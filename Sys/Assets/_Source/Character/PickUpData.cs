using UnityEngine;

namespace Character
{
    [CreateAssetMenu(fileName = "PickUpData", menuName = "SO/NewPickUpData")]
    public class PickUpData : ScriptableObject
    {
        [SerializeField] private float distanceToPickUp;
        [SerializeField] private LayerMask soulLayerMask;
        [SerializeField] private LayerMask speedSoulLayerMask;

        public float DistanceToPickUp => distanceToPickUp;
        public LayerMask SoulLayerMask => soulLayerMask;
        public LayerMask SpeedSoulLayerMask => speedSoulLayerMask;
    }
}