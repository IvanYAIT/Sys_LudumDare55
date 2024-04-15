using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public class AudioPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private List<AudioClip> clips;

        private int index = 0;

        public void Play()
        {
            audioSource.clip = clips[index];
            audioSource.Play();
            index = Random.Range(0, clips.Count);
        }
    }
}