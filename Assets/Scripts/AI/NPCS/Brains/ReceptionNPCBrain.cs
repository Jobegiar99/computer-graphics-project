using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptionNPCBrain : MonoBehaviour
{
        [SerializeField] GameObject moneyExpression;
        [SerializeField] GameObject npcResponseExpression;
        public State myState;
        [System.NonSerialized]public bool interactionEnded = false;
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

        public void StartInteraction(float time)
        {
                interactionEnded = false;
                StartCoroutine(StopInteraction(time));
        }

        private IEnumerator StopInteraction(float time)
        {
                yield return new WaitForSecondsRealtime(time);
                interactionEnded = true;
        }

        public void StartPayInteraction()
        {
                moneyExpression.SetActive(true);
                StartCoroutine(DisableMoneyExpression());
        }

        private IEnumerator DisableMoneyExpression()
        {
                yield return new WaitForSecondsRealtime(1);
                moneyExpression.SetActive(false);

                if (Random.Range(0f, 1f) < 0.15f)
                {
                        npcResponseExpression.SetActive(true);
                        yield return new WaitForSecondsRealtime(1);
                        npcResponseExpression.SetActive(false);
                }
        }
}
