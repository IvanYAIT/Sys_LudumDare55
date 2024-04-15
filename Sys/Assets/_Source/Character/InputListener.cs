using Audio;
using Core;
using UI;
using UnityEngine;
using Zenject;

namespace Character
{
    public class InputListener : MonoBehaviour
    {
        public static bool CharacterInput;
        
        private CharacterData _characterData;
        private PickUpData _pickUpData;
        private CharacterAction _action;
        private SoulCounter _soulCounter;
        private Vector3 _axis;
        private bool isRunning;
        private PauseMenu _pauseMenu;
        private TargetPointer _targetPointer;
        private AudioPlayer _audioPlayer;
        private int _soulLayer;
        private int _speedSoulLayer;

        [Inject]
        public void Construct(CharacterData characterData, 
            CharacterAction characterAction, 
            PickUpData pickUpData, 
            SoulCounter soulCounter, 
            PauseMenu pauseMenu, 
            TargetPointer targetPointer,
            AudioPlayer audioPlayer)
        {
            _characterData = characterData;
            _soulCounter = soulCounter;
            _pickUpData = pickUpData;
            _action = characterAction;
            _pauseMenu = pauseMenu;
            _targetPointer = targetPointer;
            _audioPlayer = audioPlayer;
            _soulLayer = (int)Mathf.Log(_pickUpData.SoulLayerMask.value, 2);
            _speedSoulLayer = (int)Mathf.Log(_pickUpData.SpeedSoulLayerMask.value, 2);
        }

        private void Start()
        {
            Game.UnPause();
        }

        void Update()
        {
            _axis = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

            if (CharacterInput)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                    isRunning = true;
                else if (Input.GetKeyUp(KeyCode.LeftShift))
                    isRunning = false;

                _action.Move(_characterData.Rb, _characterData.Orientation, _axis, isRunning ? _characterData.RunSpeed : _characterData.Speed, isRunning);
                _action.MoveCamera(_characterData.Transform,_characterData.PlayerBodyTransform, _characterData.PlayerCamera,_characterData.Orientation, _axis, _characterData.Sensitivity);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (Physics.CheckSphere(_characterData.FeetTransform.position, 0.1f, _characterData.FloorMask))
                        _action.Jump(_characterData.Rb, _characterData.JumpForce);
                }
            }
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Game.Pause();
                _pauseMenu.gameObject.SetActive(true);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if(other.gameObject.layer == _soulLayer)
            {
                _characterData.Hint.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _action.PickUp(other.gameObject, _soulCounter, _targetPointer, _audioPlayer);
                    _characterData.Hint.SetActive(false);
                }
            }
            if (other.gameObject.layer == _speedSoulLayer)
            {
                _characterData.Hint.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _characterData.SpeedUp();
                    _audioPlayer.Play();
                    other.gameObject.SetActive(false);
                    _characterData.Hint.SetActive(false);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.gameObject.layer == _soulLayer)
                _characterData.Hint.SetActive(false);
            if (other.gameObject.layer == _speedSoulLayer)
                _characterData.Hint.SetActive(false);
        }
    }
}