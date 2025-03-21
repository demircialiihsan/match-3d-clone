using Game.Gameplay.Items.Internal;
using System;
using UnityEngine;

namespace Game.Gameplay.Items
{
    public class Item : MonoBehaviour, IItem
    {
        [SerializeField] MoveAnimation moveAnimation;
        [SerializeField] Rigidbody rb;
        [SerializeField] Collider col;

        int id;
        Action<IItem> disposer;

        public int ID => id;

        public void Prepare(int id, Action<IItem> disposer)
        {
            this.id = id;
            this.disposer = disposer;
        }

        public void MoveToMatchBoard(Vector3 position, Quaternion rotation)
        {
            moveAnimation.MoveToPositionAndRotation(position, rotation);
            DisablePhysics();
        }

        public void RepositionOnMatchBoard(Vector3 position)
        {
            moveAnimation.Reposition(position);
        }

        public void Dispose()
        {
            disposer?.Invoke(this);
        }

        void DisablePhysics()
        {
            rb.isKinematic = true;
            col.enabled = false;
        }
    }
}