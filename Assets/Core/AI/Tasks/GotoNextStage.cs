using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using UnityEngine;

namespace Core.AI
{
    public class GotoNextStage : EnemyAction
    {
        public SharedInt CurrentStage;

        public override TaskStatus OnUpdate()
        {
            CurrentStage.Value += 1;
            return TaskStatus.Success;
        }
    }
}