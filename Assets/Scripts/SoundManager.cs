using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip jumpSound, landSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("jump");
        landSound = Resources.Load<AudioClip>("land");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip, float volume)
    {
        switch (clip)
        {
            case "jump":
                audioSrc.PlayOneShot(jumpSound, volume);
                //Debug.Log("jump");
                break;
            case "land":
                audioSrc.PlayOneShot(landSound, volume);
                //Debug.Log("land");
                break;
        }
                
    }
}
