using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastArrayBasedMovement : MonoBehaviour
{
    Animator characterAnim;
    public GameObject floor;
    public FloorGrid fl;
    public float speed;
    PresentArrayBasedMovement presentChar;

    public int charPosX;
    public int charPosY;

    // Start is called before the first frame update
    void Start()
    {
        fl = floor.GetComponent<FloorGrid>();
        characterAnim = GetComponentInChildren<Animator>();
        transform.position = fl.gridArray[charPosX, charPosY].transform.position;
        presentChar = FindObjectOfType<PresentArrayBasedMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, fl.gridArray[charPosX,charPosY].transform.position, speed * Time.deltaTime);
        Vector3 dist = transform.position - fl.gridArray[charPosX, charPosY].transform.position;
        if (dist.sqrMagnitude < 0.01)
        {
            characterAnim.SetInteger("Idle", 1);

        }
        else
        {
            //characterAnim.SetInteger("Idle", 0); //walk
        }


        if(Dimension.current == 1)
        {
            Join();
        }
        else
        {
            Separate();
        }

        //for keyboard inputs
            if (Input.GetKeyDown(KeyCode.A))
            {
                SWMovement();
                characterAnim.SetInteger("Direction", 3);
                characterAnim.Play("Walk_SW");
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                SEMovement();
                characterAnim.SetInteger("Direction", 4);
                characterAnim.Play("Walk_SE");
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                NWMovement();
                characterAnim.SetInteger("Direction", 1);
                characterAnim.Play("Walk_NW");
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                NEMovement();
                characterAnim.SetInteger("Direction", 2);
                characterAnim.Play("Walk_NE");
            }

    }

    void Join()
    {
        if (floor != presentChar.floor)
        {
            floor = presentChar.floor;
            fl = presentChar.fl;
            if (presentChar.charPosX - 1 > -1 /*&& presentChar.fl.gridArray[presentChar.charPosX-1,presentChar.charPosY]*/)
            { 
                charPosX = presentChar.charPosX -1;
            }
            else
            {
                charPosX = presentChar.charPosX + 1;
            }
            transform.position = fl.gridArray[charPosX, charPosY].transform.position;
        }
    }
    void Separate()
    {
        if (floor == presentChar.floor)
        {
            floor = presentChar.fl.matchingFloor;
            fl = floor.GetComponent<FloorGrid>();
            charPosX = presentChar.charPosX;
            charPosY = presentChar.charPosY;
            transform.position = fl.gridArray[charPosX, charPosY].transform.position;
        }
    }

    public void SEMovement()
    {
        if (charPosY + 1 < fl.rows && fl.gridArray[charPosX, charPosY + 1]
            && presentChar.charPosY + 1 < presentChar.fl.rows && presentChar.fl.gridArray[presentChar.charPosX, presentChar.charPosY + 1])
        {
            charPosY += 1;
        }

    }
    public void NWMovement()
    {
        if (charPosY - 1 > -1 && fl.gridArray[charPosX, charPosY - 1]
            && presentChar.charPosY - 1 > -1 && presentChar.fl.gridArray[presentChar.charPosX, presentChar.charPosY - 1])
        {
            charPosY -= 1;

        }
    }
    public void SWMovement()
    {
        if (charPosX + 1 < fl.rows && fl.gridArray[charPosX + 1, charPosY]
            && presentChar.charPosX + 1 < presentChar.fl.rows && presentChar.fl.gridArray[presentChar.charPosX + 1, presentChar.charPosY])
        {
            charPosX += 1;

        }
    }
    public void NEMovement()
    {
        if (charPosX - 1 > -1 && fl.gridArray[charPosX - 1, charPosY]
            && presentChar.charPosX - 1 > -1 && presentChar.fl.gridArray[presentChar.charPosX - 1, presentChar.charPosY])
        {
            charPosX -= 1;
        }
    }
}
