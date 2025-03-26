namespace Game.Levels.GoalInfos
{
    public class MatchGoalInfo : GoalInfo
    {
        readonly string itemID;
        readonly int targetCount;

        public string ItemID => itemID;

        public int TargetCount => targetCount;

        public MatchGoalInfo(string itemID, int targetCount)
        {
            this.itemID = itemID;
            this.targetCount = targetCount;
        }
    }
}