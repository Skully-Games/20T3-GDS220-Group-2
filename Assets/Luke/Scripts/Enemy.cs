using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LukeAJ
{
    public class Enemy : MonoBehaviour
    {
        //Event stuff
        public HomeBase homeBase;
        
        [Header("Enemy references")]
        //TODO 
        //when player is destroyed there is a null reference, so may need to check for the player script instead
        public Transform player;
        public float speed;
        public GameObject crystal;

        //Patrol variables
        [Header("Patrolling stuff")]
        public Transform patrolPoint;
        private float waitTime;
        public float startWaitTime;
        public float turnSpeed;
        public float avoidTurnForce;
        public bool canMove = false;
        public bool avoidEnabled = true;
        public bool patrolEnabled = true;
        [Header("Crystal min and max Z and X positions (this will be the enemy's radius protecting the crystal)")]
        public float minX;
        public float maxX;
        public float minZ;
        public float maxZ;
        public float leftRayOffset;
        public float rightRayOffset;
        private Rigidbody rb;
        
        //avoid
        public float minimumDistToAvoid;
        
        //Chase variables
        [Header("Chase stuff")]
        public float stoppingDistance;

        // Start is called before the first frame update
        void OnEnable()
        {
            rb = GetComponent<Rigidbody>();
            //subscribing to the retreat event
            homeBase.onTriggerEnterEvent += Retreat;
            
            //patrol
            waitTime = startWaitTime;
            patrolPoint.position = new Vector3(Random.Range(minX,maxX),crystal.transform.position.y, Random.Range(minZ, maxZ));
        }

        private void Update()
        {
            AvoidObstacles();
        }

        private void OnDisable()
        {
            //always unsubscribe when the object is destroyed or disabled
            homeBase.onTriggerEnterEvent -= Retreat;
        }
        
        public void AvoidObstacles()
        {

            if (avoidEnabled == false)
            {
                return;
            }
            RaycastHit hit;

            Vector3 leftRay = transform.position;
            Vector3 rightRay = transform.position;

            leftRay.x -= leftRayOffset;
            rightRay.x += rightRayOffset;

            Vector3 newDirection = patrolPoint.position - transform.position;
            newDirection = newDirection.normalized;

            

            //middle ray
            Debug.DrawLine(transform.position,(transform.forward * minimumDistToAvoid/2f) + transform.position,Color.green);

            if(Physics.Raycast(transform.position, transform.forward,out hit, minimumDistToAvoid/2f))
            {
                //checking to see if it hit itself
                if(hit.transform != transform)
                {
                    canMove = false;
                    Debug.DrawLine(transform.position,hit.point + transform.position,Color.red);
                    newDirection += hit.normal * 100;

                    Quaternion newLookRotation = Quaternion.LookRotation(newDirection);
                    // transform.rotation = Quaternion.Slerp(transform.rotation, newLookRotation, Time.deltaTime * turnSpeed);
                    rb.AddTorque(0,avoidTurnForce * 4f,0);
                }
            }
            //right ray rotation
            if (Physics.Raycast(rightRay, transform.forward, out hit, minimumDistToAvoid))
            {
                canMove = false;
                Debug.DrawLine(rightRay, hit.point, Color.yellow);
                newDirection += hit.normal * 100;
                
                // transform.position = Vector3.MoveTowards(transform.position, newDirection, speed * Time.deltaTime);
                rb.AddTorque(0,-avoidTurnForce ,0);
            }
            //left ray rotation
            if (Physics.Raycast(leftRay, transform.forward, out hit, minimumDistToAvoid))
            {
                canMove = false;
                Debug.DrawLine(leftRay, hit.point, Color.blue);
                newDirection += hit.normal * 100;
                
                // transform.position = Vector3.MoveTowards(transform.position, newDirection, speed * Time.deltaTime);
                rb.AddTorque(0,avoidTurnForce ,0);
            }
            
            else
            {
                canMove = true;
            }
        }

        public void Patrol()
        {
            if (patrolEnabled == false)
            {
                return;
            }
            //making a variable to check distance between current pos and the next patrol position
            Vector3 relativePos = patrolPoint.position - transform.position;
            
            if (canMove)
            {
                //need to check for null for this function to work properly
                //rotation while moving to next position
                if (relativePos != Vector3.zero)
                {
                    // Quaternion lookRotation = Quaternion.LookRotation(relativePos);
                    rb.AddTorque(Vector3.Cross(transform.forward,relativePos )* turnSpeed);
                    // transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
                }
                //moving to the patrol point
                //transform.position = Vector3.MoveTowards(transform.position, patrolPoint.position, speed * Time.deltaTime);
                rb.AddRelativeForce(0,0,speed);
            }
            
            //the radius enemy likes to patrol in.... also change the last distance into a variable
            if (Vector3.Distance(transform.position, patrolPoint.position) < 3f)
            {
                if (waitTime <= 0)
                {
                    patrolPoint.position = new Vector3(Random.Range(minX,maxX),crystal.transform.position.y, Random.Range(minZ, maxZ));
                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }

        public void Chase()
        {
            if (Vector3.Distance(transform.position, player.position) > stoppingDistance )
            {
                transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }

            //stops at a specified stoppingDistance and attacks or damages
            else if(Vector3.Distance(transform.position, player.position) <= stoppingDistance)
            {
                Attack();
            }
        }

        private void Attack()
        {
            //temporary
            Destroy(player.gameObject);
        }

        public void Retreat(Collider homeBaseCol)
        {
            GetComponent<EnemyStates>().ChangeState(GetComponent<EnemyStates>().retreat);
        }
    }
}
