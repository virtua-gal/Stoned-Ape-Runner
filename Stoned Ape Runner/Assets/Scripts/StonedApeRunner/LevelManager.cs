using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    Vector3 startPos;
    Quaternion startRot;
    public Slider healthBar;
    public AudioSource victoryMusic;
    public GameObject screenFade;
    public HealthManager healthManager;
    public static int levelNumber = 1;
    public int numLevels = 3;

    public CameraChanger cameraChanger;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
        HealthManager.subtractHealth = true;
        screenFade.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Respawn")
        {
            StartCoroutine(Respawn());
            StartCoroutine(ResetHealth());

        }
        else if(other.tag == "Checkpoint")
        {   
            startPos = other.transform.position;
            startRot = other.transform.rotation;
            Destroy(other.gameObject);
        }
        else if(other.tag == "Goal")
        {
            Destroy(other.gameObject);
            StartCoroutine(Goal());
            if(levelNumber == 3)
            {
                victoryMusic.Play();
            }
        }
    }

    IEnumerator Respawn()
    {
        GetComponent<AudioSource>().Play();
        LivesManager.lives--;
        yield return new WaitForSeconds(2f);
        DisableCharacter();
        transform.position = startPos;
        transform.rotation = startRot;
        GetComponent<Animator>().Play("LOSE00");
        yield return new WaitForSeconds(3.5f);
        EnableCharacter();
    }

    public void PlayerReborn()
    {
        HealthManager.health = 0;
        healthBar.value = HealthManager.health;
        GetComponent<Animator>().Play("DAMAGED01");
    }

    IEnumerator ResetHealth()
    {
        HealthManager.subtractHealth = false;
        HealthManager.health = 100;
        yield return new WaitForSeconds(4f);
        HealthManager.health = 100;
        healthManager.healthBar.value = HealthManager.health;
        yield return new WaitForSeconds(2f);
        HealthManager.subtractHealth = true;
        EnableCharacter();
    }

    IEnumerator Goal()
    {
        HealthManager.subtractHealth = false;
        yield return new WaitForSeconds(0.25f);
        cameraChanger.enabled = true;
        yield return new WaitForSeconds(0.15f);
        screenFade.SetActive(true);
        DisableCharacter();
        GetComponent<Animator>().Play("WIN00");
        yield return new WaitForSeconds(3.5f);
        EnableCharacter();
        NextLevel();
    }

    public void DisableCharacter()
    {
        GetComponent<CharacterController>().enabled = false;
        GetComponent<ThirdPersonController>().enabled = false;
    }

    public void EnableCharacter()
    {
        GetComponent<CharacterController>().enabled = true;
        GetComponent<ThirdPersonController>().enabled = true;
    }

    void NextLevel()
    {
        levelNumber++;

        if(levelNumber == numLevels)
        {
            levelNumber = 1;
        }

        SceneManager.LoadScene(levelNumber);
    }
}
