using BehaviorDesigner.Runtime.Tasks;
using Core.Combat.Projectiles;
using DG.Tweening;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Core.AI
{
    public class SpawnFallingRocks : EnemyAction
    {
        public Collider2D spawnAreaCollider;
        public AbstractProjectile rockPrefab;
        public int spawnCount = 4;
        public float spawnInterval = 0.3f;

        public override TaskStatus OnUpdate()
        {
            var sequence = DOTween.Sequence();
            for (int i = 0; i < spawnCount; i++)
            {
                sequence.AppendCallback(SpawnRocks);
                sequence.AppendInterval(spawnInterval);
            }
            return TaskStatus.Success;
        }

        private void SpawnRocks()
        {
            var randomX = UnityEngine.Random.Range(spawnAreaCollider.bounds.min.x, spawnAreaCollider.bounds.max.x);
            var rock = Object.Instantiate(rockPrefab, new Vector2(randomX, spawnAreaCollider.bounds.min.y), quaternion.identity);
            rock.SetForce(Vector2.zero);
        }
    }
}