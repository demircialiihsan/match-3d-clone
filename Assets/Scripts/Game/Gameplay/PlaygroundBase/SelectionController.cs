using Game.Gameplay.Items;
using Game.Gameplay.Mechanics;
using UnityEngine;

namespace Game.Gameplay.PlaygroundBase
{
    public class SelectionController : MonoBehaviour
    {
        [SerializeField] TouchDetector touchDetector;
        [SerializeField] Camera gameCamera;
        [SerializeField] Playground playground;

        void Start()
        {
            touchDetector.TouchEnded += OnTouchEnded;
        }

        void OnDestroy()
        {
            touchDetector.TouchEnded -= OnTouchEnded;
        }

        void OnTouchEnded(Vector2 touchPosition)
        {
            if (Physics.Raycast(gameCamera.ScreenPointToRay(touchPosition), out var hit))
            {
                if (hit.rigidbody != null && hit.rigidbody.TryGetComponent(out IItem item))
                {
                    playground.OnItemSelected(item);
                }
            }
        }
    }
}