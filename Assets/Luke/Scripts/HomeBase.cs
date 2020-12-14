using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LukeAJ
{
    public class HomeBase : MonoBehaviour
    {
        //Event
        public event Action<Collider> onTriggerEnterEvent;

        public bool enemyEnter = false;

        // Update is called once per frame
        public void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Enemy>())
            {
                enemyEnter = true;
                onTriggerEnterEvent?.Invoke(other);
            }
        }
    }
}
