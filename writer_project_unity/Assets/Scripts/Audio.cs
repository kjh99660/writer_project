using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip SlowSpeedLight;
    public AudioClip[] CrashLand = new AudioClip[4];
    public AudioClip[] CrashThrough = new AudioClip[3];
    public AudioClip[] AirLoop = new AudioClip[2];
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlaySound(string action)
    {
        /*
        switch (action)
        {
            case "Slow":
                audioSource.clip = SlowSpeedLight;
                break;
            case "Land":
                audioSource.clip = CrashLand[Random.Range(0, 3)];
                break;
            case "Through":
                audioSource.clip = CrashThrough[Random.Range(0, 2)];
                break;
            case "Air":
                audioSource.clip = AirLoop[Random.Range(0, 1)];
                break;

        }
        if (!audioSource.isPlaying) audioSource.Play();
        */
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
