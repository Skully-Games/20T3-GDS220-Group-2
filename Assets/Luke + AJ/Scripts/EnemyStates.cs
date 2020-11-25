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

            retreat.Enter = OnRetreatEnter;
            retreat.Update = OnRetreatUpdate;
            retreat.Exit = OnRetreatExit;

            ChangeState(patrol);
        }

        //the different state functions
        private void OnRetreatExit()
        {
            throw new NotImplementedException();
        }

        private void OnRetreatUpdate()
        {
            throw new NotImplementedException();
        }

        private void OnRetreatEnter()
        {
            throw new NotImplementedException();
        }

        private void OnChaseUpdate()
        {
            enemy.Chase();

            if (Vector3.Distance(player.position, gameObject.transform.position) >= enemyLostSight)
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
