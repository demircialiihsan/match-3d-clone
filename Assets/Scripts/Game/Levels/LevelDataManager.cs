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
                }
            };

            levelData.ItemsInfo.ItemCounts.Add(new MatchItemInfo("b7e5d859e7178b249a4953c8c49c5df2"), 15);
            levelData.ItemsInfo.ItemCounts.Add(new MatchItemInfo("2d35446f795e8354aaef493a09c90a38"), 15);

            return levelData;
        }
    }
}