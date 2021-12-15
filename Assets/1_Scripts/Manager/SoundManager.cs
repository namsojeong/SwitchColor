using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("SFX")]
    [SerializeField]
    AudioSource sfxSource;
    [SerializeField]
    AudioClip[] sfxSound;

    [Header("Å¬¸¯À½")]
    [SerializeField]
    AudioSource clickSource;
    [SerializeField]
    AudioClip[] clickSound;

    [Header("BGM")]
    [SerializeField]
    AudioSource BGMSource;
    [SerializeField]
    AudioClip[] bgmSound;

    void Awake()
    {
        Instance = this;
    }

    public void ClickSound(int num)
    {
        SoundOn("CLICK", num);
    }
    public void SoundOn(string source, int num)
    {
        if(source=="SFX")
        {
            sfxSource.clip = sfxSound[num];
            sfxSource.Play();
        }
        else if(source=="CLICK")
        {
            clickSource.clip = clickSound[num];
            clickSource.Play();
        }
        else if(source=="BGM")
        {
            BGMSource.clip = bgmSound[num];
            BGMSource.Play();
        }
    }


}
