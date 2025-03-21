using Game.Gameplay.Items;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.MatchBoardBase
{
    public class MatchBoard : MonoBehaviour
    {
        [SerializeField] Transform[] slots;

        List<IItem> items;

        void Awake()
        {
            items = new();
        }

        public void PlaceItem(IItem item)
        {
            var slot = slots[items.Count];
            item.MoveToPositionAndRotation(slot.position, slot.rotation);
            item.DisablePhysics();

            items.Add(item);
        }
    }
}