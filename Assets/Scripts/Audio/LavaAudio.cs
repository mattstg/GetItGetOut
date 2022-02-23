
using System.Collections;
using UnityEngine;
namespace Audio
{

    public class LavaAudio : MonoBehaviour
    {
        private global::Lava lava;

        private global::Player listener;

        private Collider trigger;

        private GameObject eventEmitter;

        private readonly string PlayEvent = "Lava_Play";

        private bool inArea;

        private void Start()
        {
            lava = LavaManager.Instance.lava;
            trigger = lava.GetComponent<Collider>();
            listener = PlayerManager.Instance.player;
            eventEmitter = lava.soundEmitter;
            
            PlayLava();
        }


        private void PlayLava()
        {
            AkSoundEngine.PostEvent(PlayEvent, eventEmitter.gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                inArea = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                inArea = false;
            }
        }


        private void Update()
        {

            if (!inArea)
                eventEmitter.transform.position = trigger.ClosestPointOnBounds(listener.transform.position);
            else
                eventEmitter.transform.position = listener.transform.position; 
        }

    }
}
