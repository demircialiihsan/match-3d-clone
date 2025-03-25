using Game.Gameplay.Items;

namespace Game.Levels.ItemInfos
{
    public class MatchItemInfo : ItemInfo
    {
        readonly string id;

        public string ID => id;

        public override ItemType ItemType => ItemType.MatchItem;

        public MatchItemInfo(string id)
        {
            this.id = id;
        }
    }
}