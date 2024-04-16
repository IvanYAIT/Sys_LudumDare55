using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        private const string DIFFICULTY = "Difficulty";

        [SerializeField] private Button playBtn;
        [SerializeField] private Button settingsBtn;
        [SerializeField] private Button settingsBackBtn;
        [SerializeField] private Scrollbar difficultyBar;

        [SerializeField] private GameObject settings;
        [SerializeField] private GameObject tutorial;

        void Start()
        {
            playBtn.onClick.AddListener(Play);
            settingsBtn.onClick.AddListener(ShowSettings);
            settingsBackBtn.onClick.AddListener(CloseSettings);
            difficultyBar.onValueChanged.AddListener(ChangeDifficulty);
            PlayerPrefs.SetInt(DIFFICULTY, 10);
        }

        private void Update()
        {
            if (tutorial.activeInHierarchy)
            {
                if(Input.anyKeyDown)
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

        private void OnDestroy()
        {
            playBtn.onClick.RemoveListener(Play);
            settingsBtn.onClick.RemoveListener(ShowSettings);
            settingsBackBtn.onClick.RemoveListener(CloseSettings);
            difficultyBar.onValueChanged.RemoveListener(ChangeDifficulty);
        }

        private void ChangeDifficulty(float value)
        {
            if (value == 0)
                PlayerPrefs.SetInt(DIFFICULTY, 10);
            else if(value >0 && value < 1)
                PlayerPrefs.SetInt(DIFFICULTY, 6);
            else if (value == 1)
                PlayerPrefs.SetInt(DIFFICULTY, 3);
        }

        private void Play()=>
            tutorial.SetActive(true);

        private void ShowSettings() =>
            settings.SetActive(true);

        private void CloseSettings() =>
            settings.SetActive(false);
    }
}