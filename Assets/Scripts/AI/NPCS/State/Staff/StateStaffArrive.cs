using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateStaffArrive : State
{
        public Transform destination;
        
        public StateStaffArrive( GameObject myGO)
                : base( myGO)
        {
                //this.destination =  myGO.GetComponent<   
        }

        public override void Enter()
        {
                base.Enter();
                //call pathFinding
        }
}
