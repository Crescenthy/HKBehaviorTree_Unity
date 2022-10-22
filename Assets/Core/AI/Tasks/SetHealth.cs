using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using UnityEngine;

namespace Core.AI
{
    public class SetHealth : EnemyAction
    {
        public SharedInt Health;

        public override TaskStatus OnUpdate()
        {
            destructable.CurrentHealth = Health.Value;
            return TaskStatus.Success;
        }
    }
}