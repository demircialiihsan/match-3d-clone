using System;
using UnityEngine;
using Utilities;

namespace Game.Gameplay.Mechanics
{
    public class TouchDetector : MonoBehaviour
    {
        public event Action<Vector2> TouchEnded;

        void Update()
        {
            if (TouchUtility.TouchCount > 0)
            {
                var touch = TouchUtility.GetTouch(0);
                ProcessTouch(touch);
            }
        }

        void ProcessTouch(Touch touch)
        {
            if (touch.phase == TouchPhase.Ended)
            {
                TouchEnded?.Invoke(touch.position);
            }
        }
    }
}