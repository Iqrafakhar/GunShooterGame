using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public float sensitivity = 2f;
    public float smothness = 0.5f;
    public float x_rotation, y_rotation;
    public float x, y;
    public float yRotationV, xRotationV;

    private void LateUpdate()
    {
        //Reading the values from mouse axis
        y_rotation += Input.GetAxis("Mouse X") * sensitivity;
        x_rotation += Input.GetAxis("Mouse Y") * sensitivity;
        //smooth damp moves values where we want it to be for the time period 
        x = Mathf.SmoothDamp(x, x_rotation, ref xRotationV, smothness);
        y = Mathf.SmoothDamp(y, y_rotation, ref yRotationV, smothness);
        //restricts the roation btw 80,-80
        x_rotation = Mathf.Clamp(xRotationV, -80, 80);
        //Settings the rotation of the campera according to mouse  
        transform.rotation = Quaternion.Euler(-x, y, 0);

    }
}
