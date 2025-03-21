using System;
using UnityEngine;

namespace Game.Gameplay.Items
{
    public interface IItem
    {
        int ID { get; }

        void Prepare(int id, Action<IItem> disposer);

        void Dispose();

        void DisablePhysics();

        void MoveToPositionAndRotation(Vector3 position, Quaternion rotation);
    }
}