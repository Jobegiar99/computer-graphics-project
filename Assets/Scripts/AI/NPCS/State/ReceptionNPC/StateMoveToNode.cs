using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StateMoveToNode : State
{      
        public int waypointIndex;
        public List<SpecialWaypointInfo> waypointInfo;
        public float accuracy = 0.6f;
        public float speed = 0.8f;
        public bool canIMove = false;



        public StateMoveToNode(GameObject gameObject, List<SpecialWaypointInfo> waypointInfo, int waypointIndex )
                :base(gameObject)
        {
               this.waypointInfo = waypointInfo;
               this.waypointIndex = waypointIndex;
               state = STATE.ReceptionMoveToNode;
        }

        public override void Enter()
        {
                base.Enter();

                if (!waypointInfo[waypointIndex].inUse)
                {
                        waypointInfo[waypointIndex].inUse = true;
                        canIMove = true;
                }
                SetIddle();

        }

        public override void Update()
        {       
                
                base.Update();

                bool hasReachedDestination = MoveToNode();

                if (hasReachedDestination)
                {
                        nextState = new StateReceptionInteract(myGameObject, waypointInfo, waypointIndex);
                        stage = STAGE.Exit;
                }
        }

        public override void Exit()
        {
                base.Exit();
                SetIddle();
        }

        private bool MoveToNode()
        {
                Vector3 targetPosition = waypointInfo[waypointIndex].transform.position;
   
                if (Vector3.Distance(targetPosition, myGameObject.transform.position) <= accuracy)
                        return true;
                SetWalk();
                Vector3 movementDirection = (targetPosition - myGameObject.transform.position);
                movementDirection.y = 0;
                movementDirection = movementDirection.normalized;
                myGameObject.transform.position += movementDirection * Time.deltaTime * speed;
                return false;
        }
        private void SetWalk()
        {
                switch (waypointIndex)
                {
                        case 0:
                        case 1:
                        case 2:
                                {
                                        animator.SetTrigger("walk_foward");
                                        break;
                                }
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                                {
                                        animator.SetTrigger("walk_left");
                                        break;
                                }
                        case 8:
                        case 9:
                                {
                                        animator.SetTrigger("walk_backwards");
                                        break;
                                }

                }
        }


        private void SetIddle()
        {
                switch (waypointIndex)
                {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                                {
                                        animator.SetTrigger("iddle_front");
                                        break;
                                }
                        case 4:
                        case 5:
                        case 6:
                                {
                                        animator.SetTrigger("iddle_left");
                                        break;
                                }
                        case 7:
                                {
                                        if (stage != State.STAGE.Exit)
                                                animator.SetTrigger("iddle_left");

                                        else
                                                animator.SetTrigger("iddle_back");

                                        break;
                                }
                        
                        case 8:
                        case 9:
                                {
                                        animator.SetTrigger("iddle_back");
                                        break;
                                }
                }
        }
}
