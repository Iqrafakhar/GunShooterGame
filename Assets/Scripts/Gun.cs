using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject camera;
    float targetxrotation, targetyrotation;
    float targetxrotationV, targetyrotationV;

    public GameObject shell;
    public Transform shellSpawnPos, bulletSpawnPos;
    public float rotateSpeed = 0.3f, holdHeight = -0.5f, holdSide = 0.5f;
    // Update is called once per frame
    void Update()
    {
        shoot();

        targetxrotation = Mathf.SmoothDamp(targetxrotation, FindObjectOfType<MouseController>().x_rotation, ref targetxrotationV, rotateSpeed);
        targetxrotation = Mathf.SmoothDamp(targetyrotation, FindObjectOfType<MouseController>().y_rotation, ref targetyrotationV, rotateSpeed);

        transform.position = camera.transform.position + Quaternion.Euler(0, targetyrotation, 0) * new Vector3(holdSide, holdHeight, 0);

        float clampedx = Mathf.Clamp(targetxrotation, -70, 80);
        transform.rotation = Quaternion.Euler(-clampedx, targetyrotation, rotateSpeed);

    }

    void shoot()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
        else if(Input.GetButton("Fire1"))
        {
            Fire();
        }
    }

    void Fire()
    {
        GameObject shellcopy = Instantiate<GameObject>(shell, shellSpawnPos.position, Quaternion.identity) as GameObject;
        RaycastHit variable;
        bool status = Physics.Raycast(bulletSpawnPos.position, bulletSpawnPos.forward, out variable, 100);
        
        if(status)
        {
            Debug.Log(variable.collider.gameObject.name);
        }
    }



}
