using Game.Gameplay.Items;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.MatchBoardBase.Internal
{
    public static class MatchBoardUtility
    {
        public static Vector3 CalculateMatchPosition(List<IItem> items)
        {
            var center = Vector3.zero;

            foreach (var item in items)
                center += item.transform.position;

            center /= items.Count;

            return center;
        }
    }
}