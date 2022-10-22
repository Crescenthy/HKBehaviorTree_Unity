using BehaviorDesigner.Runtime.Tasks;
using Core.Character;
using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace Core.AI
{
    public class Jump : EnemyAction
    {
        public float horizontalForce = 5.0f;
        public float jumpForce = 10.0f;

        public float buildupTime;
        public float jumpTime;

        public string animationTriggerName;
        public bool shakeCamerOnLanding;

        private bool hasLanded;

        private Tween buildupTween;
        private Tween jumpTween;

        public override void OnStart()
        {
            DOVirtual.DelayedCall(buildupTime, StartJump, false);
            animator.SetTrigger(animationTriggerName);
        }

        private void StartJump()
        {
            var direction = player.transform.position.x < transform.position.x ? -1 : 1;
            body.AddForce(new Vector2(horizontalForce * direction, jumpForce), ForceMode2D.Impulse);

            DOVirtual.DelayedCall(jumpTime, () =>
            {
                hasLanded = true;
                if (shakeCamerOnLanding)
                    CameraController.Instance.ShakeCamera(0.5f);
            }, false);
        }

        public override TaskStatus OnUpdate()
        {
            return hasLanded ? TaskStatus.Success : TaskStatus.Running;
        }

        public override void OnEnd()
        {
            buildupTween?.Kill();
            jumpTween?.Kill();
            hasLanded = false;
        }
    }
}