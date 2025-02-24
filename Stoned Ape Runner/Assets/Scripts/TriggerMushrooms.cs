using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMushrooms : MonoBehaviour
{
    public GameObject[] mushrooms;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(GrowMushrooms());
        }
    }

    IEnumerator GrowMushrooms()
    {
        for(int i = 0; i < mushrooms.Length; i++)
        {
            mushrooms[i].SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
