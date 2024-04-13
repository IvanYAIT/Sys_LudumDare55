using Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private Button continueBtn;
        [SerializeField] private Button settingsBtn;
        [SerializeField] private Button settingsBackBtn;
        [SerializeField] private Button leaveBtn;

        [SerializeField] private GameObject settings;

        void Start()
        {
            continueBtn.onClick.AddListener(Continue);
            settingsBtn.onClick.AddListener(ShowSettings);
            settingsBackBtn.onClick.AddListener(CloseSettings);
        }

        private void Continue()
        {
            gameObject.SetActive(false);
            Game.UnPause();
        }

        private void ShowSettings() =>
            settings.SetActive(true);

        private void CloseSettings() =>
            settings.SetActive(false);

    }
}