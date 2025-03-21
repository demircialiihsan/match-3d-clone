using Game.Gameplay.Items;
using Game.Gameplay.MatchBoardBase;
using UnityEngine;

namespace Game.Gameplay.PlaygroundBase
{
    public class Playground : MonoBehaviour
    {
        [SerializeField] Item[] items;
        [SerializeField] int objectCount;
        [SerializeField] float width, height;
        [SerializeField] MatchBoard matchBoard;
        [SerializeField] Transform walls;

        void Start()
        {
            for (int i = 0; i < objectCount; i++)
            {
                var itemPrefab = GetRandomItemPrefab();
                var item = GetRandomItem(itemPrefab);
                item.Prepare(itemPrefab.GetInstanceID(), ReleaseItem);
            }
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

        Item GetRandomItemPrefab()
        {
            return items[Random.Range(0, items.Length)];
        }

        IItem GetRandomItem(Item itemPrefab)
        {
            return Instantiate(itemPrefab, GetRandomPosition(), Random.rotation, transform);
        }

        void ReleaseItem(IItem item)
        {
            Destroy((item as Item).gameObject);
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