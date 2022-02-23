
using UnityEngine;
namespace Audio
{

    public class Lava
    {
        global::Lava lava;
  
        private readonly float UpdateInterval = 0.05f;

        private readonly string PlayEvent = "Lava_Play";

        Lava()
        {
            lava = LavaManager.Instance.lava;
        }


        private void PlayLava()
        {
            AkSoundEngine.PostEvent(PlayEvent, lava.gameObject);
        }

        

      


    }
}
