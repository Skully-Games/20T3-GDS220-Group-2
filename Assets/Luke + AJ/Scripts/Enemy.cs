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
        [Header("Enemy references")]
        
        //May want to change this to reference the player script instead but just hacked it for now
        public Transform player;
        public float speed;
        public GameObject crystal;

        //Patrol variables
        [Header("Patrolling stuff")]
        public Transform patrolPoint;
        private float waitTime;
        public float startWaitTime;
        [Header("Crystal min and max Z and X positions (this will be the enemy's radius protecting the crystal)")]
        public float minX;
        public float maxX;
        public float minZ;
        public float maxZ;
        
        //Chase variables
        [Header("Chase stuff")]
        public float stoppingDistance;

        // Start is called before the first frame update
        void Start()
        {
            //patrol
            waitTime = startWaitTime;
            patrolPoint.position = new Vector3(Random.Range(minX,maxX),crystal.transform.position.y, Random.Range(minZ, maxZ));
        }

        public void Patrol()
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoint.position, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, patrolPoint.position) < 0.2f)
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
        }

        // public void Retreat()
        // {
        //     
        // }
    }
}
