using Game.Gameplay.ItemProviding.Internal;
using Game.Gameplay.Items;
using Game.Levels.ItemInfos;
using Game.Services;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.ItemProviding
{
    public class ItemProvideManager : MonoBehaviour, IService
    {
        static readonly Dictionary<ItemType, IItemProvider> providers = new();

        void Awake()
        {
            ServiceProvider.Register(this);
        }

        void OnDestroy()
        {
            ServiceProvider.Unregister<ItemProvideManager>();
        }

        public static void RegisterItemProvider(ItemType providerType, IItemProvider provider)
        {
            providers.Add(providerType, provider);
        }

        public static void UnregisterItemProvider(ItemType providerType, IItemProvider provider)
        {
            if (providers.TryGetValue(providerType, out var p) && p == provider)
            {
                providers.Remove(providerType);
            }
        }

        public IItem GetItem(ItemType itemType, ItemInfo itemData)
        {
            if (providers.TryGetValue(itemType, out var provider))
            {
                return provider.GetItem(itemData);
            }
            else
            {
                Debug.LogWarning($"Item provider for {itemType} type not found");
                return null;
            }
        }
    }
}