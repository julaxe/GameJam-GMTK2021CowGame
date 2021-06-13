using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip demonCowSpawn, demonCowDeath, holyCowCollected, holyCowHit, ropeHit,
        holyCowDeath, changeRope;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        demonCowSpawn = Resources.Load<AudioClip>("demonCowSpawn");
        demonCowDeath = Resources.Load<AudioClip>("demonCowDeath");
        holyCowCollected = Resources.Load<AudioClip>("holyCowCollected");
        holyCowHit = Resources.Load<AudioClip>("holyCowHit");
        holyCowDeath = Resources.Load<AudioClip>("holyCowDeath");
        ropeHit = Resources.Load<AudioClip>("ropeHit");
        changeRope = Resources.Load<AudioClip>("changeRope");
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
            case "holyCowDeath":
                audioSrc.PlayOneShot(holyCowDeath);
                break;
            case "changeRope":
                audioSrc.PlayOneShot(changeRope);
                break;
            default:
                break;
                
        }
    }

}
