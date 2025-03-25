using Game.Gameplay.Items;
using Game.Levels.ItemInfos;

namespace Game.Gameplay.ItemProviding.Internal
{
    public interface IItemProvider
    {
        IItem GetItem(ItemInfo itemData);
    }
}