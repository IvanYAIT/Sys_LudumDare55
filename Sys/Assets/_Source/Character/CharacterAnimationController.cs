using UnityEngine;

namespace Character
{
    public class CharacterAnimationController : MonoBehaviour
    {
        private static int WALK_ANIMATION_ID = Animator.StringToHash("Walking");
        private static int SPRINT_ANIMATION_ID = Animator.StringToHash("Running");
        private static int JUMP_ANIMATION_ID = Animator.StringToHash("Jump");

        [SerializeField] private Animator animator;

        public void Walk(bool value) =>
            animator.SetBool(WALK_ANIMATION_ID, value);

        public void Run(bool value) =>
            animator.SetBool(SPRINT_ANIMATION_ID, value);

        public void Jump() =>
            animator.SetTrigger(JUMP_ANIMATION_ID);
    }
}