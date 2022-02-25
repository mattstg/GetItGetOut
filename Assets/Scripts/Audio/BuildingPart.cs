using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public class BuildingPart
    {
        private readonly string CollisionEvent = "BuildingPart_Collision";

        public void PlayCollision(GameObject gameObject)
        {
            AkSoundEngine.PostEvent(CollisionEvent, gameObject);
        }
    }
}