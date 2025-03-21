using Game.Gameplay.Items;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.MatchBoardBase
{
    public class MatchBoard : MonoBehaviour
    {
        const int matchCount = 3;

        [SerializeField] Transform[] slots;

        List<IItem> items;

        void Awake()
        {
            items = new();
        }

        public void PlaceItem(IItem item)
        {
            if (HasItemOfSameType(item.ID, out var newItemIndex))
            {
                InsertItem(item, newItemIndex);
                TryMatchItems(item.ID, newItemIndex);
            }
            else
            {
                newItemIndex = items.Count;
                InsertItem(item, newItemIndex);
            }
        }

        bool HasItemOfSameType(int id, out int newPlacementIndex)
        {
            newPlacementIndex = items.Count;

            while (newPlacementIndex > 0)
            {
                if (items[newPlacementIndex - 1].ID == id)
                    return true;

                newPlacementIndex--;
            }
            return false;
        }

        void InsertItem(IItem item, int index)
        {
            var slot = slots[index];
            item.MoveToMatchBoard(slot.position, slot.rotation);

            items.Insert(index, item);
            RepositionItems(index + 1);
        }

        void TryMatchItems(int id, int newItemIndex)
        {
            if (newItemIndex < matchCount - 1)
                return;

            int i = newItemIndex;

            for (int m = 0; m < matchCount - 1; m++)
            {
                if (items[i - 1].ID != id)
                    return;
                i--;
            }

            var matches = items.GetRange(i, matchCount);

            foreach (var item in matches)
                item.Dispose();

            items.RemoveRange(i, matchCount);
            RepositionItems(i);
        }

        void RepositionItems(int index)
        {
            for (int i = index; i < items.Count; i++)
            {
                var slot = slots[i];
                items[i].RepositionOnMatchBoard(slot.position);
            }
        }
    }
}