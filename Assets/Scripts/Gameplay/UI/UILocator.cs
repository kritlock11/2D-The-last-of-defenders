using Object = UnityEngine.Object;

namespace Assets.Scripts.Gameplay.UI
{
    public static class UILocator
    {
        private static Score _score;
        public static Score Score
        {
            get
            {
                if (!_score)
                    _score = Object.FindObjectOfType<Score>();
                return _score;
            }
        }

        private static Health _health;
        public static Health Health
        {
            get
            {
                if (!_health)
                    _health = Object.FindObjectOfType<Health>();
                return _health;
            }
        }

        private static Energy _energy;
        public static Energy Energy
        {
            get
            {
                if (!_energy)
                    _energy = Object.FindObjectOfType<Energy>();
                return _energy;
            }
        }

        
        private static Restart _restart;
        public static Restart Restart
        {
            get
            {
                if (!_restart)
                    _restart = Object.FindObjectOfType<Restart>();
                return _restart;
            }
        }
    }
}
