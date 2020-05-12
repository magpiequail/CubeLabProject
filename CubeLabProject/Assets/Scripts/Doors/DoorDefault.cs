using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDefault : Door
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
            Debug.Log("door is open");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Character")
        {
            Debug.Log("collision");
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

    //protected override void OnTriggerEnter2D(Collider2D collision)
    //{
    //    base.OnTriggerEnter2D(collision);
    //    if (collision.tag == "Character")
    //    {
    //        Debug.Log("collision");
    //        isOpened = true;
    //    }
    //}

    //protected override void OnTriggerExit2D(Collider2D collision)
    //{
    //    base.OnTriggerExit2D(collision);
    //    //    if (collision.tag == "Character")
    //    //    {
    //    //        isOpened = false;
    //    //    }
    //}

}
