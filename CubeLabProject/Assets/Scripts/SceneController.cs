using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Running,
    Paused,
    GameOver
}

public class SceneController : MonoBehaviour
{
    public static GameState gameState = GameState.Running;
    public GameObject gameOver;

    

    private void Awake()
    {
        gameOver = GameObject.FindGameObjectWithTag("Game Over");
        gameOver.SetActive(false);
        gameState = GameState.Running;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameState == GameState.GameOver)
        {
            Time.timeScale = 0f;
            gameOver.SetActive(true);
        }
    }
    public void BackToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

}
