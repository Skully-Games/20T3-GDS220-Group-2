using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepGrass : MonoBehaviour
{

    public AudioSource footStepsGrass;
    public AudioClip[] footSoundsG;

    // Start is called before the first frame update
    void Start()
    {

        footStepsGrass = GetComponent<AudioSource>();
        
    }

    /* OTHER WAY TO RANDOMIZE THE ARRAY OF FOOTSTEP SOUNDS
    private void FootSound()
    {
        //footStepsGrass.clip = footSounds[Random.Range(0, footSounds.Length)];
        //footStepsGrass.PlayOneShot(footStepsGrass.clip);

        //footSteps.Play();
        //footSteps.clip = footSounds[Random.Range(0, 5)];
        //footSteps.PlayOneShot(footSteps.clip);

    }*/
 
    void GrassFootStep()
    {
        int i = Random.Range(0, footSoundsG.Length);
        footStepsGrass.clip = footSoundsG[i];
        footStepsGrass.PlayOneShot(footStepsGrass.clip);

        footSoundsG[i] = footSoundsG[0];
        footSoundsG[0] = footStepsGrass.clip;
        
    }
}





