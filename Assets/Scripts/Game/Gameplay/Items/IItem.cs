using System;
using UnityEngine;

namespace Game.Gameplay.Items
{
    public interface IItem
    {
        int ID { get; }

        void Prepare(int id, Action<IItem> disposer);

        void Dispose();

        void MoveToMatchBoard(Vector3 position, Quaternion rotation);

        void RepositionOnMatchBoard(Vector3 position);
    }
}