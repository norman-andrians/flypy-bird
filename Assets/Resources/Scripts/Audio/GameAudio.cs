using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour
{
    public AudioClip buttonClick; // button click sound from www.zapsplat.com
    public AudioClip getPoint;
    public AudioClip coins;
    public AudioClip impact;

    private AudioSource audioSource;

    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void buttonSound () { audioSource.PlayOneShot(buttonClick); }
    public void pointSound() { audioSource.PlayOneShot(getPoint); }
    public void coinsSound () { audioSource.PlayOneShot(coins); }
    public void impactSound() { audioSource.PlayOneShot(impact); }
}
