using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBuilder : MonoBehaviour
{
        [Header("Prefabs")]
        [SerializeField] GameObject floorCorner;
        [SerializeField] GameObject floorNoCorner;
        [SerializeField] GameObject floorCornerTopBottom;
        [SerializeField] GameObject floorCornerLeftRight;
        [Header("Room Settings")]
        [SerializeField] int roomSize;
        [SerializeField] int xOffset;
        [SerializeField] int zOffset;
        [Header("Miscellaneous")]
        [SerializeField] Transform cubeContainer;
       
    // Start is called before the first frame update
    void Start()
    {
                BuildFloor();
    }
        
        private void BuildFloor()
        {
                for(int row = 1; row < roomSize - 1; row++)
                {
                        for(int col = 1; col < roomSize - 1; col++)
                        {
                                GameObject block = null;
                                Vector3Int position = new Vector3Int(row + xOffset, -1, col + zOffset);
                                if( row == 1 && col  == 1) //bl
                                {
                                        block = Instantiate(floorCorner, position, Quaternion.identity);
                                        block.transform.Rotate(new Vector3(0, 90, 0));

                                }

                                else if (row == roomSize - 2 && col == roomSize - 2) //tr
                                {
                                        block = Instantiate(floorCorner, position, Quaternion.identity);
                                        block.transform.Rotate(new Vector3(0, -90, 0));
                                }

                                else if ( row == 1 && col  == roomSize - 2)//tl
                                {
                                        
                                        
                                        block = Instantiate(floorCorner, position, Quaternion.identity);
                                        block.transform.Rotate(new Vector3(0, 180, 0));
                                }

                                else if(row == roomSize - 2 && col == 1) //brl
                                {

                                        block = Instantiate(floorCorner, position, Quaternion.identity);


                                }
                                else if( row == 1)
                                {
                                        block = Instantiate(floorCornerLeftRight, position, Quaternion.identity);
                                        block.transform.Rotate(new Vector3Int(0, 90, 0));
                                }
                                else if ( row == roomSize - 2)
                                {
                                        block = Instantiate(floorCornerLeftRight, position, Quaternion.identity);
                                        block.transform.Rotate(new Vector3Int(0, -90, 0));
                                }
                                else if( col == 1)
                                {
                                        block = Instantiate(floorCornerTopBottom, position, Quaternion.identity);
                                        block.transform.Rotate(new Vector3Int(0, 90, 0));
                                }
                                else if( col == roomSize - 2)
                                {
                                        block = Instantiate(floorCornerTopBottom, position, Quaternion.identity);
                                        block.transform.Rotate(new Vector3Int(0, -90, 0));
                                }
                                else
                                {
                                        block = Instantiate(floorNoCorner, position, Quaternion.identity);
                             
                                }
                                if (block != null)
                                        block.transform.parent = cubeContainer;
                        }
                }
        }
}
