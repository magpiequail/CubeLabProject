using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    GameObject gameOverUI;
    public float delayTillGameOver;
    public float delayTillUI;
    bool isGameOver = false;
    

    private void Awake()
    {
        gameOver = GameObject.FindGameObjectWithTag("Game Over");
        gameOverUI = gameOver.GetComponentInChildren<Button>().transform.parent.gameObject;
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
        if(gameState == GameState.GameOver && !isGameOver )
        {
            StartCoroutine(GameOver());
        }
    }
    public void BackToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(delayTillGameOver);
        //
        gameOver.SetActive(true);
        gameOverUI.SetActive(false);
        yield return new WaitForSeconds(delayTillUI);
        gameOverUI.SetActive(true);
        isGameOver = true;
        Time.timeScale = 0f;
    }
}
