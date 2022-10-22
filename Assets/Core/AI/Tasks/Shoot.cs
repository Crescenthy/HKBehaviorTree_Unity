using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Character;
using Core.Combat.Projectiles;
using Core.Combat;

namespace Core.AI
{
    public class Shoot : EnemyAction
    {
        //public List<Weapon> weapons;
        public Transform weaponTransform;
        public AbstractProjectile projectilePrefab;
        public float horizontalForce;
        public float verticalForce;

        public bool shakeCamera;

        public override TaskStatus OnUpdate()
        {
            //foreach (var weapon in weapons)
            //{
            //    var projectile = UnityEngine.Object.Instantiate(weapon.projectilePrefab, weapon.weaponTransform.position, Quaternion.identity);
            //    projectile.Shooter = gameObject;

            //    var force = new Vector2(weapon.horizontalForce * transform.localScale.x, weapon.verticalForce);
            //    projectile.SetForce(force);

            //    if (shakeCamera)
            //        CameraController.Instance.ShakeCamera(0.5f);
            //}
            var projectile = Object.Instantiate(projectilePrefab, weaponTransform.position, Quaternion.identity);
            projectile.Shooter = gameObject;
            var force = new Vector2(horizontalForce * transform.localScale.x, verticalForce);
            projectile.SetForce(force);

            if (shakeCamera)
                CameraController.Instance.ShakeCamera(0.5f);

            return TaskStatus.Success;
        }
    }
}