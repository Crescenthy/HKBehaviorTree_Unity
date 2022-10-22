using BehaviorDesigner.Runtime.Tasks;
using Core.UI;
using System.Collections;
using UnityEngine;

namespace Core.AI
{
    public class InitBoss : EnemyAction
    {
        public string bossName;

        public override TaskStatus OnUpdate()
        {
            GuiManager.Instance.ShowBossName(bossName);
            return TaskStatus.Success;
        }
    }
}