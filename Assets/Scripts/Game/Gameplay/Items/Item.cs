using UnityEngine;

namespace Game.Gameplay.Items
{
    public class Item : MonoBehaviour, IItem
    {
        [SerializeField] Rigidbody rb;

        public void DisablePhysics()
        {
            rb.isKinematic = true;
        }

        public void MoveToPositionAndRotation(Vector3 position, Quaternion rotation)
        {
            transform.SetPositionAndRotation(position, rotation);
        }
    }
}