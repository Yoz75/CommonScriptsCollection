using System.Collections.Generic;
using UnityEngine;

namespace CSC
{
    public class MusicPlayer : MonoBehaviour
    {
        [Tooltip("Last clips limitation. E.g if this value is 2, last 2 clips can't be selected as next clips." +
            " You cant set this value more or equals of your clips count")]
        [SerializeField] private int LastClipsLimit;
        [SerializeField] private List<AudioClip> MusicClips;
        [SerializeField] private AudioSource MusicSource;

        private Queue<AudioClip> BannedClips = new();

        [Range(0f, 1f)]
        [SerializeField] private float Volume;

        private void Start()
        {
            if(LastClipsLimit >= MusicClips.Count)
            {
                Debug.LogError($"Last clips limit can't be more or equals music clips count!" +
                    $" Limit: {LastClipsLimit}. Clips count: {MusicClips.Count}");
            }

            MusicSource.volume = Volume;
            ChangeMusic();
        }

        private void Update()
        {
            if(!MusicSource.isPlaying)
            {
                ChangeMusic();
            }
        }

        private void ChangeMusic()
        {
            AudioClip nextClip;

            do
            {
                nextClip = MusicClips[Random.Range(0, MusicClips.Count)];
            } while(MusicClips.Count > 1 && BannedClips.Contains(nextClip));


            MusicSource.clip = nextClip;
            MusicSource.Play();

            BannedClips.Enqueue(nextClip);

            if(BannedClips.Count > LastClipsLimit)
            {
                BannedClips.Dequeue();
            }
        }
    }
}