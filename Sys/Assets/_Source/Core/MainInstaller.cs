using Audio;
using Character;
using UI;
using UnityEngine;
using Zenject;

namespace Core
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private CharacterData characterData;
        [SerializeField] private InputListener inputListener;
        [SerializeField] private PickUpData pickUpData;
        [SerializeField] private SoulView soulView;
        [SerializeField] private PauseMenu pauseMenu;
        [SerializeField] private TargetPointer targetPointer;
        [SerializeField] private AudioPlayer audioPlayer;

        public override void InstallBindings()
        {
            Container.Bind<CharacterData>().FromInstance(characterData).AsSingle().NonLazy();
            Container.Bind<PickUpData>().FromInstance(pickUpData).AsSingle().NonLazy();
            Container.Bind<SoulView>().FromInstance(soulView).AsSingle().NonLazy();
            Container.Bind<PauseMenu>().FromInstance(pauseMenu).AsSingle().NonLazy();
            Container.Bind<TargetPointer>().FromInstance(targetPointer).AsSingle().NonLazy();
            Container.Bind<AudioPlayer>().FromInstance(audioPlayer).AsSingle().NonLazy();
            Container.Bind<CharacterAction>().AsSingle().NonLazy();
            Container.Bind<SoulCounter>().AsSingle().NonLazy();
            Container.Bind<InputListener>().FromInstance(inputListener).AsSingle().NonLazy();
        }
    }
}