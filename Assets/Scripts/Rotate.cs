using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Rotate : MonoBehaviour {

    private float speedd = 200f;


    void Update()
    {
        transform.Rotate(0f, speedd * Time.deltaTime, 0f, Space.Self);
    }
}