using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private AudioSource effectAudioSource;
    private AudioSource backgroundAudioSource;
    public AudioClip[] Effect = new AudioClip[21];
    public AudioClip[] BackGroundSound = new AudioClip[8];
    private readonly WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
    // Start is called before the first frame update
    void Start()
    {
        effectAudioSource = GetComponent<AudioSource>();
        backgroundAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        
    }
    public void PlayEffectSound(string action)
    {
        if (effectAudioSource.isPlaying) effectAudioSource.Stop();
        switch (action)
        {
            case "0":
                effectAudioSource.clip = Effect[0];
                break;
            case "1":
                effectAudioSource.clip = Effect[1];
                break;
            case "2":
                effectAudioSource.clip = Effect[2];
                break;
            case "3":
                effectAudioSource.clip = Effect[3];
                break;
            case "4":
                effectAudioSource.clip = Effect[4];
                break;
            case "5":
                effectAudioSource.clip = Effect[5];
                break;
            case "6":
                effectAudioSource.clip = Effect[6];
                break;
            case "7":
                effectAudioSource.clip = Effect[7];
                break;
            case "8":
                effectAudioSource.clip = Effect[8];
                break;
            case "9":
                effectAudioSource.clip = Effect[9];
                break;
            case "10":
                effectAudioSource.clip = Effect[10];
                break;
            case "11":
                effectAudioSource.clip = Effect[11];
                break;
            case "12":
                effectAudioSource.clip = Effect[12];
                break;
            case "13":
                effectAudioSource.clip = Effect[13];
                break;
            case "14":
                effectAudioSource.clip = Effect[14];
                break;
            case "15":
                effectAudioSource.clip = Effect[15];
                break;
            case "16":
                effectAudioSource.clip = Effect[16];
                break;
            case "17":
                effectAudioSource.clip = Effect[17];
                break;
            case "18":
                effectAudioSource.clip = Effect[18];
                break;
            case "19":
                effectAudioSource.clip = Effect[19];
                break;
            case "20":
                effectAudioSource.clip = Effect[20];
                break;
        }
        effectAudioSource.Play();        
    }
    public void PlayBackGroundSound(string musicNumber)
    {
        if (backgroundAudioSource.isPlaying) effectAudioSource.Stop();
        switch (musicNumber)
        {
            case "1":
                backgroundAudioSource.clip = BackGroundSound[0];
                break;
            case "2":
                backgroundAudioSource.clip = BackGroundSound[1];
                break;
            case "3":
                backgroundAudioSource.clip = BackGroundSound[2];
                break;
            case "4":
                backgroundAudioSource.clip = BackGroundSound[3];
                break;
            case "5":
                backgroundAudioSource.clip = BackGroundSound[4];
                break;
            case "6":
                backgroundAudioSource.clip = BackGroundSound[5];
                break;
            case "7":
                backgroundAudioSource.clip = BackGroundSound[6];
                break;
            case "8":
                backgroundAudioSource.clip = BackGroundSound[7];
                break;
        }
        backgroundAudioSource.Play();
    }
    public void StopBackGroundSound() => backgroundAudioSource.Stop();
    public void StopEffactSound() => effectAudioSource.Stop();
    public void SetBackGroundSound(float value) => backgroundAudioSource.volume = value;
    public void DecreaseBackGroundSound(float min = 0.1f)
    {
        IEnumerator DecreaseBackGround()
        {
            while (backgroundAudioSource.volume > min)
            {
                backgroundAudioSource.volume -= 0.005f;
                yield return waitForEndOfFrame;
            }
        }
        StartCoroutine(DecreaseBackGround()); 
    }

}
