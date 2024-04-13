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
        private Vector2 _mouseInput;
        private bool isRunning;
        private PauseMenu _pauseMenu;
        private TargetPointer _targetPointer;
        private AudioPlayer _audioPlayer;


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
        }

        private void Start()
        {
            Game.UnPause();
        }

        void Update()
        {
            _axis = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            _mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            if (CharacterInput)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                    isRunning = true;
                else if (Input.GetKeyUp(KeyCode.LeftShift))
                    isRunning = false;

                _action.Move(_characterData.Transform, _characterData.Rb, _axis, isRunning ? _characterData.RunSpeed : _characterData.Speed);
                _action.MoveCamera(_characterData.Transform, _characterData.PlayerCamera, _mouseInput, _characterData.Sensitivity, _characterData.LookXLimit);

                if (Input.GetKeyDown(KeyCode.Space))
                    if (Physics.CheckSphere(_characterData.FeetTransform.position, 0.1f, _characterData.FloorMask))
                        _action.Jump(_characterData.Rb, _characterData.JumpForce);

                RaycastHit hit;
                if (Physics.Raycast(_characterData.PlayerCamera.position, _characterData.PlayerCamera.forward, out hit, _pickUpData.DistanceToPickUp, _pickUpData.SoulLayerMask))
                {
                    _characterData.Aim.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                        _action.PickUp(hit.collider.gameObject, _soulCounter, _targetPointer, _audioPlayer);
                }
                else
                {
                    _characterData.Aim.SetActive(false);
                }
            }
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Game.Pause();
                _pauseMenu.gameObject.SetActive(true);
            }
        }
    }
}