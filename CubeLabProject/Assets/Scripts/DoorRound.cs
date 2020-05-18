using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRound : Door
{


    private void Awake()
    {
        isOpened = false;

    }

// Start is called before the first frame update
void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isOpened == true)
        {
            Debug.Log("round door is open");
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Character" && collision.GetComponentInParent<CharacterMovement>().isHavingRoundKey)
        {
            isOpened = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Character")
        {
            isOpened = false;

        }
    }

}
