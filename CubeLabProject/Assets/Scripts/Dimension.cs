using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dimension : MonoBehaviour
{
    public static int current = 0;
    //0은 싱크, 1은 분리
    public float timer = 0f;
    private bool isInputAllowed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            timer = 0f;
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            timer += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            Debug.Log(timer);
        }
        if (timer > 2.0f)
        {
            timer = 0f;
            if(current == 0)
            {
                current = 1;
            }
            else
            {
                current = 0;
            }
        }
    }
}
