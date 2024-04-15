using Core;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    private const string DIFFICULTY = "Difficulty";

    [SerializeField] private GameObject endScreen;
    [SerializeField] private GameObject blackScreen;
    [SerializeField] private LayerMask playerLayersMask;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private int timerMinuts;
    [SerializeField] private TextMeshProUGUI timerText;

    private int _playerLayer;
    private float _timer;

    void Start()
    {
        timerMinuts = PlayerPrefs.GetInt(DIFFICULTY);
        _playerLayer = (int)Mathf.Log(playerLayersMask.value, 2);
        _timer = timerMinuts * 60;
    }

    void Update()
    {
        if (blackScreen.activeInHierarchy)
        {
            Color color = blackScreen.GetComponent<Image>().color;
            color.a += Time.deltaTime * 0.7f;
            blackScreen.GetComponent<Image>().color = color;
        }
            
        if (endScreen.activeInHierarchy)
        {
            if (Input.anyKeyDown)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        if(_timer > 0)
            _timer -= Time.deltaTime;

        int hours = Mathf.FloorToInt(_timer / 3600f);
        int minutes = Mathf.FloorToInt((_timer - hours * 3600f) / 60f);
        int seconds = Mathf.FloorToInt((_timer - hours * 3600f) - (minutes * 60f));

        timerText.text = $"{minutes:D2}:{seconds:D2}";
        if (_timer <= 0)
        {
            timerText.text = "00:00";
            Game.Pause();
            loseScreen.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _playerLayer)
        {
            StartCoroutine(BlackScreen());
        }
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(timerMinuts * 60);
    }

    private IEnumerator BlackScreen()
    {
        blackScreen.SetActive(true);
        yield return new WaitForSeconds(3);
        Game.Pause();
        endScreen.SetActive(true);
        audioSource.Play();
    }
}
