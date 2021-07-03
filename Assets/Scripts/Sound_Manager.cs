using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manager : MonoBehaviour
{
    static AudioSource audio_src;
    static AudioClip default_clip;
    // Start is called before the first frame update
    void Start()
    {
        audio_src = GetComponent<AudioSource>();
        default_clip = Resources.Load<AudioClip>("Block_Moment");
    }

    public static void playSound(string name) {
       audio_src.PlayOneShot(Resources.Load<AudioClip>(name));
    }
}
