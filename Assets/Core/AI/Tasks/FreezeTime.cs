using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using UnityEngine;

namespace Core.AI
{
    public class FreezeTime : EnemyAction
    {
        public SharedFloat Duration = 0.1f;

        public override TaskStatus OnUpdate()
        {
            GameManager.Instance.FreezeTime(Duration.Value);
            return TaskStatus.Success;
        }
    }
}