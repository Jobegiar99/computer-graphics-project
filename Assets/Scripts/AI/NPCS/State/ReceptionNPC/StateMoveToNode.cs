using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StateMoveToNode : State
{
        //TO DO queue de npcs a los que se les tiene que dar el paso;
        //estado de esperar o simplemente ver que onda con el update
        
        public int waypointIndex;
        public List<SpecialWaypointInfo> waypointInfo;
        public float accuracy = 1.2f;
        public float speed = 2f;
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
                //update sprite
        }

        public override void Update()
        {
                base.Update();

                bool hasReachedDestination = MoveToNode();

                if (hasReachedDestination)
                {
                        nextState = new StateMoveToNode(myGameObject, waypointInfo, waypointIndex + 1);
                        stage = STAGE.Exit;
                }
        }

        public override void Exit()
        {
                base.Exit();
                waypointInfo[waypointIndex].inUse = false;
                canIMove = false;
                //change sprite to iddle
        }

        private bool MoveToNode()
        {
                Vector3 targetPosition = waypointInfo[waypointIndex].transform.position;
   
                if (Vector3.Distance(targetPosition, myGameObject.transform.position) < accuracy)
                        return true;

                Vector3 movementDirection = (targetPosition - myGameObject.transform.position);
                movementDirection.y = 0;
                movementDirection = movementDirection.normalized;
                myGameObject.transform.position += movementDirection * Time.deltaTime * speed;
                return false;
        }
}
