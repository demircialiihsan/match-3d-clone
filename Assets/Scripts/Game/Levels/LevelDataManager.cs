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

            levelData.ItemsInfo.ItemCounts.Add(new MatchItemInfo("-21026"), 15);
            levelData.ItemsInfo.ItemCounts.Add(new MatchItemInfo("44050"), 15);

            return levelData;
        }
    }
}