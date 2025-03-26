using UnityEngine;

namespace Game.Gameplay.GoalsBase.MatchGoals
{
    public class MatchGoalDisplayData : GoalDisplayData
    {
        readonly Sprite image;
        readonly int targetCount;

        public Sprite Image => image;

        public int TargetCount => targetCount;

        public MatchGoalDisplayData(Sprite image, int targetCount)
        {
            this.image = image;
            this.targetCount = targetCount;
        }
    }
}