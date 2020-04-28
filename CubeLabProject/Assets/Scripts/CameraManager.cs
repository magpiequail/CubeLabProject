using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    float halfScreen;
    public Camera leftCam;
    public Camera rightCam;
    Camera currentCam;
    
    public bool isMouseOnCopier = false;
    public bool isMouseOnSafe = false;


    // Start is called before the first frame update
    void Start()
    {
        halfScreen = Screen.width / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetMouseButton(0))
        {
            DetectCurrentCamera();

            Vector3 worldPoint = currentCam.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, transform.forward, 1000f);
            Debug.DrawRay(worldPoint, transform.forward * 10, Color.red);
            if (hit)
            {
                if (hit.collider.tag == "Copier")
                {
                    isMouseOnCopier = true;
                    isMouseOnSafe = false;
                }
                else if(hit.collider.tag == "Safe")
                {
                    isMouseOnCopier = false;
                    isMouseOnSafe = true;
                }
            }
            else
            {
                isMouseOnCopier = false;
                isMouseOnSafe = false;
            }
        }


        if(Dimension.current == 0)
        {
            leftCam.rect = new Rect(0.0f, 0.0f, 0.5f, 1.0f);
            rightCam.rect = new Rect(0.5f, 0.0f, 0.5f, 1.0f);
        }
        if(Dimension.current == 1)
        {
            rightCam.rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
            leftCam.rect = new Rect(0.0f, 0.0f, 0.0f, 1.0f);
        }
        
    }
    private void DetectCurrentCamera()
    {
        if (Input.mousePosition.x < halfScreen)
        {
            currentCam = leftCam;
        }
        else
        {
            currentCam = rightCam;
        }
    }
    
}
