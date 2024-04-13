using UnityEngine;

namespace Character
{
    public class CharacterData : MonoBehaviour
    {
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private Transform camera;
        [SerializeField] private Transform feet;
        [SerializeField] private LayerMask floorMask;
        [SerializeField] private GameObject aim;
        [SerializeField] private float speed;
        [SerializeField] private float runSpeed;
        [SerializeField] private float jumpForce;
        [SerializeField] private float sensitivity;
        [SerializeField] private float lookXLimit;

        public Rigidbody Rb => rigidbody;
        public Transform PlayerCamera => camera;
        public Transform FeetTransform => feet;
        public LayerMask FloorMask => floorMask;
        public GameObject Aim => aim;
        public float Speed => speed;
        public float RunSpeed => runSpeed;
        public float JumpForce => jumpForce;
        public float Sensitivity => sensitivity;
        public float LookXLimit => lookXLimit;
        public Transform Transform => transform;
    }
}