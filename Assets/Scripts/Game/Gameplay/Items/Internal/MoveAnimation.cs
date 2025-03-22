using DG.Tweening;
using System;
using UnityEngine;

namespace Game.Gameplay.Items.Internal
{
    public class MoveAnimation : MonoBehaviour
    {
        const float rotateDuration = 0.2f;
        const float moveDuration = 0.5f;
        const float repositionDuration = 0.2f;

        Tween rotateTween;
        Sequence moveSequence;
        Tween repositionTween;

        Action moveCompleteHandler;

        void OnDestroy()
        {
            rotateTween.Kill();
            moveSequence.Kill();
            repositionTween.Kill();
        }

        public void MoveToPositionAndRotation(Vector3 position, Quaternion rotation, Action moveCompleteHandler = null)
        {
            rotateTween = transform.DORotateQuaternion(rotation, rotateDuration).SetEase(Ease.OutSine);

            moveSequence = DOTween.Sequence();
            moveSequence.Join(transform.DOMoveX(position.x, moveDuration).SetEase(Ease.OutSine));
            moveSequence.Join(transform.DOMoveY(position.y, moveDuration).SetEase(Ease.OutBack));
            moveSequence.Join(transform.DOMoveZ(position.z, moveDuration).SetEase(Ease.OutSine));

            this.moveCompleteHandler = moveCompleteHandler;
            moveSequence.AppendCallback(() =>
            {
                this.moveCompleteHandler?.Invoke();
            });
        }

        public void Reposition(Vector3 position)
        {
            if (moveSequence.IsActive())
                moveSequence.Kill();

            repositionTween.Kill();
            repositionTween = transform.DOMove(position, repositionDuration).SetEase(Ease.OutSine).OnComplete(() =>
            {
                moveCompleteHandler?.Invoke();
            });
        }
    }
}