using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Rabbit
{
    public class RandomMoveWabbit : MonoBehaviour
    {

        NavMeshAgent navMesh;
        NavMeshPath navPath;

        public float newPathTimer;
        bool inCoRoutine;
        bool validPath;

        Vector3 target;

        // Start is called before the first frame update
        void Start()
        {
            navMesh = GetComponent<NavMeshAgent>();
            navPath = new NavMeshPath();
        }

        void Update()
        {
            if (!inCoRoutine)
                StartCoroutine(DoSomething());
        }

        Vector3 getNewRandomPosition()
        {

            float x = Random.Range(-50, -180);
            float z = Random.Range(117, 215);

            Vector3 position = new Vector3(x, 0, z);
            return position;
        }

        IEnumerator DoSomething()
        {
            inCoRoutine = true;
            yield return new WaitForSeconds(newPathTimer);
            GetNewPath();

            validPath = !navMesh.CalculatePath(target, navPath);

            if (!validPath)
            {
                
                yield return new WaitForSeconds(0.01f);
                
            }

            while (!validPath)
            {
                yield return new WaitForSeconds(0.01f);

                GetNewPath();
                validPath = navMesh.CalculatePath(target, navPath);
            }

            inCoRoutine = false;

        }

        void GetNewPath()
        {
            target = getNewRandomPosition();
            navMesh.SetDestination(target);
        }
    }
}