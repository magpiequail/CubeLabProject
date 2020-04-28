using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryInteraction : MonoBehaviour
{
    bool isCharOn = false;
    public static bool isInventoryPossible = false;
    public GameObject diarySprite;
    InventoryManager im;

    // Start is called before the first frame update
    void Start()
    {
        im = FindObjectOfType<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isCharOn && PastCharacterCollider.state ==0)
        {
            if (PastCharacterCollider.isSync && PastCharacterCollider.state == 0)
            {
                PastCharacterCollider.state = 1; //다이어리 발견
            }

        }
        if (Input.GetKey(KeyCode.Space) && isCharOn) //다이어리 획득하기
        {
            if(/*PastCharacterCollider.state == 2 || */PastCharacterCollider.state == 3)
            {

                diarySprite.SetActive(false);
                isInventoryPossible = true;
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
                im.ShowInventory();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Character")
        {
            isCharOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isCharOn = false;
    }

}
