using System;
using System.Collections;
using System.Collections.Generic;
using Luke;
using LukeAJ;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyPatrol : MonoBehaviour
{
    //Crystal radius (technically a square)
    [Header("Crystal min and max Z and X positions (this will be the enemy's radius protecting the crystal)")]
    public float minRange;
    public float maxRange;

    //references
    private RaycastAvoid raycastAvoid;
    private Rigidbody rb;
    public GameObject crystal;
    public Transform patrolPoint;

    //time and physics variables
    private float waitTime;
    public float startWaitTime;
    public float speed;
    public float turnSpeed;
    public bool isWaiting;

    //bool checking
    public bool patrolEnabled = true;

    public void Start()
    {
        //patrol
        waitTime = startWaitTime;
        patrolPoint.position =
            new Vector3(Random.Range(crystal.transform.position.x + minRange,crystal.transform.position.x + maxRange ), 
                crystal.transform.position.y, Random.Range(crystal.transform.position.z + minRange,crystal.transform.position.z + maxRange ));
        rb = GetComponent<Rigidbody>();
    }

    public void Patrol()
    {
        //testing bool
        if (patrolEnabled == false)
        {
            return;
        }

        if (rb.velocity.magnitude <= 0.5f && !isWaiting)
        {
            patrolPoint.position = new Vector3(Random.Range(crystal.transform.position.x + minRange,crystal.transform.position.x + maxRange ), 
                crystal.transform.position.y, Random.Range(crystal.transform.position.z + minRange,crystal.transform.position.z + maxRange ));
        }

        //making a variable to check distance between current pos and the next patrol position
        Vector3 relativePos = patrolPoint.position - transform.position;

        if (relativePos != Vector3.zero)
        {
            //rotation while moving to next position
            rb.AddTorque(Vector3.Cross(transform.forward, relativePos) * turnSpeed);
        }

        //the radius enemy likes to patrol in.... TODO: also change the last distance into a variable
        if (Vector3.Distance(transform.position, patrolPoint.position) < 3f)
        {
            isWaiting = true;
            if (waitTime <= 0)
            {
                patrolPoint.position = new Vector3(Random.Range(crystal.transform.position.x + minRange,crystal.transform.position.x + maxRange ), 
                    crystal.transform.position.y, Random.Range(crystal.transform.position.z + minRange,crystal.transform.position.z + maxRange ));
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }

        }
        //moving to the patrol point
        else
        {
            rb.AddForce(transform.forward * speed); 
            isWaiting = false;
        }
    }
}
