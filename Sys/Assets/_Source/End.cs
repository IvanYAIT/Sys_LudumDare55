using Core;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    [SerializeField] private GameObject endScreen;
    [SerializeField] private LayerMask playerLayersMask;

    private int _playerLayer;

    void Start()
    {
        _playerLayer = (int)Mathf.Log(playerLayersMask.value, 2);
    }

    void Update()
    {
        if (endScreen.activeInHierarchy)
        {
            if (Input.anyKeyDown)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject);
        if (other.gameObject.layer == _playerLayer)
        {
            endScreen.SetActive(true);
            Game.Pause();
        }
    }
}
