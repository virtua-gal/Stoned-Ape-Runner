using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HealthManager : MonoBehaviour
{
    public Slider healthBar;
    public GameObject screenFade;
    public static int health;
    public UnityEvent loseLife;
    public AudioSource pickUpSound;
    public AudioClip[] pickUpClip;
    public LevelManager levelManager;
    public static bool subtractHealth;

    // Start is called before the first frame update
    void Start()
    {
        subtractHealth = true;
        health = 100;
        InvokeRepeating("SubtractHealth", 3, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            levelManager.PlayerReborn();
            StartCoroutine(ResetHealth());
            loseLife.Invoke();
        }
    }

    void SubtractHealth()
    {
        if(subtractHealth)
        {
            health -= 20;
            health = Mathf.Clamp(health, 0, 100);
            healthBar.value = health;
        }  
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "YellowShroom")
        {
            pickUpSound.clip = pickUpClip[Random.Range(2,3)];
            pickUpSound.Play();
            health += 20;
            health = Mathf.Clamp(health, 0, 100);
            healthBar.value = health;
            Destroy(other.gameObject);
        }
        if(other.tag == "BlueShroom")
        {
            pickUpSound.clip = pickUpClip[1];
            pickUpSound.Play();
            health += 5;
            health = Mathf.Clamp(health, 0, 100);
            healthBar.value = health;
            Destroy(other.gameObject);
        }
        if(other.tag == "RedShroom")
        {
            pickUpSound.clip = pickUpClip[0];
            pickUpSound.Play();
            health -= 100;
            health = Mathf.Clamp(health, 0, 100);
            healthBar.value = health;
            Destroy(other.gameObject);
        }
    }

    IEnumerator ResetHealth()
    {
        subtractHealth = false;
        health = 100;
        screenFade.SetActive(true);
        yield return new WaitForSeconds(3f);
        screenFade.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        health = 100;
        healthBar.value = health;
        subtractHealth = true;
        levelManager.EnableCharacter();
    }
}
