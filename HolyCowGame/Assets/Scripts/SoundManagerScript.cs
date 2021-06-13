using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip demonCowSpawn, demonCowDeath, holyCowCollected, holyCowHit, ropeHit;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        demonCowSpawn = Resources.Load<AudioClip>("demonCowSpawn");
        demonCowDeath = Resources.Load<AudioClip>("demonCowDeath");
        holyCowCollected = Resources.Load<AudioClip>("holyCowCollected");
        holyCowHit = Resources.Load<AudioClip>("holyCowHit");
        ropeHit = Resources.Load<AudioClip>("ropeHit");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "demonCowSpawn":
                audioSrc.PlayOneShot(demonCowSpawn);
                break;
            case "demonCowDeath":
                audioSrc.PlayOneShot(demonCowDeath);
                break;
            case "holyCowCollected":
                audioSrc.PlayOneShot(holyCowCollected);
                break;
            case "holyCowHit":
                audioSrc.PlayOneShot(holyCowHit);
                break;
            case "ropeHit":
                audioSrc.PlayOneShot(ropeHit);
                break;
            default:
                break;
                
        }
    }

}
