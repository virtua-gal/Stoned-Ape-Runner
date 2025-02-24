using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    public float waitTime = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CameraSwitch());
    }

    public IEnumerator CameraSwitch()
    {
        yield return new WaitForSeconds(waitTime);
        cam1.enabled = false;
        cam2.enabled = true;
    }
}
