using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Audio
{
    public class UI
    {

        private readonly string ButtonHoverEvent= "Button_Hover";
        private readonly string ButtonDefaultClickEvent = "Button_Press";

        public void PlayHover(GameObject gameObjct)
        {
            AkSoundEngine.PostEvent(ButtonHoverEvent, gameObjct);
        }

        public void PlayDefaultClick(GameObject gameObject)
        {
            AkSoundEngine.PostEvent(ButtonDefaultClickEvent, gameObject);
        }
    }
}