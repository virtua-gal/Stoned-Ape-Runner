using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesManager : MonoBehaviour
{
    public static int lives = 3;
    public GameObject[] monkeyBust = new GameObject[lives];

    // Update is called once per frame
    void Update()
    {
        if(lives == 2)
        {
            monkeyBust[0].SetActive(false);
        }
        if(lives == 1)
        {
            monkeyBust[1].SetActive(false);
            monkeyBust[0].SetActive(false);
        }
        if(lives == 0)
        {
            monkeyBust[2].SetActive(false);
            monkeyBust[1].SetActive(false);
            monkeyBust[0].SetActive(false);
            StartCoroutine(RestartGame());
        }
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(3.5f);
        lives = 3;
        LevelManager.levelNumber = 1;
        SceneManager.LoadScene(1);
    }

    public void LoseLife()
    {
        lives--;
    }
}
