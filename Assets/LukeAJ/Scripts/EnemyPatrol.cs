using System;
using System.Collections;
using System.Collections.Generic;
using LukeAJ;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyPatrol : MonoBehaviour
{
    //Crystal radius (technically a square)
    [Header("Crystal min and max Z and X positions (this will be the enemy's radius protecting the crystal)")]
    public float minX;

    public float maxX;
    public float minZ;
    public float maxZ;

    //references
    private Rigidbody rb;
    public GameObject crystal;
    public Transform patrolPoint;

    //time and physics variables
    private float waitTime;
    public float startWaitTime;
    public float speed;
    public float turnSpeed;

    //bool checking
    public bool patrolEnabled = true;

    public void Start()
    {
        //patrol
        waitTime = startWaitTime;
        patrolPoint.position =
            new Vector3(Random.Range(minX, maxX), crystal.transform.position.y, Random.Range(minZ, maxZ));
        rb = GetComponent<Rigidbody>();
    }

    public void Patrol()
    {
        //testing bool
        if (patrolEnabled == false)
        {
            return;
        }

        //making a variable to check distance between current pos and the next patrol position
        Vector3 relativePos = patrolPoint.position - transform.position;


        //need to check for null for this function to work properly
        if (relativePos != Vector3.zero)
        {
            //rotation while moving to next position
            
            //old 
            // Quaternion lookRotation = Quaternion.LookRotation(relativePos);
            // transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);

            //new
            rb.AddTorque(Vector3.Cross(transform.forward, relativePos) * turnSpeed);
        }
        //moving to the patrol point

        //old
        //transform.position = Vector3.MoveTowards(transform.position, patrolPoint.position, speed * Time.deltaTime);

        //new
        rb.AddForce((patrolPoint.position - transform.position).normalized * speed);


        //the radius enemy likes to patrol in.... TODO: also change the last distance into a variable
        if (Vector3.Distance(transform.position, patrolPoint.position) < 3f)
        {
            if (waitTime <= 0)
            {
                patrolPoint.position = new Vector3(Random.Range(minX, maxX), crystal.transform.position.y,
                    Random.Range(minZ, maxZ));
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
