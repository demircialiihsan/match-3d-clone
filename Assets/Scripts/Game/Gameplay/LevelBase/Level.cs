using Game.Gameplay.GoalsBase;
using Game.Gameplay.MatchBoardBase;
using Game.Gameplay.PlaygroundBase;
using Game.Levels;
using UnityEngine;

namespace Game.Gameplay.LevelBase
{
    public class Level : MonoBehaviour
    {
        [SerializeField] Playground playground;
        [SerializeField] Goals goals;

        void Start()
        {
            var levelData = LevelDataManager.LoadLevelData();

            playground.Prepare(levelData.ItemsInfo, MatchBoard.MatchCount);
            goals.Prepare(levelData.GoalsInfo);
        }
    }
}