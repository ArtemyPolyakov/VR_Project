using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorAnimation : MonoBehaviour
{
    public GameObject[] cylindres;
    public float RotationSpeed = 100.0f;

    void Update()
    {
        foreach (GameObject cylinder in cylindres)
        {
            cylinder.transform.Rotate(Vector3.right * RotationSpeed * Time.deltaTime);
        }
    }
}
