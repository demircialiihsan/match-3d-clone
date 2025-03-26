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

            levelData.ItemsInfo.ItemCounts.Add(new MatchItemInfo("b7e5d859e7178b249a4953c8c49c5df2"), 15);
            levelData.ItemsInfo.ItemCounts.Add(new MatchItemInfo("2d35446f795e8354aaef493a09c90a38"), 15);

            levelData.GoalsInfo.Goals.Add(new MatchGoalInfo("b7e5d859e7178b249a4953c8c49c5df2", 6));
            levelData.GoalsInfo.Goals.Add(new MatchGoalInfo("2d35446f795e8354aaef493a09c90a38", 9));

            return levelData;
        }
    }
}