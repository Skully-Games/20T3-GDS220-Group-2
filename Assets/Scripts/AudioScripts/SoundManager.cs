using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    static AudioSource audioSource;
    public static AudioClip jumpSound, breathSound,screech,chase;

    // Start is called before the first frame update
    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("JumpLanding");
        breathSound = Resources.Load<AudioClip>("HBreathing");
        screech = Resources.Load<AudioClip>("Mscreech");
        chase = Resources.Load<AudioClip>("Chase");

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySFX(string clip)
    {
        switch(clip)
        {
            case "JumpLanding":
                audioSource.PlayOneShot(jumpSound);
                break;

            case "HBreathing":
                audioSource.PlayOneShot(breathSound);
                break;

            case "Mscreech":
                audioSource.PlayOneShot(screech);
                break;

            case "Chase":
                audioSource.PlayOneShot(chase);
                break;
        }
    }
}