using Audio;
using UnityEngine;

namespace Character
{
    public class CharacterAction
    {
        private float _xRot;

        public void Move(Transform transform,Rigidbody rb, Vector3 axis, float speed)
        {
            Vector3 dir = transform.TransformDirection(axis) * speed;
            rb.velocity = new Vector3(dir.x, rb.velocity.y, dir.z);
        }

        public void MoveCamera(Transform transform, Transform playerCamera, Vector3 mouseInput, float sensitivity, float lookXLimit)
        {
            _xRot -= mouseInput.y * sensitivity;
            _xRot = Mathf.Clamp(_xRot, -lookXLimit, lookXLimit);

            transform.Rotate(0f, mouseInput.x * sensitivity, 0f);
            playerCamera.localRotation = Quaternion.Euler(_xRot,0f , 0f);
        }

        public void Jump(Rigidbody rb, float jumpForce) =>
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        public void PickUp(GameObject pickedSoul, SoulCounter soulCounter, TargetPointer targetPointer, AudioPlayer audioPlayer)
        {
            pickedSoul.SetActive(false);
            soulCounter.Add();
            targetPointer.Remove(pickedSoul.transform);
            audioPlayer.Play();
        }
    }
}