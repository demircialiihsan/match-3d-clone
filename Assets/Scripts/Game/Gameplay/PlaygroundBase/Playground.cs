using Game.Gameplay.Items;
using Game.Gameplay.MatchBoardBase;
using UnityEngine;

namespace Game.Gameplay.PlaygroundBase
{
    public class Playground : MonoBehaviour
    {
        [SerializeField] GameObject[] objects;
        [SerializeField] int objectCount;
        [SerializeField] float width, height;
        [SerializeField] MatchBoard matchBoard;
        [SerializeField] Transform walls;

        void Start()
        {
            for (int i = 0; i < objectCount; i++)
            {
                Instantiate(GetRandomObject(), GetRandomPosition(), Random.rotation, transform);
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

        GameObject GetRandomObject()
        {
            return objects[Random.Range(0, objects.Length)];
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