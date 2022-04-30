using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptionNPCBrain : MonoBehaviour
{
        public State myState;
        // Start is called before the first frame update
        public void Init(List<SpecialWaypointInfo> waypointInfo)
        {  
                myState = new StateMoveToNode(this.gameObject, waypointInfo, 0);
                PerformAction();
        }

        public bool CanMove()
        {

                if (myState.state != State.STATE.ReceptionMoveToNode)
                        return false;


                bool canIMove = ((StateMoveToNode)(myState)).canIMove;
             

                if (canIMove)
                        return true;

                int waypointIndex = ((StateMoveToNode)(myState)).waypointIndex;

                if (((StateMoveToNode)(myState)).waypointInfo[waypointIndex].inUse)
                        return false;

                ((StateMoveToNode)(myState)).waypointInfo[waypointIndex].inUse = true;
                ((StateMoveToNode)(myState)).canIMove = true;

                return true;
        }

        // Update is called once per frame
        public void PerformAction() 
        {
                myState = myState.Process();
        }
}
