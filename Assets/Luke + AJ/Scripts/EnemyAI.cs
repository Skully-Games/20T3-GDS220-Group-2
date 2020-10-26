using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LukeAJ
{
    public class EnemyAI : MonoBehaviour
    {
        public class SimpleStateTest : MonoBehaviour
        {
            //Useful variables
            public DelegateState currentState;

            public DelegateState idle = new DelegateState();
            public DelegateState patrol = new DelegateState();
            public DelegateState attack = new DelegateState();
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
            
            void Start()
            {
                //doesn't run the functions just remembers it
                idle.Enter = OnIdleEnter;
                idle.Update = OnIdleUpdate;
                idle.Exit = OnIdleExit;

                patrol.Enter = OnPatrolEnter;
                patrol.Update = OnPatrolUpdate;
                patrol.Exit = OnPatrolExit;

                attack.Enter = OnAttackEnter;
                attack.Update = OnAttackUpdate;
                attack.Exit = OnAttackExit;

                retreat.Enter = OnRetreatEnter;
                retreat.Update = OnRetreatUpdate;
                retreat.Exit = OnRetreatExit;

                ChangeState(idle);
            }

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

            private void OnAttackExit()
            {
                throw new NotImplementedException();
            }

            private void OnAttackUpdate()
            {
                throw new NotImplementedException();
            }

            private void OnAttackEnter()
            {
                throw new NotImplementedException();
            }

            private void OnPatrolExit()
            {
                throw new NotImplementedException();
            }

            private void OnPatrolUpdate()
            {
                throw new NotImplementedException();
            }

            private void OnPatrolEnter()
            {
                throw new NotImplementedException();
            }

            private void OnIdleExit()
            {
                throw new NotImplementedException();
            }

            private void OnIdleUpdate()
            {
                throw new NotImplementedException();
            }

            private void OnIdleEnter()
            {
                throw new NotImplementedException();
            }

            // Update is called once per frame
            void Update()
            {
                UpdateCurrentState();
            }
            
        }
    }
}
