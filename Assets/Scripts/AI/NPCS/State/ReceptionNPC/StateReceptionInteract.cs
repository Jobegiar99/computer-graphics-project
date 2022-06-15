using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;


public class StateReceptionInteract : State
{

        static Timer timer = new Timer();

        public int waypointIndex;

        public List<SpecialWaypointInfo> waypointInfo;

        private ReceptionNPCBrain brain;


        public StateReceptionInteract(GameObject myGo, List<SpecialWaypointInfo> waypointInfo, int waypointIndex)
               : base(myGo)
        {
                this.waypointInfo = waypointInfo;
                this.waypointIndex = waypointIndex;
                state = STATE.ReceptionInteract;

                this.brain = myGameObject.GetComponent<ReceptionNPCBrain>();
        }

        public override void Enter()
        {
                base.Enter();
                //set animation
                //switch to decide interaction type
                //implementar esto
                //delete next line:
                switch (waypointIndex)
                {
                        case 0:
                                {
                                        
                                        animator.SetTrigger("interact_right");
                                        brain.StartInteraction(2);
                                        break;
                                }
                        case 1:
                                {
                                        animator.SetTrigger("interact_right");
                                        brain.StartInteraction(2);
                                        break;
                                }
                        case 2:
                                {
                                        stage = STAGE.Exit;
                                        break;
                                }
                        case 3:
                                {
                                        animator.SetTrigger("interact_front");
                                        brain.StartInteraction(3);

                                        ReceptionNPCManager manager = GameObject.Find("NPCReceptionManager").
                                                        GetComponent<ReceptionNPCManager>();

                                        if (!manager.IsNight)
                                                brain.StartPayInteraction();

                                        break;
                                }
                        case 4:
                                {
                                        animator.SetTrigger("interact_front");
                                        brain.StartInteraction(2);
                                        break;
                                }
                        case 5:
                                {
                                        animator.SetTrigger("interact_front");
                                        brain.StartInteraction(2);
                                        break;
                                }
                        case 6:
                                {
                                        animator.SetTrigger("interact_front");
                                        brain.StartInteraction(2);
                                        break;
                                }
                        case 7:
                                {
                                        animator.SetTrigger("interact_front");
                                        brain.StartInteraction(2);
                                        break;
                                }
                        case 8:
                                {
                                        animator.SetTrigger("interact_left");
                                        brain.StartInteraction(2);
                                        break;
                                }
                }
        }

        public override void Update()
        {
                base.Update();
                if (brain.interactionEnded)
                        stage = STAGE.Exit;
        }

        public override void Exit()
        {
                base.Exit();
                while (waypointInfo[waypointIndex + 1].inUse)
                {
                        SetIddle();
                        continue;
                }
                SetIddle();
                waypointInfo[waypointIndex].inUse = false;
                nextState = new StateMoveToNode(myGameObject, waypointInfo, waypointIndex + 1);
        }

        private void SetIddle()
        {
                switch (waypointIndex)
                {
                        case 0:
                        case 1:
                        case 2:
                                {
                                        animator.SetTrigger("iddle_front");
                                        break;
                                }
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                                {
                                        animator.SetTrigger("iddle_left");
                                        break;
                                }

                        case 8:
                                {
                                        animator.SetTrigger("iddle_back");
                                        break;
                                }
                }
        }
}

