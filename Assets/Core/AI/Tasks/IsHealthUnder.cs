using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using UnityEngine;

namespace Core.AI
{
    public class IsHealthUnder : EnemyConditional
    {
        public SharedInt HealthTreshold;

        public override TaskStatus OnUpdate()
        {
            return destructable.CurrentHealth < HealthTreshold.Value ? TaskStatus.Success : TaskStatus.Failure;
        }
    }
}