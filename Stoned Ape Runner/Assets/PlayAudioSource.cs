using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioSource : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject camera;
    public GameObject button;
    public GameObject globalVolume;
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        globalVolume.SetActive(true);
        camera.SetActive(true);
        audioSource.Play();
        text.SetActive(true);
        button.SetActive(true);
    }

}
