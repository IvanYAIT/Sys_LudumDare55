using Zenject;

namespace Character
{
    public class SoulCounter
    {
        public static bool isEnoghSouls;

        private int _soul;
        private SoulView _view;

        [Inject]
        public SoulCounter(SoulView view)
        {
            _view = view;
            _soul = 0;
            _view.SetSoul(_soul);
        }

        public void Add()
        {
            _soul++;
            _view.SetSoul(_soul);
            if(_soul >= 5)
            {
                TargetPointer.isSoulsCollected = true;
                isEnoghSouls = true;
            }
        }
    }
}