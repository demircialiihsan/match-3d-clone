using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Game.Libraries.MatchItems
{
    [CreateAssetMenu(fileName = "NewMatchItemLibrary", menuName = "Libraries/Items/Match Items/Match Item Library")]
    public class MatchItemLibrarySO : ScriptableObject
    {
        [SerializeField, HideInInspector] string[] ids;
        [SerializeField] MatchItemDataSO[] items;

        Dictionary<string, MatchItemDataSO> itemsByIDs;

        public MatchItemDataSO GetMatchItemData(string id)
        {
            if (itemsByIDs == null)
                LoadDictionary();

            if (itemsByIDs.TryGetValue(id, out var item))
            {
                return item;
            }
            else
            {
                Debug.LogWarning($"No item data available for id: {id}", this);
                return null;
            }
        }

        void LoadDictionary()
        {
            itemsByIDs = new Dictionary<string, MatchItemDataSO>();

            for (int i = 0; i < ids.Length && i < items.Length; i++)
            {
                var item = items[i];

                if (item == null)
                    continue;

                itemsByIDs[ids[i]] = item;
            }
        }

#if UNITY_EDITOR
        void OnValidate()
        {
            SaveIDs();
        }

        void SaveIDs()
        {
            if (ids.Length != items.Length)
                ids = new string[items.Length];

            for (int i = 0; i < items.Length; i++)
            {
                var item = items[i];

                if (item == null)
                    continue;

                var path = AssetDatabase.GetAssetPath(item);
                if (!string.IsNullOrEmpty(path))
                    ids[i] = AssetDatabase.AssetPathToGUID(path);
            }
        }
#endif
    }
}