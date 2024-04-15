using UnityEngine;

namespace Character
{
    public class CharacterData : MonoBehaviour
    {
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private Transform camera;
        [SerializeField] private Transform feet;
        [SerializeField] private Transform orientation;
        [SerializeField] private Transform playerBodyTransform;
        [SerializeField] private LayerMask floorMask;
        [SerializeField] private GameObject hint;
        [SerializeField] private float speed;
        [SerializeField] private float runSpeed;
        [SerializeField] private float jumpForce;
        [SerializeField] private float sensitivity;
        [SerializeField] private float boostMulti;

        public Rigidbody Rb => rigidbody;
        public Transform PlayerCamera => camera;
        public Transform FeetTransform => feet;
        public LayerMask FloorMask => floorMask;
        public GameObject Hint => hint;
        public float Speed => speed;
        public float RunSpeed => runSpeed;
        public float JumpForce => jumpForce;
        public float Sensitivity => sensitivity;
        public Transform Transform => transform;
        public Transform Orientation => orientation;
        public Transform PlayerBodyTransform => playerBodyTransform;

        public void SpeedUp()
        {
            speed *= boostMulti;
            runSpeed *= boostMulti;
        }
    }
}