using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;


public class StateReceptionInteract : State
{

        static Timer timer = new Timer();
        public int waypointIndex;
        public List<SpecialWaypointInfo> waypointInfo;
        public StateReceptionInteract(GameObject myGo, List<SpecialWaypointInfo> waypointInfo, int waypointIndex)
               : base(myGo)
        {
                this.waypointInfo = waypointInfo;
                this.waypointIndex = waypointIndex;
                state = STATE.ReceptionInteract;
        }

        public override async void Enter()
        {
                base.Enter();
                //set animation
                //switch to decide interaction type
                //implementar esto
                switch(waypointIndex)
                {
                        case 1:
                                {
                                        break;
                                }
                        case 2:
                                {
                                        break;
                                }
                        case 3:
                                {
                                        break;
                                }
                        case 4:
                                {
                                        stage = STAGE.Exit;
                                        break;
                                }
                        case 5:
                                {
                                        break;
                                }
                        case 6:
                                {
                                        break;
                                }
                        case 7:
                                {
                                        break;
                                }
                }
        }

        public override void Update()
        {
                base.Update();
             
                if (myGameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("npc_iddle"))
                        stage = STAGE.Exit;

        }
        public override void Exit()
        {
                base.Exit();
                
                waypointInfo[waypointIndex].inUse = false;
                nextState = new StateMoveToNode(myGameObject, waypointInfo, waypointIndex + 1);
        }
}

