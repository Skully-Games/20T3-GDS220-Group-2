using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LukeAJ
{
    public class HomeBase : MonoBehaviour
    {
        public bool enemyEnter = false;

        // Update is called once per frame
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Enemy>())
            {
                enemyEnter = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            enemyEnter = false;
        }
    }
}
