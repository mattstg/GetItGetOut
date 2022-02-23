using UnityEngine;

namespace Audio
{
    public class GrapplingGun : MonoBehaviour
    {
        private readonly string PlayShootEvent = "Grappling_Fire_Play";
        private readonly string StopShootEvent = "Grappling_Fire_Stop";
        private readonly string PlayReelInEvent = "Grappling_Reel_In_Play";
        private readonly string StopReelInEvent = "Grappling_Reel_In_Stop";
        private readonly string PlayRechargeEvent = "Grappling_Recharge";
        private readonly string StopAudioEvent = "Stop_Audio";


        public void PlayShoot(GameObject gameObject)
        {
            AkSoundEngine.PostEvent(PlayShootEvent, gameObject);
        }

        public void StopShoot(GameObject gameObject)
        {
            AkSoundEngine.PostEvent(StopShootEvent, gameObject);
        }

        public void PlayReelIn(GameObject gameObject)
        {
            AkSoundEngine.PostEvent(PlayReelInEvent, gameObject);
        }

        public void StopReelIn(GameObject gameObject)
        {
            AkSoundEngine.PostEvent(StopReelInEvent, gameObject);
        }

        public void StopAllAudio(GameObject gameObject)
        {
            AkSoundEngine.PostEvent(StopAudioEvent, gameObject);
        }

        public void PlayRecharge(GameObject gameObject)
        {
            AkSoundEngine.PostEvent(PlayRechargeEvent, gameObject);
        }
    }
}