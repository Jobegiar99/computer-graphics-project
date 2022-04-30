using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateStaffWait : State
{
        public StateStaffWait(GameObject myGo)
                :base(myGo)
        {
                
        }

        public override void Enter()
        {
                base.Enter();
                //animator set animation to iddle
        }

        public override void Update()
        {
                base.Update();
                bool notSpaceFree = false;
                //isSpaceFree = myGameObject.GetComponent<??>().FreeSpace
                if (notSpaceFree)
                {
                        this.stage = STAGE.Exit;
                }
        }

        public override void Exit()
        {
                base.Exit();
                //set animation to serve
        }

}
