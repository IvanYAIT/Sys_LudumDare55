using Core;
using UnityEngine;
using UnityEngine.SceneManagement;
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
            leaveBtn.onClick.AddListener(Leave);
            gameObject.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Continue();
            }
        }

        private void OnDestroy()
        {
            continueBtn.onClick.RemoveListener(Continue);
            settingsBtn.onClick.RemoveListener(ShowSettings);
            settingsBackBtn.onClick.RemoveListener(CloseSettings);
            leaveBtn.onClick.RemoveListener(Leave);
        }

        private void Continue()
        {
            gameObject.SetActive(false);
            CloseSettings();
            Game.UnPause();
        }

        private void ShowSettings() =>
            settings.SetActive(true);

        private void CloseSettings() =>
            settings.SetActive(false);

        public void Leave()=>
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
}