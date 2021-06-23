using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyWinds : MonoBehaviour
{

    public WindZone wind;

    public float Maxturbulence;
    public float Minturbulence;

    [Range(0, 5)] public float lerpSpeed = 1;

    public AudioSource audioSource;////////winds
    public float musicFadeSpeed;
    public float maxVolume;
    public float volume = 1;

    private void Start()
    {
        wind.windTurbulence = 0;
        audioSource.volume = 0.8f;
    }

    public void TurbulenceUp()
    {
        wind.windTurbulence = Mathf.Lerp(wind.windTurbulence, Maxturbulence, Time.deltaTime * lerpSpeed);
    }

    public void TurbulenceDown()
    {
        wind.windTurbulence = Mathf.Lerp(wind.windTurbulence, Minturbulence, Time.deltaTime * lerpSpeed);
    }

    public void soundWind()
    {
        audioSource.PlayOneShot(audioSource.clip, volume);
        //audioSource.volume = Mathf.Lerp(audioSource.volume, maxVolume, musicFadeSpeed * Time.deltaTime);
    }




}
