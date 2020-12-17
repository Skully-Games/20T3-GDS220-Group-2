using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSreech : MonoBehaviour
{
    public float lookRadius = 3f;
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = ChaseAudioManager.instance.player.transform;  
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            SoundManager.PlaySFX("Mscreech");
        }
       
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
