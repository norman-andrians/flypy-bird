using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public AudioSource audioSource;

    [Header("UI")]
    public Image volumeImg;
    public Image vibrateImg;

    public Sprite volumeSpriteOn;
    public Sprite volumeSpriteOff;
    public Sprite vibrateSpriteOn;
    public Sprite vibrateSpriteOff;

    public OptionsData data;

    [HideInInspector] public bool isVolume = true;
    [HideInInspector] public bool isVibrate = true;

    private void Start()
    {
        switch (isVolume)
        {
            case true: volumeImg.sprite = volumeSpriteOn; audioSource.volume = 1; break;
            case false: volumeImg.sprite = volumeSpriteOff; audioSource.volume = 0; break;
        }
        switch (isVibrate)
        {
            case true: vibrateImg.sprite = vibrateSpriteOn; break;
            case false: vibrateImg.sprite = vibrateSpriteOff; break;
        }
    }

    public void SetVolume()
    {
        switch (isVolume)
        {
            case true: isVolume = false; volumeImg.sprite = volumeSpriteOff; audioSource.volume = 0; break;
            case false: isVolume = true; volumeImg.sprite = volumeSpriteOn; audioSource.volume = 1; break;
        }
    }

    public void SetVibrate()
    {
        switch (isVibrate)
        {
            case true: isVibrate = false; vibrateImg.sprite = vibrateSpriteOff; break;
            case false : isVibrate = true; vibrateImg.sprite = vibrateSpriteOn; break;
        }
    }

    public void SaveData() { data.OptionSave(isVolume, isVibrate); }
}
