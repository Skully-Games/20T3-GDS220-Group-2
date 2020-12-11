using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LukeAJ
{
    public class EnemyStates : MonoBehaviour
    {
        //References
        public Enemy enemy;
        public Transform player;
        public float playerSpottedDistance;
        public float enemyLostSight;
        public float maxDistance;

        //State stuff 
        public DelegateState currentState;
        
        public DelegateState patrol = new DelegateState();
        public DelegateState chase = new DelegateState();
        public DelegateState retreat = new DelegateState();

        //These will help point to a function
        [Serializable]
        public class DelegateState
        {
            public Action Enter;
            public Action Exit;
            public Action Update;
            public bool active;
        }

        //Change state manager
        public void ChangeState(DelegateState newState)
        {
            if (currentState != null)
            {
                currentState.active = false;
                currentState.Exit?.Invoke();
            }

            if (newState != null)
            {
                newState.active = true;
                newState.Enter?.Invoke();
                currentState = newState;
            }
        }

        public void UpdateCurrentState()
        {
            currentState?.Update?.Invoke();
        }

        private void Start()
        {
            //doesn't run the functions just remembers it
            patrol.Update = OnPatrolUpdate;
            
            chase.Update = OnChaseUpdate;
            
            retreat.Update = OnRetreatUpdate;

            ChangeState(patrol);
        }

        //the different state functions
        private void OnRetreatUpdate()
        {
            Vector3 relativePos = transform.position - player.position;

            //need to check for null for this function to work properly
            //rotation while retreating
            if (relativePos != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(relativePos);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * enemy.turnSpeed);
            }
            
            //moving towards the end retreat pos and de-spawn
            transform.position = Vector3.MoveTowards(transform.position, transform.position * maxDistance, enemy.speed * Time.deltaTime);

            if (Vector3.Distance(player.position, transform.position) >= maxDistance)
            {
                gameObject.SetActive(false);
            }
            
        }

        private void OnChaseUpdate()
        {
            enemy.Chase();

            if (Vector3.Distance(player.position, transform.position) >= enemyLostSight)
            {
                ChangeState(patrol);
            }
        }

        private void OnPatrolUpdate()
        {
            enemy.Patrol();
            
            if (Vector3.Distance(player.position,gameObject.transform.position) <= playerSpottedDistance)
            {
                ChangeState(chase);
            }
        }

        // Update is called once per frame
        private void Update()
        {
            UpdateCurrentState();
        }
            
    }
}
