using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseSphere : MonoBehaviour
{
    public GameObject sphere;
    public AudioSource audioSource;
    public float volume;
    void Start()
    {
        
    }

    public void agrandarS()
    {
        sphere.transform.localScale = new Vector3(3, 3, 3);
        audioSource.PlayOneShot(audioSource.clip, volume);
    }

    public void achicarS()
    {
        sphere.transform.localScale = new Vector3(.5f, .5f, .5f);
        audioSource.Stop();
    }


}
