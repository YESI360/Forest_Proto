using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestCapsule : MonoBehaviour
{
    public GameObject capsule;
    public AudioSource audioSource;///////amb forest
    public float maxVolume;
    public float musicFadeSpeed;

    //public bool IsAnimating;
    void Start()
    {
        audioSource.Play();
        audioSource.volume = 0;
    }

    public void agrandarCa()
    {
        capsule.transform.localScale = new Vector3(3, 3, 3);
    }

    public void achicarCa()
    {
        capsule.transform.localScale = new Vector3(.5f, .5f, .5f);
    }

    public void PlayFirstBreathAnimation()
    {
        StartCoroutine(AnimateVolume());
    }

    private IEnumerator AnimateVolume()
    {
        while (audioSource.volume < maxVolume)
        {
            audioSource.volume = Mathf.Lerp(audioSource.volume, maxVolume, musicFadeSpeed * Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }
    }

}
