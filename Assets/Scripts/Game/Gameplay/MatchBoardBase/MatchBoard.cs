using Game.Gameplay.Items;
using Game.Gameplay.MatchBoardBase.Internal;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.MatchBoardBase
{
    public class MatchBoard : MonoBehaviour
    {
        const int matchCount = 3;

        [SerializeField] Transform[] slots;

        List<IItem> items;
        Dictionary<IItem, List<IItem>> matchFlaggedItems;

        void Awake()
        {
            items = new();
            matchFlaggedItems = new();
        }

        public void PlaceItem(IItem item)
        {
            if (HasUnmatchedItemOfSameType(item.ID, out var newItemIndex))
            {
                InsertItem(item, newItemIndex, OnItemInserted);
                TryMatchFlagItems(item, newItemIndex);
            }
            else
            {
                newItemIndex = items.Count;
                InsertItem(item, newItemIndex);
            }
        }

        bool HasUnmatchedItemOfSameType(int id, out int newPlacementIndex)
        {
            newPlacementIndex = items.Count;

            while (newPlacementIndex > 0)
            {
                var previousItem = items[newPlacementIndex - 1];

                if (!previousItem.MatchFlagged && previousItem.ID == id)
                    return true;

                newPlacementIndex--;
            }
            return false;
        }

        void InsertItem(IItem item, int index, Action<IItem> onItemInsert = null)
        {
            var slot = slots[index];
            item.MoveToMatchBoard(slot.position, slot.rotation, () =>
            {
                onItemInsert?.Invoke(item);
            });

            items.Insert(index, item);
            RepositionItems(index + 1);
        }

        void TryMatchFlagItems(IItem completingItem, int newItemIndex)
        {
            if (newItemIndex < matchCount - 1)
                return;

            int i = newItemIndex;

            for (int m = 0; m < matchCount - 1; m++)
            {
                var previousItem = items[i - 1];

                if (previousItem.ID != completingItem.ID || previousItem.MatchFlagged)
                    return;
                i--;
            }

            var otherMatches = items.GetRange(i, matchCount - 1);

            completingItem.MatchFlagged = true;
            foreach (var item in otherMatches)
            {
                item.MatchFlagged = true;
            }

            matchFlaggedItems[completingItem] = otherMatches;
        }

        void OnItemInserted(IItem item)
        {
            if (matchFlaggedItems.TryGetValue(item, out var matches))
            {
                matches.Add(item);
                MatchItems(matches);

                matchFlaggedItems.Remove(item);
            }
        }

        void MatchItems(List<IItem> matchingItems)
        {
            var matchPosition = MatchBoardUtility.CalculateMatchPosition(matchingItems);

            for (int i = 0; i < matchingItems.Count; i++)
            {
                var item = matchingItems[i];

                items.Remove(item);

                if (i == 0)
                    item.MoveToMatchTarget(matchPosition, OnMatchComplete);
                else
                    item.MoveToMatchTarget(matchPosition);
            }

            RepositionItems();

            void OnMatchComplete()
            {
                foreach (var match in matchingItems)
                {
                    match.Dispose();
                }
            }
        }

        void RepositionItems(int startIndex = 0)
        {
            for (int i = startIndex; i < items.Count; i++)
            {
                var slot = slots[i];
                items[i].RepositionOnMatchBoard(slot.position);
            }
        }
    }
}