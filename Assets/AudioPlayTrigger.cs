using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayTrigger : MonoBehaviour
{
    public AudioSource musicAudio;
    private AudioClip clip;

    private bool isTrigger = false;

    private void Start()
    {
        clip = musicAudio.clip;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(isTrigger == false)
            {
                isTrigger = true;
                musicAudio.PlayOneShot(clip);
            }
        }
    }
}
