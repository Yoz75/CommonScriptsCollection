using UnityEngine;

namespace CSC.UI
{
    [CreateAssetMenu(menuName = "CSC/Subtitles Settings")]
    public class SubtitlesProps : Props
    {
        /// <summary>
        /// Text writing speed
        /// </summary>
        public float LettersPerSecond;

        /// <summary>
        /// Text color
        /// </summary>
        public Color Color;

        /// <summary>
        /// Subtitles appearing time
        /// </summary>
        public float ShowTime;
    }
}
