using Zenject;

namespace Character
{
    public class SoulCounter
    {
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
        }
    }
}