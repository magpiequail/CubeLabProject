using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Animator characterAnim;
    bool isInputAllowed = true;
    public bool isHavingRoundKey = false;
    public bool isHavingTriangleKey = false;
    public GameObject floor;

    public int rows = 5;

    public float speed;
    
    public Floor fl;
    private Door door;
    //public int charPosX = 2;
    //public int charPosY = 2;

    // Start is called before the first frame update
    void Start()
    {
        fl = floor.GetComponent<Floor>();
        door = GameObject.FindObjectOfType<Door>();
        characterAnim = GetComponentInChildren<Animator>();
        transform.position = fl.gridArray[fl.charPosX, fl.charPosY].transform.position;

        fl.gridArray[fl.charPosX, fl.charPosY].GetComponent<BlockStat>().currentBlock = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (door.isAllOpen)
        {
            isInputAllowed = false;
        }

        //transform.position = fl.gridArray[fl.charPosX, fl.charPosY].transform.position;
        transform.position = Vector3.MoveTowards(transform.position, fl.gridArray[fl.charPosX, fl.charPosY].transform.position, speed * Time.deltaTime);
        Vector3 dist = transform.position - fl.gridArray[fl.charPosX, fl.charPosY].transform.position;
        if (dist.sqrMagnitude < 0.1)
        {
            characterAnim.SetInteger("Idle", 1);
            isInputAllowed = true;
        }
        else
        {
            Debug.Log("false");
            isInputAllowed = false;
        }
        //for keyboard inputs
        if (isInputAllowed)
        {
            
            if (Input.GetKeyDown(KeyCode.A))
            {
                fl.SWMovement();
                //characterAnim.Play("Idle_SW");
                //characterAnim.SetTrigger("Jump");
                characterAnim.SetInteger("Direction", 3);
                characterAnim.Play("Walk");
            }

            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                fl.SEMovement();
                //characterAnim.Play("Idle_SE");
                //characterAnim.SetTrigger("Jump");
                characterAnim.SetInteger("Direction", 4);
                characterAnim.Play("Walk_SE");
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                fl.NWMovement();
                //characterAnim.Play("Idle_NW");
                //characterAnim.SetTrigger("Jump");
                characterAnim.SetInteger("Direction", 1);
                characterAnim.Play("Walk_NW");
            }
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.E))
            {
                fl.NEMovement();
                //characterAnim.Play("Idle_NE");
                //characterAnim.SetTrigger("Jump");
                characterAnim.SetInteger("Direction", 2);
                characterAnim.Play("Walk_NE");
            }
        }
        
        
    }


}
