using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptionNPCManager : MonoBehaviour
{
        [SerializeField] List<GameObject> waypointInfo;
        [SerializeField] Transform spawnPoint;
        [SerializeField] Transform exitPoint;
        [SerializeField] GameObject npcTemplate;
        [System.NonSerialized] public bool IsNight = false;
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

                InvokeRepeating("SpawnNPC", 0.5f, 0.25f);

                InvokeRepeating("ProcessNPC", 2f, 0.01f);
        }


        public void SpawnNPC()
        {
                //spawn the npc;
                if (Random.Range(0f, 1f) > Random.Range(0f, 0.3f) || IsNight)
                        return;

                GameObject newNPC = Instantiate(npcTemplate, new Vector3(10.6f, 0.5f, -2.679f), Quaternion.identity);
                newNPC.GetComponent<ReceptionNPCBrain>().Init(specialWaypointInfo);
                npcs.Add(newNPC);
                
        }

        private void ProcessNPC()
        {
                if (npcs.Count == 0)
                        return;

                for (int i = 0; i < npcs.Count; i++)
                {


                        GameObject npc = npcs[i];
                        ReceptionNPCBrain brain = npc.GetComponent<ReceptionNPCBrain>();

                        if (brain.myState.state == State.STATE.ReceptionInteract) 
                        {
                                brain.PerformAction();
                                continue;
                        }

                        if (!brain.CanMove())
                                continue;
                        
                        brain.PerformAction();

                        float distanceToExit = Vector3.Distance(
                                    npc.transform.position,
                                    exitPoint.transform.position
                        );

                        if (distanceToExit > 2)
                                continue;
                        


                        //add object pooling
                        (
                                (StateMoveToNode)
                                        (npc.GetComponent<ReceptionNPCBrain>().myState)
                        ).waypointInfo[waypointInfo.Count - 1].inUse = false;

                        Destroy(npc);
                        npcs.Remove(npc);

                }
        }
}

