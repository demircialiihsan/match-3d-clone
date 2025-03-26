using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Gameplay.GoalsBase.MatchGoals
{
    public class MatchGoalDisplay : MonoBehaviour, IGoalDisplay
    {
        [SerializeField] Image itemImage;
        [SerializeField] TMP_Text remainingCountText;

        public void Prepare(GoalDisplayData displayData)
        {
            if (displayData is not MatchGoalDisplayData matchGoalDisplayData)
            {
                Debug.LogWarning($"Can't display {displayData.GetType().Name} in {nameof(MatchGoalDisplay)}");
                return;
            }

            SetItemImage(matchGoalDisplayData.Image);
            SetRemainingCount(matchGoalDisplayData.TargetCount);
        }

        public void SetRemainingCount(int remainingCount)
        {
            remainingCountText.text = remainingCount.ToString();
        }

        void SetItemImage(Sprite image)
        {
            itemImage.sprite = image;
        }
    }
}