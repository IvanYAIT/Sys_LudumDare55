using Core;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    [SerializeField] private GameObject endScreen;
    [SerializeField] private GameObject blackScreen;
    [SerializeField] private LayerMask playerLayersMask;
    [SerializeField] private AudioSource audioSource;

    private int _playerLayer;

    void Start()
    {
        _playerLayer = (int)Mathf.Log(playerLayersMask.value, 2);
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _playerLayer)
        {
            StartCoroutine(BlackScreen());
        }
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
