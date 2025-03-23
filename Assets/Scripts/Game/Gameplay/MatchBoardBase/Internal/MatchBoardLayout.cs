using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.MatchBoardBase.Internal
{
    public class MatchBoardLayout : MonoBehaviour
    {
        [SerializeField] float cellWidth;
        [SerializeField] float cellHeight;
        [SerializeField] float spacing;
        [Space]
        [SerializeField] float itemPlacementOffset;
        [SerializeField] float matchPositionOffset;

        Transform selfTransform;
        float firstCellPosX;

        public Quaternion Rotation => selfTransform.rotation;

        public Vector3 MatchOffset => selfTransform.up * matchPositionOffset;

        Vector3 PlacementOffset => -selfTransform.forward * itemPlacementOffset;

        void Awake()
        {
            selfTransform = transform;
        }

        public void UpdateLayout()
        {
            var children = new List<RectTransform>();

            foreach (Transform child in transform)
            {
                if (child.gameObject.activeSelf)
                {
                    var childRect = child as RectTransform;

                    if (childRect != null)
                        children.Add(childRect);
                }
            }

            var count = children.Count;

            var totalWidth = (count * cellWidth) + ((count - 1) * spacing);
            firstCellPosX = -totalWidth * 0.5f + cellWidth * 0.5f;

            for (int i = 0; i < count; i++)
            {
                var child = children[i];
                child.sizeDelta = new Vector2(cellWidth, cellHeight);
                child.anchoredPosition = CalculateCellLocalPosition(i);
                child.anchorMin = new Vector2(0.5f, 0.5f);
                child.anchorMax = new Vector2(0.5f, 0.5f);
                child.pivot = new Vector2(0.5f, 0.5f);
            }
        }

        public Vector3 CalculateCellPosition(int index)
        {
            return selfTransform.TransformPoint(CalculateCellLocalPosition(index)) + PlacementOffset;
        }

        Vector2 CalculateCellLocalPosition(int index)
        {
            return new Vector2(firstCellPosX + index * (cellWidth + spacing), 0);
        }
    }
}