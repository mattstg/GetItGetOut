using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioIntro : MonoBehaviour
{
    Audio.Voice audio = new Audio.Voice();
    private AkAudioListener listener;

    private void Awake()
    {
        listener = FindObjectOfType<AkAudioListener>();
    }

    void Start()
    {
        audio.PlayIntro(listener.gameObject);
    }
}
