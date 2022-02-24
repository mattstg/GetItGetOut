using UnityEngine;

namespace Audio
{
    public class Player
    {

        //Event
        private readonly string WindStartEvent = "Wind_Play";

        //Parameters
        private readonly string SpeedSync = "Player_Speed";
        private readonly float SPEED_THRESHOLD = 300.0f;
        private float Speed => PlayerManager.Instance.player.rb.velocity.magnitude;
        private float Speed100 => Speed * SPEED_THRESHOLD / 100;

        public void PlayWind(GameObject gameObject)
        {
            AkSoundEngine.PostEvent(WindStartEvent, gameObject);
        }

        public void Refresh(GameObject gameObject)
        {
            //TO TEST

            if (Speed > SPEED_THRESHOLD)
                AkSoundEngine.SetRTPCValue(SpeedSync, 100, gameObject);
            else
            {

                AkSoundEngine.SetRTPCValue(SpeedSync, Speed100, gameObject);
            }
        }
    }
}