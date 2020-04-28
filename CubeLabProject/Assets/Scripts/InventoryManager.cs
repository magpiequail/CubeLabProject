using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryManager : MonoBehaviour
{
    bool isInventoryOn = false;
    GameObject[] inventories;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (DiaryInteraction.isInventoryPossible)
        {
            if (Input.GetKeyDown(KeyCode.I) && !isInventoryOn)
            {
                ShowInventory();
            }
            else if (Input.GetKeyDown(KeyCode.I) && isInventoryOn)
            {

                CloseInventory();
            }
        }
        
    }

    private void Initialize()
    {
        inventories = new GameObject[transform.childCount];
        int i = 0;
        foreach (Transform child in gameObject.transform)
        {
            inventories[i] = child.gameObject;
            i++;
        }
        foreach(GameObject obj in inventories)
        {
            obj.SetActive(false);
        }
    }
    public void ShowInventory()
    {
        foreach (GameObject obj in inventories)
        {

            obj.SetActive(true);
        }
        isInventoryOn = true;
    }
    public void CloseInventory()
    {
        foreach (GameObject obj in inventories)
        {
            obj.SetActive(false);
        }
        isInventoryOn = false;
    }


}
