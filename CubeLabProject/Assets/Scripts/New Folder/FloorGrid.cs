using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGrid : MonoBehaviour
{
    public GameObject matchingFloor; 
    public int rows = 5;
    

    public GameObject[,] gridArray;
    GameObject[] everyBlock;

    //public int charPosX = 2;
    //public int charPosY = 2;

    private void Awake()
    {
        everyBlock = new GameObject[transform.childCount];
        gridArray = new GameObject[rows, rows];
        int i = 0;
        foreach (Transform child in transform)
        {
            everyBlock[i] = child.gameObject;
            i++;
        }
        foreach (GameObject obj in everyBlock)
        {
            gridArray[obj.GetComponent<BlockStat>().x, obj.GetComponent<BlockStat>().y] = obj;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void SEMovement()
    //{
    //    if (charPosY + 1 < rows && gridArray[charPosX, charPosY + 1])
    //    {
    //        charPosY += 1;
    //    }

    //}
    //public void NWMovement()
    //{
    //    if (charPosY - 1 > -1 && gridArray[charPosX, charPosY - 1])
    //    {
    //        charPosY -= 1;

    //    }
    //}
    //public void SWMovement()
    //{
    //    if (charPosX + 1 < rows && gridArray[charPosX + 1, charPosY])
    //    {
    //        charPosX += 1;

    //    }
    //}
    //public void NEMovement()
    //{
    //    if (charPosX - 1 > -1 && gridArray[charPosX - 1, charPosY])
    //    {
    //        charPosX -= 1;
    //    }
    //}
}

