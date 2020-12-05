using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LukeAJ
{
    public class Raycast : MonoBehaviour
    {
        //raycasting stuff
        Ray ray = new Ray();
        RaycastHit raycastHit = new RaycastHit();
        public float rayDistance;

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
                transform.Rotate(0, Time.deltaTime * 100f, 0);
            }

        }

        void RaycastBool()
        {
            if (Physics.Raycast(transform.position, transform.forward))
            {
                transform.Rotate(0,Time.deltaTime * 100f, 0);
            }
        }

        private void OnDrawGizmos()
        {
            if (raycastHit.transform != null)
            {
                Debug.Log("drawing gizmos");
                Gizmos.color = Color.green;
                Gizmos.DrawLine(ray.origin, raycastHit.point);

                Gizmos.color = Color.red;
                Gizmos.DrawRay(raycastHit.point, raycastHit.normal);

                Gizmos.color = Color.yellow;
                Gizmos.DrawRay(raycastHit.point, Vector3.Reflect(ray.direction, raycastHit.normal));
            }
        }
    }
}
