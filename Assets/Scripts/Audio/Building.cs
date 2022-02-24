using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public class Building
    {
        private readonly string DestructionEvent = "Building_Destroy";

        public void PlayDestruction(GameObject gameObject)
        {
            AkSoundEngine.PostEvent(DestructionEvent, gameObject);
        }
    }
}