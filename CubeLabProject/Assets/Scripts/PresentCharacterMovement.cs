using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentCharacterMovement : MonoBehaviour
{
    Vector2 nextPos;
    Grid grid;
    float gridX;
    float gridY;
    Vector2 currPos;
    public float speed;

    public LayerMask accessible;
    Animator anim;
    bool isMovable;

    private void Awake()
    {
        grid = FindObjectOfType<Grid>();
        gridX = grid.cellSize.x / 2;
        gridY = grid.cellSize.y / 2;

        currPos = transform.position;
        anim = GetComponentInChildren<Animator>();
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

        //Debug.Log("currpos = " + currPos + "nextpos = " + nextPos);


        if (!PastCharacterCollider.isSync)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                SWMovement();
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                SEMovement();
            }

            if (Input.GetKeyDown(KeyCode.U))
            {
                NWMovement();
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                NEMovement();
            }
        }
        else if (PastCharacterCollider.isSync)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                SWMovement();
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                SEMovement();
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                NWMovement();
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                NEMovement();
            }
        }
        

    }

    public void SEMovement()
    {

        nextPos = new Vector2(currPos.x + gridX, currPos.y - gridY);
        if (!Physics2D.OverlapCircle(nextPos, 0.1f, accessible))
        {
            nextPos = currPos;
        }
        anim.SetInteger("Direction", 4);

    }
    public void NWMovement()
    {
        nextPos = new Vector2(currPos.x - gridX, currPos.y + gridY);
        if (!Physics2D.OverlapCircle(nextPos, 0.1f, accessible))
        {
            nextPos = currPos;
        }
        anim.SetInteger("Direction", 1);

    }
    public void SWMovement()
    {

        nextPos = new Vector2(currPos.x - gridX, currPos.y - gridY);
        if (!Physics2D.OverlapCircle(nextPos, 0.1f, accessible))
        {
            nextPos = currPos;
        }
        anim.SetInteger("Direction", 3);

    }
    public void NEMovement()
    {
        nextPos = new Vector2(currPos.x + gridX, currPos.y + gridY);
        if (!Physics2D.OverlapCircle(nextPos, 0.1f, accessible))
        {
            nextPos = currPos;
        }
        anim.SetInteger("Direction", 2);

    }
}
