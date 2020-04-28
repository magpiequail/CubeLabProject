using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastCharacterCollider : MonoBehaviour
{
    public GameObject footprint;
    public GameObject blur;

    public static bool isSync = false;
    public static int state = 0;

    public GameObject comBlur;
    public GameObject comOpt;
    public GameObject laptopBlur;
    public GameObject laptopOpt;
    public GameObject copierBlur;
    public GameObject copierOpt;

    public GameObject mission;

    public GameObject first;
    public GameObject second;
    public GameObject third;
    public GameObject fourth;
    public GameObject fifth;

    public GameObject livingroom;
    public GameObject room1;
    public GameObject room2;

    public Cinemachine.CinemachineVirtualCamera cam;

    public GameObject tutor1;
    public GameObject tutor2;
    public GameObject tutor3;
    public GameObject tutor4;
    public GameObject tutor5;

    bool isCom = false;
    bool isCopier = false;
    bool isLaptop = false;
    bool isCopierSelected = false;
    bool isSafeSelected = false;

    //Color room1Color;
    //Color room2Color;
    //Color livingroomColor;

    SpriteRenderer room1Sprite;
    SpriteRenderer room2Sprite;
    SpriteRenderer livingroomSprite;
    //0은 싱크만 된 상태
    //1은 다이어리를 발견한 상태
    //10은 상호작용 가능한 오브젝트를 처음 발견한 상태
    //2는 상호작용 가능한 오브젝트들을 발견한 상태
    //3은 복사기를 선택한 상태
    //4는 다이어리를 복사한 상태
    //5는 금고를 발견한 상태
    int whichRoom = 0;
    //0은 거실, 1은 위쪽 방, 2는 아래쪽 방 

    // Start is called before the first frame update
    void Start()
    {
        first.SetActive(false);
        second.SetActive(false);
        third.SetActive(false);
        fourth.SetActive(false);
        fifth.SetActive(false);
        comBlur.SetActive(false);
        comOpt.SetActive(false);
        laptopBlur.SetActive(false);
        laptopOpt.SetActive(false);
        copierBlur.SetActive(false);
        copierOpt.SetActive(false);

        mission.SetActive(false);

        
        tutor3.SetActive(false);
        tutor4.SetActive(false);
        tutor5.SetActive(false);

        //room1Color = room1.GetComponent<SpriteRenderer>().color;
        //room2Color = room2.GetComponent<SpriteRenderer>().color;
        //livingroomColor = livingroom.GetComponent<SpriteRenderer>().color;
        room1Sprite = room1.GetComponent<SpriteRenderer>();
        room2Sprite = room2.GetComponent<SpriteRenderer>();
        livingroomSprite = livingroom.GetComponent<SpriteRenderer>();

        room1Sprite.enabled = false;
        room2Sprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("state = " + state);
        if (isSync && state == 0)
        {
            first.SetActive(true);
        }
        if (isSync)
        {
            tutor1.SetActive(false);
            tutor2.SetActive(false);
        }
        if(state == 1)
        {
            tutor3.SetActive(false);
            first.SetActive(false);
            second.SetActive(true);
        }
        if(state == 10)
        {
            second.SetActive(false);
        }

        if(state == 4)
        {
            mission.SetActive(false);
            third.SetActive(true);
            tutor5.SetActive(false);
        }
        if(state == 6)
        {
            fourth.SetActive(false);
            fifth.SetActive(true);
        }
        if (DiaryInteraction.isInventoryPossible)
        {
            tutor4.SetActive(false);
            tutor5.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isCom)
            {
                comBlur.SetActive(true);
                comOpt.SetActive(true);
                state = 10;
            }
            if (isCopier)
            {
                copierBlur.SetActive(true);
                copierOpt.SetActive(true);
                state = 10;
            }
            if (isLaptop)
            {
                laptopBlur.SetActive(true);
                laptopOpt.SetActive(true);
                state = 10;
            }
            if (isCopierSelected)
            {
                state = 3;
                laptopBlur.SetActive(false);
                copierBlur.SetActive(false);
                comBlur.SetActive(false);
                mission.SetActive(true);
                tutor4.SetActive(true);
            }
            if (isSafeSelected)
            {
                third.SetActive(false);
                fourth.SetActive(true);
                state = 5;
            }
        }
        
    }

    IEnumerator ShowConvo()
    {
        first.SetActive(true);
        yield return new WaitForSeconds(5);
        first.SetActive(false);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("collision with character");
        if(collision.gameObject.name == "zansang")
        {
            footprint.SetActive(false);
            blur.SetActive(false);
            isSync = true;
        }
        if(state == 1 || state == 10)
        {
            if (collision.gameObject.name == "Computer")
            {
                isCom = true;
            }
            if(collision.gameObject.name == "Laptop")
            {
                isLaptop = true;
            }
            if (collision.gameObject.name == "Copier")
            {
                isCopier = true;
            }
        }
        if (state == 4 && collision.tag == "Safe")
        {
            Debug.Log("collision with safe");
            isSafeSelected = true;
        }
        
        //if (collision.tag == "To Room1")
        //{
        //    if (whichRoom == 0)
        //    {
        //        cam.Follow = room1.transform;
        //    }

        //}
        //if (collision.tag == "To Room2")
        //{
        //    if (whichRoom == 0)
        //    {
        //        cam.Follow = room2.transform;
        //    }
        //}
        //if (collision.tag == "Room1")
        //{
        //    if (whichRoom == 1)
        //    {
        //        cam.Follow = transform.parent.transform;
        //    }
        //}
        //if (collision.tag == "Room2")
        //{
        //    if (whichRoom == 2)
        //    {
        //        cam.Follow = transform.parent.transform;
        //    }
        //}

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(state == 2 && collision.name == "Copier")
        {
            isCopierSelected = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Computer")
            {
                isCom = false;
            }
            if (collision.gameObject.name == "Laptop")
            {
                isLaptop = false;
            }
            if (collision.gameObject.name == "Copier")
            {
                isCopier = false;
            }
        if (collision.gameObject.name == "Copier")
        {
            isCopierSelected = false;
        }
        if (collision.gameObject.name == "Safe")
        {
            isSafeSelected = false;
        }
        //if (collision.tag == "To Room1")
        //{
        //    cam.Follow = transform.parent.transform;

        //}
        //if (collision.tag == "To Room2")
        //{
        //    cam.Follow = transform.parent.transform;
        //}
        //if (collision.tag == "Room1")
        //{
        //    if(whichRoom == 1)
        //    {
        //        cam.Follow = room1.transform;
        //    }

        //}
        //if (collision.tag == "Room2")
        //{
        //    if (whichRoom == 2)
        //    {
        //        cam.Follow = room2.transform;
        //    }

        //}
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Room1")
        {
            cam.Follow = room1.transform;
            room1Sprite.enabled = true;
            room2Sprite.enabled = false;
            livingroomSprite.enabled = false;
        }
        if (collision.collider.tag == "Room2")
        {
            cam.Follow = room2.transform;
            room1Sprite.enabled = false;
            room2Sprite.enabled = true;
            livingroomSprite.enabled = false;
        }
        if (collision.collider.tag == "Living Room")
        {
            cam.Follow = transform.parent.transform;
            room1Sprite.enabled = false;
            room2Sprite.enabled = false;
            livingroomSprite.enabled = true;
        }
    }
}
