using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battery : MonoBehaviour
{
    //public static int firstBatt;
    //public static int secondBatt;
    //public static int thirdBatt;

    //public int totalMoves;
    public static int movesforEmotion;
    public static int movesforStageClear;
    public static int movesTillGameover;

    public GameObject firstBatt;
    public GameObject secondBatt;
    public GameObject thirdBatt;

    public Text first;
    public Text second;
    public Text third;

    SceneInfo s;

    private void Awake()
    {
        //totalMoves = s.firstBattery + s.secondBattery + s.thirdBattery;
        //movesforEmotion = s.firstBattery;
        //movesforStageClear = s.secondBattery;
        //movesTillGameover = s.thirdBattery;
        s = FindObjectOfType<SceneInfo>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //totalMoves = s.firstBattery + s.secondBattery + s.thirdBattery;
        movesforEmotion = s.firstBattery;
        movesforStageClear = s.secondBattery;
        movesTillGameover = s.thirdBattery;
    }

    // Update is called once per frame
    void Update()
    {
        first.text = "" + movesforEmotion;
        second.text = "" + movesforStageClear;
        third.text = "" + movesTillGameover;

        if(movesTillGameover == 0)
        {
            SceneController.gameState = GameState.GameOver;
        }

    }
    public void MinusOneMove()
    {
        //totalMoves -= 1;

        if(movesforEmotion != 0)
        {
            movesforEmotion -= 1;

        }
        if(movesforEmotion == 0 && movesforStageClear != 0)
        {
            movesforStageClear -= 1;
        }
        if(movesforEmotion ==0 && movesforStageClear == 0)
        {
            movesTillGameover -= 1;
        }
        //first.text = "" + movesforEmotion;
        //second.text = "" + movesforStageClear;
        //third.text = "" + movesTillGameover;
    }
}
