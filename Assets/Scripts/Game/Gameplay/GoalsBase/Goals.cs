using Game.Gameplay.GoalsBase.MatchGoals;
using Game.Gameplay.MatchBoardBase;
using Game.Levels;
using Game.Levels.GoalInfos;
using Game.Libraries.MatchItems;
using Game.Services;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.GoalsBase
{
    public class Goals : MonoBehaviour
    {
        [SerializeField] Transform goalsPanel;
        [SerializeField] MatchGoalDisplay matchGoalDisplayPrefab;
        [SerializeField] MatchBoard matchBoard;

        Dictionary<string, (int, MatchGoalDisplay)> matchGoals;

        void OnDestroy()
        {
            matchBoard.MatchItemCollected -= OnMatchItemCollected;
        }

        public void Prepare(GoalsInfo goalsInfo)
        {
            CreateGoals(goalsInfo);

            matchBoard.MatchItemCollected += OnMatchItemCollected;
        }

        void CreateGoals(GoalsInfo goalsInfo)
        {
            matchGoals = new();

            var library = ServiceProvider.Get<MatchItemLibraryManager>().Library;

            foreach (var goalInfo in goalsInfo.Goals)
            {
                if (goalInfo is MatchGoalInfo matchGoalInfo)
                {
                    var image = library.GetMatchItemData(matchGoalInfo.ItemID).Image;

                    var goalDisplay = Instantiate(matchGoalDisplayPrefab, goalsPanel);
                    goalDisplay.Prepare(new MatchGoalDisplayData(image, matchGoalInfo.TargetCount));
                    matchGoals.Add(matchGoalInfo.ItemID, (matchGoalInfo.TargetCount, goalDisplay));
                }
                else
                {
                    Debug.LogWarning($"Can't create {goalInfo.GetType().Name} in {nameof(Goals)}");
                }
            }
        }

        void OnMatchItemCollected(string id)
        {
            if (matchGoals.TryGetValue(id, out (int count, MatchGoalDisplay display) goal))
            {
                goal.count--;
                matchGoals[id] = (goal.count, goal.display);
                goal.display.SetRemainingCount(goal.count);

                if (goal.count == 0)
                {
                    Destroy(goal.display.gameObject);
                    matchGoals.Remove(id);

                    if (matchGoals.Count == 0)
                    {
                        Debug.Log("Win! All goals are completed");
                    }
                }
            }
        }
    }
}