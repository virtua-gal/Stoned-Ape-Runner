using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float yRotationSpeed = 1;
    void FixedUpdate()
    {
        transform.Rotate(0, yRotationSpeed, 0, Space.World);
    }
}
