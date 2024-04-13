using UnityEngine;

namespace Audio
{
    public class AudioPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;

        public void Play() =>
            audioSource.Play();
    }
}