using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Luke
{
    public class Raycast : MonoBehaviour
    {
        //raycasting stuff
        public float rayDistance;
        public Ray ray = new Ray();
        public RaycastHit raycastHit = new RaycastHit();
        public float rotationSpeed;

        // Update is called once per frame
        void Update()
        {
            RaycastOut();
        }

        void RaycastOut()
        {
            Ray ray = new Ray();
            ray.origin = transform.position;
            ray.direction = transform.forward;
            RaycastHit raycastHit = new RaycastHit();
            
            if (Physics.Raycast(ray, out raycastHit, rayDistance))
            {
                if (raycastHit.transform != transform)
                {
                    Debug.DrawLine(ray.origin, raycastHit.point, Color.red);
                }
            }
        }
    }
}
