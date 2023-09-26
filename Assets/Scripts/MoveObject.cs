using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    [SerializeField] private bool xAxis;
    [SerializeField] private bool yAxis;
    [SerializeField] private bool zAxis;
    [Range(10f, 200f)]
    [SerializeField] private float rotSpeed = 60f;

    void Update()
    {
        if(xAxis) transform.Rotate(rotSpeed*Time.deltaTime,0,0);
        if(yAxis) transform.Rotate(0,rotSpeed*Time.deltaTime,0);
        if(zAxis) transform.Rotate(0,0,rotSpeed*Time.deltaTime);
    }
}
