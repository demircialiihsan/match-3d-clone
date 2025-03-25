using Game.Gameplay.Items;
using Game.Levels.ItemInfos;
using Game.Libraries.MatchItems;
using Game.Services;
using UnityEngine;

namespace Game.Gameplay.ItemProviding.Internal
{
    public class MatchItemProvider : MonoBehaviour, IItemProvider
    {
        void Awake()
        {
            ItemProvideManager.RegisterItemProvider(ItemType.MatchItem, this);
        }

        void OnDestroy()
        {
            ItemProvideManager.UnregisterItemProvider(ItemType.MatchItem, this);
        }

        public IItem GetItem(ItemInfo itemData)
        {
            if (itemData is MatchItemInfo matchItemData)
            {
                var matchItem = GetMatchItem(matchItemData.ID);
                matchItem.Prepare(matchItemData.ID, ReleaseMatchItem);
                return matchItem;
            }
            else
            {
                Debug.LogWarning($"Can't get {nameof(Item)} with {itemData.GetType().Name}");
                return null;
            }
        }

        Item GetMatchItem(string id)
        {
            var library = ServiceProvider.Get<MatchItemLibraryManager>().Library;
            var prefab = library.GetMatchItemData(id).Prefab;
            return Instantiate(prefab);
        }

        void ReleaseMatchItem(Item matchItem)
        {
            Destroy(matchItem.gameObject);
        }
    }
}