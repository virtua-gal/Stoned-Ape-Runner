using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    //Camera Switcher for any number of cameras, be sure to adjust number of cameras in Update.
    public GameObject[] cam;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            cam[0].SetActive(true);
            cam[1].SetActive(false);
            cam[2].SetActive(false);
            cam[3].SetActive(false); 
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            cam[0].SetActive(false);
            cam[1].SetActive(true);
            cam[2].SetActive(false);
            cam[3].SetActive(false);     
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            cam[0].SetActive(false);
            cam[1].SetActive(false);
            cam[2].SetActive(true);
            cam[3].SetActive(false);    
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            cam[0].SetActive(false);
            cam[1].SetActive(false);
            cam[2].SetActive(false);
            cam[3].SetActive(true);    
        }
    }
}
