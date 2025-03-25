using System;
using UnityEngine;

namespace Game.Gameplay.Items
{
    public interface IItem
    {
        Transform transform { get; }

        string ID { get; }

        bool MatchFlagged { get; set; }

        void Dispose();

        void MoveToMatchBoard(Vector3 position, Quaternion rotation, Action onMoveComplete = null);

        void RepositionOnMatchBoard(Vector3 position);

        void MoveToMatchTarget(Vector3 position, Action onMoveComplete = null);
    }
}