using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button playBtn;
        [SerializeField] private Button settingsBtn;
        [SerializeField] private Button settingsBackBtn;

        [SerializeField] private GameObject settings;

        void Start()
        {
            playBtn.onClick.AddListener(Play);
            settingsBtn.onClick.AddListener(ShowSettings);
            settingsBackBtn.onClick.AddListener(CloseSettings);
        }

        private void OnDestroy()
        {
            playBtn.onClick.RemoveListener(Play);
            settingsBtn.onClick.RemoveListener(ShowSettings);
            settingsBackBtn.onClick.RemoveListener(CloseSettings);
        }

        private void Play()=>
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        private void ShowSettings() =>
            settings.SetActive(true);

        private void CloseSettings() =>
            settings.SetActive(false);
    }
}