using Game.Gameplay.Items;
using UnityEngine;

namespace Game.Libraries.MatchItems
{
    [CreateAssetMenu(fileName = "NewMatchItemDataObject", menuName = "Libraries/Items/Match Items/Match Item Data Object")]
    public class MatchItemDataSO : ScriptableObject
    {
        [SerializeField] Item prefab;
        [SerializeField] Sprite image;

        public Item Prefab => prefab;

        public Sprite Image => image;
    }
}