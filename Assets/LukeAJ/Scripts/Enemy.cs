using System;
using System.Collections;
using System.Collections.Generic;
//using System.Runtime.Remoting.Messaging;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LukeAJ
{
    public class Enemy : MonoBehaviour
    {
        //Event stuff
        public HomeBase homeBase;
        public EnemyPatrol enemyPatrol;
        
        [Header("Enemy references")]
        //TODO 
        //when player is destroyed there is a null reference, so may need to check for the player script instead
        public Transform player;
        private Rigidbody rb;
        
        //Chase variables
        [Header("Chase stuff")]
        public float stoppingDistance;
        public float chaseSpeed;

        // Start is called before the first frame update
        void OnEnable()
        {
            rb = GetComponent<Rigidbody>();
            //subscribing to the retreat event
            homeBase.onTriggerEnterEvent += Retreat;
        }

        private void OnDisable()
        {
            //always unsubscribe when the object is destroyed or disabled
            homeBase.onTriggerEnterEvent -= Retreat;
        }

        public void Chase()
        {
            Vector3 chaseDirection = player.position - transform.position;
            
            if (Vector3.Distance(transform.position, player.position) > stoppingDistance )
            {
                //rotation
                rb.AddTorque(Vector3.Cross(transform.forward, chaseDirection) * enemyPatrol.turnSpeed);
                rb.AddForce((player.position - transform.position) * chaseSpeed);
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
