using Game.Gameplay.ItemProviding;
using Game.Gameplay.Items;
using Game.Gameplay.MatchBoardBase;
using Game.Levels;
using Game.Services;
using UnityEngine;

namespace Game.Gameplay.PlaygroundBase
{
    public class Playground : MonoBehaviour
    {
        [SerializeField] float width, height;
        [SerializeField] MatchBoard matchBoard;
        [SerializeField] Transform walls;

        public void Prepare(ItemsInfo itemsInfo, int matchCount)
        {
            CreateItems(itemsInfo, matchCount);
        }

        void OnValidate()
        {
            if (walls)
                walls.localScale = new Vector3(width, 1, height);
        }

        public void OnItemSelected(IItem item)
        {
            matchBoard.PlaceItem(item);
        }

        void CreateItems(ItemsInfo itemsInfo, int matchCount)
        {
            var itemProvider = ServiceProvider.Get<ItemProvideManager>();

            foreach (var (info, count) in itemsInfo.ItemCounts)
            {
                for (int i = 0; i < count * matchCount; i++)
                {
                    var item = itemProvider.GetItem(info.ItemType, info);
                    item.transform.SetPositionAndRotation(GetRandomPosition(), Random.rotation);
                }
            }
        }

        Vector3 GetRandomPosition()
        {
            return new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(0.2f, 1f), Random.Range(-2.5f, 2.5f));
        }

#if UNITY_EDITOR
        void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(transform.position, new Vector3(width, 1, height));
        }
#endif
    }
}