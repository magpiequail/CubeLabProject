using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentArrayBasedMovement : MonoBehaviour
{
    Animator characterAnim;
    public GameObject floor;
    public FloorGrid fl;
    public float speed;

    public int charPosX;
    public int charPosY;

    PastArrayBasedMovement pastChar;

    // Start is called before the first frame update
    void Start()
    {
        fl = floor.GetComponent<FloorGrid>();
        characterAnim = GetComponentInChildren<Animator>();
        transform.position = fl.gridArray[charPosX, charPosY].transform.position;
        pastChar = FindObjectOfType<PastArrayBasedMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, fl.gridArray[charPosX, charPosY].transform.position, speed * Time.deltaTime);
        Vector3 dist = transform.position - fl.gridArray[charPosX, charPosY].transform.position;
        if (dist.sqrMagnitude < 0.01)
        {
            characterAnim.SetInteger("Idle", 1);

        }
        else
        {
            //characterAnim.SetInteger("Idle", 0); //walk
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
    public void SEMovement()
    {
        if (charPosY + 1 < fl.rows && fl.gridArray[charPosX, charPosY + 1]
            && pastChar.charPosY + 1 < pastChar.fl.rows && pastChar.fl.gridArray[pastChar.charPosX, pastChar.charPosY + 1])
        {
            charPosY += 1;
        }

    }
    public void NWMovement()
    {
        if (charPosY - 1 > -1 && fl.gridArray[charPosX, charPosY - 1]
            && pastChar.charPosY - 1 > -1 && pastChar.fl.gridArray[pastChar.charPosX, pastChar.charPosY - 1])
        {
            charPosY -= 1;

        }
    }
    public void SWMovement()
    {
        if (charPosX + 1 < fl.rows && fl.gridArray[charPosX + 1, charPosY]
            && pastChar.charPosX + 1 < pastChar.fl.rows && pastChar.fl.gridArray[pastChar.charPosX + 1, pastChar.charPosY])
        {
            charPosX += 1;

        }
    }
    public void NEMovement()
    {
        if (charPosX - 1 > -1 && fl.gridArray[charPosX - 1, charPosY]
            && pastChar.charPosX - 1 > -1 && pastChar.fl.gridArray[pastChar.charPosX - 1, pastChar.charPosY])
        {
            charPosX -= 1;
        }
    }
}
