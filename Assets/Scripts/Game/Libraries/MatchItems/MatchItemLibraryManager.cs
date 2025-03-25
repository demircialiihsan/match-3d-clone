using Game.Services;
using UnityEngine;

namespace Game.Libraries.MatchItems
{
    public class MatchItemLibraryManager : MonoBehaviour, IService
    {
        [SerializeField] MatchItemLibrarySO library;

        public MatchItemLibrarySO Library
        {
            get
            {
                if (library == null)
                    Debug.LogWarning($"Library reference is null", this);
                return library;
            }
        }

        void Awake()
        {
            ServiceProvider.Register(this);
        }

        void OnDestroy()
        {
            ServiceProvider.Unregister<MatchItemLibraryManager>();
        }
    }
}