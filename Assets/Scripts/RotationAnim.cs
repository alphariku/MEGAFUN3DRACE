using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAnim : MonoBehaviour
{
    float time = 0;
    [SerializeField] Vector3 rotationSpeed;
    [SerializeField] float rotationArea = 1;
    [SerializeField] bool sinX;
    [SerializeField] bool sinY;
    [SerializeField] bool sinZ;
    
    void Update()
    {
        time += Time.deltaTime; 
        float x = sinX ? rotationArea * Mathf.Sin(rotationSpeed.x * time * rotationArea) : rotationArea * Mathf.Cos(rotationSpeed.x * time* rotationArea);
        float y = sinY ? rotationArea * Mathf.Sin(rotationSpeed.y * time* rotationArea) : rotationArea * Mathf.Cos(rotationSpeed.y * time * rotationArea);
        float z = sinZ ? rotationArea * Mathf.Sin(rotationSpeed.z * time* rotationArea) : rotationArea * Mathf.Cos(rotationSpeed.z * time* rotationArea);

        transform.localPosition = new Vector3(x,y,z);
        
    }
}
