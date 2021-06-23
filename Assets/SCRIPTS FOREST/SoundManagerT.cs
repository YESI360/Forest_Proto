using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerT : MonoBehaviour
{
    public AudioClip audioClipInstruccion02;//X2                                        
    public AudioClip audioClipInstruccion03;//X3++
    public AudioClip audioClipInstruccion04;// ABDOMINAL?
    public AudioClip audioClipInstruccion05;// ABDOMINAL2
    //public float volume = 0.5f;
    public AudioSource audioSource; //para no usar getComponent xq tenfo 2 audios...

    public void Start() //COMO HACER QUE EL CLIP DEL AWAKE NO SEA PISADO POR LOS CLIPS??
    {
        //if (AudioSource audioSource) //PLAY ON AWAKE ESTA EN PLAY NO! HABILITAR PLAY DE LOS CLIPS
    }

    public void PlayInstruccion02()
    {
        PlayAudioClip(audioClipInstruccion02);
    }

    public void PlayInstruccion03()
    {
        PlayAudioClip(audioClipInstruccion03);
    }

    public void PlayInstruccion04()
    {
        PlayAudioClip(audioClipInstruccion04);
    }

    public void PlayInstruccion05()
    {
        PlayAudioClip(audioClipInstruccion05);
    }

    private void PlayAudioClip(AudioClip audioclip)//instruccion 00
    {
        audioSource.clip = audioclip;
        audioSource.Play();
    }

}
