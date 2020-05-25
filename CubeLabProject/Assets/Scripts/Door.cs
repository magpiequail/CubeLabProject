using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door :MonoBehaviour
{
    public float delayTillDoorOpen = 1.0f;
    public float delayTillStageClear=2.0f;
    public float delayTillNextStage = 1.5f;

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

    protected virtual void PlayOpenAnim()
    {

    }

    
    IEnumerator Open()
    {
        if (IsAllDoorsOpen() == true)
        {
            isAllOpen = true;


            yield return new WaitForSeconds(delayTillDoorOpen);
            foreach(Door doors in doorsArray)
            {
                doors.PlayOpenAnim();
            }

            yield return new WaitForSeconds(delayTillStageClear);
            text.SetActive(true);

            yield return new WaitForSeconds(delayTillNextStage);


            Rate();
            isAllOpen = false;
            if (SceneManager.GetActiveScene().buildIndex == 6)
            {
                SceneManager.LoadScene("Lobby");
            }

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
        }
    }
    public void Rate()
    {
        if(PlayerPrefs.GetInt(""+ SceneManager.GetActiveScene().buildIndex+"stars") < Battery.stars)
        {
            PlayerPrefs.SetInt("" + SceneManager.GetActiveScene().buildIndex + "stars", Battery.stars);
        }
        
    }
}
