using System.Collections.Generic;
using UnityEngine;

public class BlockBuilder : MonoBehaviour
{
        [Header("Wall Prefabs")]
        [SerializeField] List<GameObject> wallBottom;
        [SerializeField] List<GameObject> wallCenter;
        [SerializeField] List<GameObject> wallTop;
        [Header("Room Settings")]
        [SerializeField] int roomSize;
        [SerializeField] int xOffset;
        [SerializeField] int zOffset;
        [Header("Miscellaneous")]
        [SerializeField] Transform blockContainer;

        Dictionary<int, Vector3Int> orientationHelper = new Dictionary<int, Vector3Int>
        {
                {0,new Vector3Int(0,90,0) }, // left
                {1, new Vector3Int(0,0,-180) }, // center
                {2, new Vector3Int(0,-90,0) } // right
        };


        // Start is called before the first frame update
        void Start()
        {
                buildBlocks(wallBottom, 0);
                buildBlocks(wallCenter, 1);
                buildBlocks(wallTop, 2);
        }

        private void buildBlocks(List<GameObject> blockList, int height)
        {
                for(int row = 0; row < roomSize; row++)
                {
                        for(int col = 0; col < roomSize; col++)
                        {
                                bool isValidColumn = (col == 0 || col == roomSize - 1);
                                bool isValidRow = row > 0;
                                bool isStartingRow = (row == roomSize - 1);
                                GameObject block = null;
                                Vector3Int position = new Vector3Int(col + xOffset, height,row + zOffset);


                                if( isStartingRow )
                                {
                                        if( col == 0)
                                        {
                                                block = Instantiate(blockList[0], position, Quaternion.identity);
                                                block.transform.Rotate(orientationHelper[0]);
                                        }
                                        else if ( col == roomSize - 1)
                                        {
                                                block = Instantiate(blockList[2], position, Quaternion.identity);
                                                block.transform.Rotate(orientationHelper[2]);
                                        }
                                        else
                                        {
                                                block = Instantiate(blockList[1], position, Quaternion.identity);
                                                block.transform.Rotate(orientationHelper[1]);
                                        }
                                }
                                else if( isValidColumn && isValidRow )
                                {
                                        block = Instantiate(blockList[1], position, Quaternion.identity);
                                        if(col == 0)
                                                block.transform.Rotate(orientationHelper[0]);
                                        else
                                        {
                                                block.transform.Rotate(orientationHelper[2]);
                                        }
                                }
                                if(block != null)
                                        block.transform.parent = blockContainer;
                        }
                }
        }
}
