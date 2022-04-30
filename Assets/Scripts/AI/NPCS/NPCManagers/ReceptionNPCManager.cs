using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptionNPCManager : MonoBehaviour
{
        [SerializeField] List<GameObject> waypointInfo;
        [SerializeField] Transform spawnPoint;
        [SerializeField] Transform exitPoint;
        [SerializeField] GameObject npcTemplate;
        private List<GameObject> npcs;
        private List<SpecialWaypointInfo> specialWaypointInfo;

        // Start is called before the first frame update
        void Start()
        {
                npcs = new List<GameObject>();
                specialWaypointInfo = new List<SpecialWaypointInfo>();
                for (int i = 0; i < waypointInfo.Count; i++)
                {
                        specialWaypointInfo.Add(waypointInfo[i].GetComponent<SpecialWaypointInfo>());
                }

                Invoke("SpawnNPC",0.5f);
                Invoke("SpawnNPC", 0.5f);
                Invoke("SpawnNPC", 0.5f);
                InvokeRepeating("ProcessNPC", 2f, 0.1f);
        }

        // Update is called once per frame
        void Update()
        {
                //non
        }

        public void SpawnNPC()
        {
                //spawn the npc;
                GameObject newNPC = Instantiate(npcTemplate, new Vector3(10.6f, 0.5f, -2.679f), Quaternion.identity);
                newNPC.GetComponent<ReceptionNPCBrain>().Init(specialWaypointInfo);
                npcs.Add(newNPC);
                
        }

        private void ProcessNPC()
        {
                if (npcs.Count == 0)
                        return;
                Debug.Log(npcs.Count);
               
                for(int i = 0; i < npcs.Count ; i++)
                {

                        GameObject npc = npcs[i];
                        ReceptionNPCBrain brain = npc.GetComponent<ReceptionNPCBrain>();
                        State.STATE st = State.STATE.ReceptionMoveToNode;
                        
                        if (brain.myState.state != st || !brain.CanMove())
                                continue;

                        StateMoveToNode currentState = (StateMoveToNode)brain.myState;
                        brain.PerformAction();

                        if (currentState.stage != State.STAGE.Exit)
                                return;

                        float distanceToExit = Vector3.Distance(
                                    npc.transform.position,
                                    exitPoint.transform.position
                        );

                        if (distanceToExit > 2)
                                return;
                        //add object pooling
                        
                        Destroy(npc);
                        npcs.Remove(npc);
                        
                }
        }
}

