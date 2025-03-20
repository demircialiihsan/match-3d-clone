using Game.Gameplay.Mechanics;
using UnityEngine;

namespace Game.Gameplay.PlaygroundBase
{
    public class TouchController : MonoBehaviour
    {
        [SerializeField] TouchDetector touchDetector;
        [SerializeField] Camera gameCamera;
        [SerializeField] Transform target;

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
            if (Physics.Raycast(gameCamera.ScreenPointToRay(touchPosition), out RaycastHit hit))
            {
                if (hit.collider.gameObject.TryGetComponent(out Rigidbody rb))
                {
                    rb.isKinematic = true;
                    hit.collider.transform.SetParent(target);
                    hit.collider.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
                }
            }
        }
    }
}