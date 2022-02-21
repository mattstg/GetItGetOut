using System.Collections;
using System.Collections.Generic;
using AK.Wwise;
using UnityEngine;

namespace Audio
{

    public class Bullet
    {
        private readonly string Impact_Event = "Grappling_Impact";
        
        

        public void PlayGrapplingImpact(GameObject gameObject)
        {
            AkSoundEngine.PostEvent(Impact_Event, gameObject);
        }

    }
}
