using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerControllerMario thePlayer;
    private Vector2 playerStart;
    public GameObject victoryScreen;
    public GameObject gameOverScreen;
    public string mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        playerStart = thePlayer.transform.position;
    }

    public void Victory()
    {
        victoryScreen.SetActive(true);
        thePlayer.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        thePlayer.gameObject.SetActive(false);
    }

    IEnumerator GameReset()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(mainMenu);
    }

    public void Reset()
    {
        gameOverScreen.SetActive(false);
        victoryScreen.SetActive(false);
        thePlayer.gameObject.SetActive(true);
        thePlayer.transform.position = playerStart;
    }
}
