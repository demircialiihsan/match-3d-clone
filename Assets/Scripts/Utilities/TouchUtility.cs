using UnityEngine;

namespace Utilities
{
    public static class TouchUtility
    {
        static Vector3 touchPosition;

        public static int TouchCount
        {
            get
            {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
            return Input.touchCount;
#else
                if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
                    return 1;
                else
                    return 0;
#endif
            }
        }

        public static Touch GetTouch(int index)
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
            return Input.GetTouch(index);
#else
            var touch = new Touch();

            if (index == 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    touch.phase = TouchPhase.Began;
                    touchPosition = Input.mousePosition;
                }
                else if (Input.GetMouseButton(0))
                {
                    if ((Input.mousePosition == touchPosition) && (touch.phase != TouchPhase.Moved))
                    {
                        touch.phase = TouchPhase.Stationary;
                    }
                    else
                    {
                        touch.phase = TouchPhase.Moved;
                    }
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    touch.phase = TouchPhase.Ended;
                }
                touch.position = Input.mousePosition;
                touch.fingerId = 0;
            }
            return touch;
#endif
        }
    }
}