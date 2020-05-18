using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door :MonoBehaviour
{
    public float delaySeconds = 1.5f;

    public bool isOpened = true;
    protected bool isHavingKey;
    private GameObject text;
    Door[] doorsArray;
    public static bool isAllOpen = false;


    private void Awake()
    {
        text = GameObject.Find("StageClear");

    }

    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
        doorsArray = GameObject.FindObjectsOfType<Door>();
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(Open());
    }

    private bool IsAllDoorsOpen()
    {
        for (int i = 0; i < doorsArray.Length; ++i)
        {
            if (doorsArray[i].isOpened == false)
            {
                return false;
            }
        }
        return true;
    }
    //protected virtual void OnTriggerEnter2D(Collider2D collision)
    //{
        
    //}

    //protected virtual void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "Character")
    //    {
    //        Debug.Log("triggerexit");
    //        isOpened = false;
    //    }
    //}
    IEnumerator Open()
    {
        if (IsAllDoorsOpen() == true)
        {
            isAllOpen = true;


            yield return new WaitForSeconds(delaySeconds);
            
            text.SetActive(true);

            yield return new WaitForSeconds(1);
            isAllOpen = false;
            if (SceneManager.GetActiveScene().buildIndex == 6)
            {
                Application.Quit();
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
        }
    }
}
