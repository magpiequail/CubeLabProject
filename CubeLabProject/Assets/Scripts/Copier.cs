using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copier : MonoBehaviour
{
    //float halfScreen;
    //public Camera leftCam;
    //public Camera rightCam;
    //Camera currentCam;
    //public bool isMouseOnCopier = false;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    halfScreen = Screen.width / 2;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        if (Input.mousePosition.x < halfScreen)
    //        {
    //            currentCam = leftCam;
    //        }
    //        else
    //        {
    //            currentCam = rightCam;
    //        }

    //        Vector3 worldPoint = currentCam.ScreenToWorldPoint(Input.mousePosition);
    //        RaycastHit2D hit = Physics2D.Raycast(worldPoint, transform.forward, 1000f);
    //        Debug.DrawRay(worldPoint, transform.forward * 10, Color.red);
    //        if (hit)
    //        {
    //            if (hit.collider.tag == "Copier")
    //            {
    //                isMouseOnCopier = true;
    //            }
    //            else
    //            {
    //                isMouseOnCopier = false;
    //            }
    //        }
    //        else
    //        {
    //            isMouseOnCopier = false;
    //        }
    //    }
    //}

}
