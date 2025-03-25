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

        string id;
        Action<Item> disposer;

        public string ID => id;

        public bool MatchFlagged { get; set; }

        public void Prepare(string id, Action<Item> disposer)
        {
            this.id = id;
            this.disposer = disposer;
        }

        public void MoveToMatchBoard(Vector3 position, Quaternion rotation, Action onMoveComplete = null)
        {
            moveAnimation.MoveToPositionAndRotation(position, rotation, onMoveComplete);
            DisablePhysics();
        }

        public void RepositionOnMatchBoard(Vector3 position)
        {
            moveAnimation.Reposition(position);
        }

        public void MoveToMatchTarget(Vector3 position, Action onMoveComplete = null)
        {
            moveAnimation.MoveToMatchTarget(position, onMoveComplete);
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