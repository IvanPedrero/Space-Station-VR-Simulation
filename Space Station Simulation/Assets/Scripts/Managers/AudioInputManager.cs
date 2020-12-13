using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInputManager : MonoBehaviour {

    AudioSource audio;
    AudioDistortionFilter distortionFilter;

    public float distortionChangeTimer = 5f;

    // Use this for initialization
    void Start () {
        //Fetch components.
        audio = GetComponent<AudioSource>();
        distortionFilter = GetComponent<AudioDistortionFilter>();

        //Start audio.
        audio.clip = Microphone.Start(null, true, 1, 22050);
        audio.loop = true;
        while (!(Microphone.GetPosition(null) > 0)) {}
        audio.Play();

        //Start the distortion audio right away and every 4 seconds.
        InvokeRepeating("SetDistortion", 0.0f, 4f);
    }

    void SetDistortion()
    {
        distortionFilter.distortionLevel = Random.Range(0.1f, 0.8f);

    }
}
