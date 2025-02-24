using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXOnTrigger : MonoBehaviour
{
    public GameObject vfxPrefab;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Instantiate(vfxPrefab, this.transform.position, this.transform.rotation);
        }
    }
}
