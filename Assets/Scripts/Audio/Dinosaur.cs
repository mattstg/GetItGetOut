using UnityEngine;

namespace Audio
{
    public class Dinosaur
    {
        private readonly string DragonScream = "Dragon_Scream";

        public void PlayScream(GameObject gameObject)
        {
            AkSoundEngine.PostEvent(DragonScream, gameObject);
        }
    }
}