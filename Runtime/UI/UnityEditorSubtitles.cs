using System.Collections.Generic;
using UnityEngine;

namespace CSC.UI
{
    /// <summary>
    /// Allows create subtitles from the unity editor
    /// </summary>
    public class UnityEditorSubtitles : MonoBehaviour
    {
        /// <summary>
        /// List of subtitles
        /// </summary>
        [SerializeField] List<Subtitles> Subtitles;

        /// <summary>
        /// Play all subtitles
        /// </summary>
        public void Play()
        {
            foreach(Subtitles subtitles in Subtitles)
            {
                subtitles.Play();
            }
        }
    }
}