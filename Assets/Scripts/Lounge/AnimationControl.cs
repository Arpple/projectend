using UnityEngine;
namespace End.Lounge {
    public class AnimationControl : MonoBehaviour{
        public Animator Animator;

        public void Play() {
            this.Animator.Play("MoveUp",0);
        }
    }
}
