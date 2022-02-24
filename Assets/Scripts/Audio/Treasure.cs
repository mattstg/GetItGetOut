using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public class Treasure
    {
        private readonly string AmbiantEvent = "Treasure_Play";
        private readonly string StopAllEvent = "Stop_Audio";
        private readonly string CollisionEvent = "Treasure_Collision";
        
        public void PlayTreasureAmbiant(GameObject gameObject)
        {
            AkSoundEngine.PostEvent(AmbiantEvent, gameObject);
        }

        public void StopAllAudio(GameObject gameObject)
        {
            AkSoundEngine.PostEvent(StopAllEvent, gameObject);
        }

        public void PlayCollision(GameObject gameObject)
        {
            AkSoundEngine.PostEvent(CollisionEvent, gameObject);
        }
    }
}
