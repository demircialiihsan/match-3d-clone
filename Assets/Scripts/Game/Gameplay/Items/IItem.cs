using UnityEngine;

namespace Game.Gameplay.Items
{
    public interface IItem
    {
        void DisablePhysics();

        void MoveToPositionAndRotation(Vector3 position, Quaternion rotation);
    }
}