using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public class Voice
    {
        private readonly string IntroEvent = "Play_Intro";

        public void PlayIntro(GameObject gameObject)
        {
            AkSoundEngine.PostEvent(IntroEvent, gameObject);
        }
    }
}
