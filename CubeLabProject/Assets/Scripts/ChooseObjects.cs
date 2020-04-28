using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseObjects : MonoBehaviour
{
    GameObject[] childObj;
    public GameObject monologue;

    // Start is called before the first frame update
    void Start()
    {
        childObj = new GameObject[transform.childCount];
        int i = 0;
        foreach(Transform child in transform)
        {
            childObj[i] = child.gameObject;
            i++;
            child.gameObject.SetActive(false);
        }
        monologue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isChildrenActive()&&PastCharacterCollider.state == 10)
        {
            monologue.SetActive(true);
            PastCharacterCollider.state = 2;
            
        }
        if(PastCharacterCollider.state == 3)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            monologue.SetActive(false);
        }
        

    }

    private bool isChildrenActive()
    {
        for(int i = 0; i<childObj.Length; i++)
        {
            if (childObj[i].activeSelf == false)
            {
                return false;
            }
        }

        return true;
    }
}
