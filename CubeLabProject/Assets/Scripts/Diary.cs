using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Diary : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    //Vector3 originalPos;
    bool isMouseButtonDown = false;
    public GameObject tooltip;
    public GameObject copiedDiary;
    GameObject instantiated;
    RectTransform rt;

    bool isTooltip = true;

    CameraManager cm;

    private void Awake()
    {
        //originalPos = Vector3.zero;
        rt = GetComponent<RectTransform>();
        cm = FindObjectOfType<CameraManager>();
        copiedDiary.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMouseButtonDown)
        {
            transform.position = Input.mousePosition;
        }


    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isTooltip)
        {
            instantiated = Instantiate(tooltip, Input.mousePosition, Quaternion.identity);
            instantiated.transform.SetParent(GameObject.Find("Canvas").transform);
        }
        
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (instantiated)
        {
            Destroy(instantiated);
        }
        
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        isMouseButtonDown = true;
        isTooltip = false;
        if (instantiated)
        {
            Destroy(instantiated);
        }
        
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        isTooltip = true;
        isMouseButtonDown = false;
        rt.anchoredPosition = Vector3.zero;
        if (cm.isMouseOnCopier)
        {
            copiedDiary.SetActive(true);
            PastCharacterCollider.state = 4;
        }
        else if (cm.isMouseOnSafe)
        {
            rt.anchoredPosition = new Vector2(rt.anchoredPosition.x + 1400, rt.anchoredPosition.y);
            PastCharacterCollider.state = 6;
        }
        
    }



}
