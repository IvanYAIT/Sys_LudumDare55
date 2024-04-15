using Audio;
using UnityEngine;
using Zenject;

namespace Character
{
    public class CharacterAction
    {
        private CharacterAnimationController _animController;

        [Inject]
        public CharacterAction(CharacterAnimationController animController)
        {
            _animController = animController;
        }

        public void Move(Rigidbody rb, Transform orientation, Vector3 axis, float speed, bool isRunning)
        {
            Vector3 moveDir = orientation.forward * axis.z + orientation.right * axis.x;
            rb.AddForce(moveDir.normalized * speed * 10f, ForceMode.Force);

            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            if (flatVel.magnitude > speed)
            {
                Vector3 limiteVel = flatVel.normalized * speed;
                rb.velocity = new Vector3(limiteVel.x, rb.velocity.y, limiteVel.z);
            }

            if (axis == Vector3.zero)
            {
                rb.velocity = new Vector3(0, rb.velocity.y, 0);
                _animController.Walk(false);
                _animController.Run(false);
            }

            if (!isRunning)
                _animController.Walk(axis != Vector3.zero);
            else
                _animController.Run(axis != Vector3.zero);
        }

        public void MoveCamera(Transform transform, Transform playerBodyTransform, Transform playerCamera, Transform orientation, Vector3 axis, float sensitivity)
        {
            Vector3 viewDir = transform.position - new Vector3(playerCamera.position.x, transform.position.y, playerCamera.position.z);
            orientation.forward = viewDir.normalized;

            Vector3 inputDir = orientation.forward * axis.z + orientation.right * axis.x;
            if (inputDir != Vector3.zero)
            {
                playerBodyTransform.forward = Vector3.Slerp(playerBodyTransform.forward, inputDir.normalized, Time.deltaTime * sensitivity);
            }

        }

        public void Jump(Rigidbody rb, float jumpForce)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            _animController.Jump();
        }

        public void PickUp(GameObject pickedSoul, SoulCounter soulCounter, TargetPointer targetPointer, AudioPlayer audioPlayer)
        {
            pickedSoul.SetActive(false);
            soulCounter.Add();
            targetPointer.Remove(pickedSoul.transform);
            audioPlayer.Play();
        }
    }
}