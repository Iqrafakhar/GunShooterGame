using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject cameraObject;
    public float accelration;
    public float walkAccelrationRatio;

    public float maxWalkSpeed;
    public float deaccelrate = 2;
    public Vector2 horizontalmovement;

    public float walkDeaccelratex;
    public float walkDeaccelratez;

    public bool isGround = true;
    Rigidbody playerRigidBody;
    public float jumpVelocity = 20;
    float maxSlope = 45;

    private void Awake()
    {

        playerRigidBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        jump();
        Move();
    }

    void jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            playerRigidBody.AddForce(0, jumpVelocity, 0);
        }
    }

    private void Move()
    {
        horizontalmovement = new Vector2(playerRigidBody.velocity.x, playerRigidBody.velocity.z);
        if(horizontalmovement.magnitude > maxWalkSpeed)
        {
            horizontalmovement = horizontalmovement.normalized;
            horizontalmovement *= maxWalkSpeed;
        }

        //controlling the x and z speed
        playerRigidBody.velocity = new Vector3(horizontalmovement.x, playerRigidBody.velocity.y, horizontalmovement.y);
        //rotating the player where camera is looking
        transform.rotation = Quaternion.Euler(0, cameraObject.GetComponent<MouseController>().y, 0);
        
        if(isGround)
        {
            playerRigidBody.AddRelativeForce(Input.GetAxis("Horizontal") * accelration, 0, Input.GetAxis("Vertical") * accelration);

        }
        else
        {
            playerRigidBody.AddRelativeForce(Input.GetAxis("Horizontal") * accelration * walkAccelrationRatio, 0, Input.GetAxis("Vertical") * walkAccelrationRatio * accelration);
        }

        if (isGround)
        {
            float xMove = Mathf.SmoothDamp(playerRigidBody.velocity.x, 0, ref walkDeaccelratex, deaccelrate
                );
            float zMove = Mathf.SmoothDamp(playerRigidBody.velocity.z, 0, ref walkDeaccelratez, deaccelrate
                );
            playerRigidBody.velocity = new Vector3(xMove, playerRigidBody.velocity.y, zMove);
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        foreach(ContactPoint contact in collision.contacts)
        {
            if(Vector3.Angle(contact.normal, Vector3.up) < maxSlope)
            {
                isGround = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.name.Equals("Plane"))
        {
            isGround = false;
        }
    }


}
