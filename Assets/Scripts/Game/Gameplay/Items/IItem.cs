using System;
using UnityEngine;

namespace Game.Gameplay.Items
{
    public interface IItem
    {
        int ID { get; }

        bool MatchFlagged { get; set; }

        void Prepare(int id, Action<IItem> disposer);

        void Dispose();

        void MoveToMatchBoard(Vector3 position, Quaternion rotation, Action onMoveComplete = null);

        void RepositionOnMatchBoard(Vector3 position);
    }
}