using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
        Transform goal;
        float speed = 5.0f;
        float accuracy = 1.0f;
        float rotSpeed = 2.0f;
        public GameObject wpManager;
        GameObject[] wps;
        GameObject currentNode;
        int currentWP = 0; //current waypoint position, not the array index
        Graph g;
        // Start is called before the first frame update
        void Start()
        {
                wps = wpManager.GetComponent<WPManager>().waypoints;
                g = wpManager.GetComponent<WPManager>().graph;
               // depende  currentNode = wps[7];
        }

        // Update is called once per frame
        /*void LateUpdate()
        {
                if (g.getPathLength() == 0 || currentWP == g.getPathLength())
                        return;

                //the node we are closest to at this moment
                currentNode = g.getPathPoint(currentWP);
                float currentDistance = Vector3.Distance(
                                        g.getPathPoint(currentWP).transform.position,
                                        transform.position);

                if (currentDistance < accuracy )
                {
                        currentWP++;
                }

                if( currentWP < g.getPathLength())
                {
                        goal = g.getPathPoint(currentWP).transform;
                        Vector3 lookAtGoal = new Vector3(goal.position.x,
                                                                                this.transform.position.y,
                                                                                goal.position.z);
                        
                }
         }*/

        
}
