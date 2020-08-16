using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 offset;

    void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;   
        offset = transform.position - lookAt.position;
    }

    void Update()
    {
        transform.position = lookAt.position + offset;
    }
}
