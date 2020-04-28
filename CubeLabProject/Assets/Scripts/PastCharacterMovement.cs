using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PastCharacterMovement : MonoBehaviour
{
    Vector2 nextPos;
    Grid grid;
    float gridX;
    float gridY;
    Vector2 currPos;
    public float speed;

    public LayerMask accessible;
    public Animator charAnim;
    //public Animator footAnim;
    bool isMovable;

    private void Awake()
    {
        grid = FindObjectOfType<Grid>();
        gridX = grid.cellSize.x / 2;
        gridY = grid.cellSize.y / 2;

        currPos = transform.position;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        nextPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircle(nextPos, 0.1f, accessible))
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        }
        if (Vector3.Distance(transform.position, nextPos) < 0.01f)
        {
            currPos = nextPos;
        }


        if (Input.GetKeyDown(KeyCode.A))
        {
            SWMovement();
            //footAnim.Play("Foot_SW");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            SEMovement();
            //footAnim.Play("Foot_SE");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            NWMovement();
            //footAnim.Play("Foot_NW");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            NEMovement();
            //footAnim.Play("Foot_NE");
        }
    }

    public void SEMovement()
    {
        
        nextPos = new Vector2(currPos.x + gridX, currPos.y - gridY);
        if (!Physics2D.OverlapCircle(nextPos,0.1f,accessible))
        {
            nextPos = currPos;
        }
        charAnim.SetInteger("Direction", 4);

    }
    public void NWMovement()
    {
        nextPos = new Vector2(currPos.x - gridX, currPos.y + gridY);
        if (!Physics2D.OverlapCircle(nextPos, 0.1f, accessible))
        {
            nextPos = currPos;
        }
        charAnim.SetInteger("Direction", 1);

    }
    public void SWMovement()
    {
        nextPos = new Vector2(currPos.x - gridX, currPos.y - gridY);
        if (!Physics2D.OverlapCircle(nextPos, 0.1f, accessible))
        {
            nextPos = currPos;
        }
        charAnim.SetInteger("Direction", 3);

    }
    public void NEMovement()
    {
        nextPos = new Vector2(currPos.x + gridX, currPos.y + gridY);
        if (!Physics2D.OverlapCircle(nextPos, 0.1f, accessible))
        {
            nextPos = currPos;
        }
        charAnim.SetInteger("Direction", 2);

    }


}
