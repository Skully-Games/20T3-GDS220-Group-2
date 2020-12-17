using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAudioTrigger : MonoBehaviour
{

    [Header("Chase Music Controlls")]
    public AudioSource chaseSource;
    [SerializeField, Range(0, 1)] private float chaseVolume;

    public float lookRadius = 10f;

    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = ChaseAudioManager.instance.player.transform;

        chaseVolume = chaseSource.GetComponent<AudioSource>().volume;
        chaseVolume = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            chaseSource.GetComponent<AudioSource>().volume = chaseVolume = 1;
            SoundManager.PlaySFX("Mscreech");
        }
        else if (distance>=lookRadius)
        {
            chaseSource.GetComponent<AudioSource>().volume = chaseVolume = 0;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
