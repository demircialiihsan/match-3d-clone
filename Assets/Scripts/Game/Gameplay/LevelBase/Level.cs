using Game.Gameplay.MatchBoardBase;
using Game.Gameplay.PlaygroundBase;
using Game.Levels;
using UnityEngine;

namespace Game.Gameplay.LevelBase
{
    public class Level : MonoBehaviour
    {
        [SerializeField] Playground playground;

        void Start()
        {
            var levelData = LevelDataManager.LoadLevelData();

            playground.Prepare(levelData.ItemsInfo, MatchBoard.MatchCount);
        }
    }
}