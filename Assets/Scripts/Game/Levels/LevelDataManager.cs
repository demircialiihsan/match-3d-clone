using Game.Levels.GoalInfos;
using Game.Levels.ItemInfos;

namespace Game.Levels
{
    public static class LevelDataManager
    {
        public static LevelData LoadLevelData()
        {
            var levelData = new LevelData
            {
                ItemsInfo = new ItemsInfo()
                {
                    ItemCounts = new(),
                },
                GoalsInfo = new GoalsInfo()
                {
                    Goals = new(),
                }
            };

            levelData.ItemsInfo.ItemCounts.Add(new MatchItemInfo("4f58d0d81f3b04d429eda897bc9245f7"), 10);
            levelData.ItemsInfo.ItemCounts.Add(new MatchItemInfo("b7e5d859e7178b249a4953c8c49c5df2"), 10);
            levelData.ItemsInfo.ItemCounts.Add(new MatchItemInfo("2d35446f795e8354aaef493a09c90a38"), 10);
            levelData.ItemsInfo.ItemCounts.Add(new MatchItemInfo("7515a92e9d056334abfd2bd3b064738a"), 10);

            levelData.GoalsInfo.Goals.Add(new MatchGoalInfo("4f58d0d81f3b04d429eda897bc9245f7", 6));
            levelData.GoalsInfo.Goals.Add(new MatchGoalInfo("b7e5d859e7178b249a4953c8c49c5df2", 9));
            levelData.GoalsInfo.Goals.Add(new MatchGoalInfo("2d35446f795e8354aaef493a09c90a38", 3));
            levelData.GoalsInfo.Goals.Add(new MatchGoalInfo("7515a92e9d056334abfd2bd3b064738a", 6));

            return levelData;
        }
    }
}