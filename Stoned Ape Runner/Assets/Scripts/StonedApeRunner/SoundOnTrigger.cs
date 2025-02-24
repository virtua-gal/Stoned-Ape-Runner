using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnTrigger : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    public float waitTime = 0;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Invoke("PlaySound", waitTime);
        }
    }

    void PlaySound()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
