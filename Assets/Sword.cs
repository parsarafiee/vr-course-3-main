using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    public void SwordSoundOn()
    {
        audioSource.Play();

    }
    public void SwordSoundOff()
    {
        audioSource.Pause();
    }
}
