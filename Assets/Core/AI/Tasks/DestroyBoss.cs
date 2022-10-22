using BehaviorDesigner.Runtime.Tasks;
using Core.Character;
using Core.Util;
using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace Core.AI
{
    public class DestroyBoss : EnemyAction
    {
        public float bleedTime = 2.0f;
        public ParticleSystem bleedEffect;
        public ParticleSystem explodeEffect;

        private bool isDestroyed;

        public override void OnStart()
        {
            EffectManager.Instance.PlayOneShot(bleedEffect, transform.position);
            DOVirtual.DelayedCall(bleedTime, () =>
            {
                EffectManager.Instance.PlayOneShot(explodeEffect, transform.position);
                CameraController.Instance.ShakeCamera(0.7f);
                isDestroyed = true;
                Object.Destroy(gameObject);
            }, false);
        }

        public override TaskStatus OnUpdate()
        {
            return isDestroyed ? TaskStatus.Success : TaskStatus.Running;
        }
    }
}