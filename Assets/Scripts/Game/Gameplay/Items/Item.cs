using System;
using UnityEngine;

namespace Game.Gameplay.Items
{
    public class Item : MonoBehaviour, IItem
    {
        [SerializeField] Rigidbody rb;

        int id;
        Action<IItem> disposer;

        public int ID => id;

        public void Prepare(int id, Action<IItem> disposer)
        {
            this.id = id;
            this.disposer = disposer;
        }

        public void DisablePhysics()
        {
            rb.isKinematic = true;
        }

        public void MoveToPositionAndRotation(Vector3 position, Quaternion rotation)
        {
            transform.SetPositionAndRotation(position, rotation);
        }

        public void Dispose()
        {
            disposer?.Invoke(this);
        }
    }
}