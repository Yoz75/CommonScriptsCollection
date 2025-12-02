using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;

namespace CSC.UI
{
    /// <summary>
    /// Plays <see cref="Subtitles"/> in queue
    /// </summary>
    public class SubtitlesPlayer : MonoBehaviour
    {
        [Tooltip("Is this the default subtitles player?")]
        [SerializeField] private bool IsDefault;

        [SerializeField] private SubtitlesProps DefaultSubtitlesProps;
        [SerializeField] private TMP_Text SubtitlesText;

        private Queue<Subtitles> PlayQueue = new();

        private bool IsCoroutineRunning;

        /// <summary>
        /// Default subtitles player. <see cref="Subtitles.Play"/> uses this player.
        /// </summary>
        public static SubtitlesPlayer DefaultPlayer
        {
            get; private set;
        }

        public void Play(Subtitles subtitles)
        {
            PlayQueue.Enqueue(subtitles);
            if(!IsCoroutineRunning) StartCoroutine(PlayCoroutine());
        }

        private void Start()
        {
            SubtitlesText.text = "";
            if(IsDefault) DefaultPlayer = this;

            StartCoroutine(PlayCoroutine());
        }

        private IEnumerator PlayCoroutine()
        {
            IsCoroutineRunning = true;

            while(PlayQueue.Count > 0)
            {
                Subtitles subtitles = PlayQueue.Dequeue();

                SubtitlesProps settings;

                if(subtitles.GetProps() is null) settings = DefaultSubtitlesProps;
                else settings = subtitles.GetProps();

                var waitTime = 1 / settings.LettersPerSecond;

                SubtitlesText.color = settings.Color;

                for(int i = 0; i < subtitles.Text.Length; i++)
                {
                    SubtitlesText.text += subtitles.Text[i];
                    yield return new WaitForSeconds(waitTime);
                }

                yield return new WaitForSeconds(settings.ShowTime);
                SubtitlesText.text = "";
            }

            IsCoroutineRunning = false;
        }
    }
}