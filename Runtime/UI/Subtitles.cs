using System;
using UnityEngine;

namespace CSC.UI
{
    [Serializable]
    public struct Subtitles : IPropsHolder<SubtitlesProps>
    {
        [SerializeField] private string Text_;
        [SerializeField] private SubtitlesProps Props;
        public string Text
        {
            get
            {
                return Text_;
            }
        }

        public Props GetRawProps() => (Props) Props.Clone();
        public SubtitlesProps? GetProps()
        {
            if(Props == null) return null;

            var props = Props.Clone();
            return props == null ? null : (SubtitlesProps)props;
        }

        public Subtitles(string text, SubtitlesProps props = null)
        {
            Text_ = text;
            Props = props;
        }

        /// <summary>
        /// Play subtitles, using <see cref="SubtitlesPlayer.DefaultPlayer"/>
        /// </summary>
        public void Play()
        {
            SubtitlesPlayer.DefaultPlayer.Play(this);
        }
    }
}