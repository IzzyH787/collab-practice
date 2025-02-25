using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DroneMovement : MonoBehaviour
{
    public float tiltAngle; //in degrees
    public float speed;
    public float riseSpeed;
    public float tiltStep;
    public float rotateStep;

    float upDownInput = 0.0f;
    float leftRightInput = 0.0f;
    float forwardBackInput = 0.0f;
    float rotateInput = 0.0f;

    public float accelleration;
    public float decelleration;
    public int targetHoop = 1;
    Rigidbody rb;

    private LevelManager levelManager;
    private void Start()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }

    private void Update()
    {
        //move drone 
        MoveUpDown();
        MoveLeftRight();
        MoveForwardBack();
        //check if no input then zero spinning
        if (leftRightInput == 0 && forwardBackInput == 0 && upDownInput == 0)
        {

        }
        //Rotate();
        //check if moving up
        if (gameObject.GetComponent<Rigidbody>().velocity.y > 0)
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x, gameObject.GetComponent<Rigidbody>().velocity.y + decelleration, gameObject.GetComponent<Rigidbody>().velocity.z);
        }
        //check if falling with no input
        else if (gameObject.GetComponent<Rigidbody>().velocity.y < 0 && upDownInput == 0)
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x, 0.0f, gameObject.GetComponent<Rigidbody>().velocity.z);

        }

    }

    void OnCollisionEnter(Collision collision)
    {
        // Stop the rotation by resetting angular velocity
        
        rb.angularVelocity = Vector3.zero;  // This stops any spinning

        // Optionally, reset rotation to a desired fixed value (like upright)
        //gameObject.transform.rotation = Quaternion.Euler(0, 0, 0); // Reset to upright position
    }
    public void OnUpDown(InputAction.CallbackContext ctx)
    {
        //Debug.Log(upDownInput);
        upDownInput = ctx.ReadValue<float>(); //reads direction 
    }
    public void OnLeftRight(InputAction.CallbackContext ctx)
    {
        leftRightInput = ctx.ReadValue<float>(); //reads direction
        //Debug.Log(leftRightInput);
    }
    public void OnForwardBack(InputAction.CallbackContext ctx)
    {
        forwardBackInput = ctx.ReadValue<float>(); //reads direction
    }
    public void OnRotate(InputAction.CallbackContext ctx)
    {
        rotateInput = ctx.ReadValue<float>(); //reads direction
    }

    void MoveLeftRight()
    {
        //move drone left/right
        //gameObject.transform.position = new Vector3(gameObject.transform.position.x + (leftRightInput * speed), gameObject.transform.position.y, gameObject.transform.position.z);
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(leftRightInput * riseSpeed, gameObject.GetComponent<Rigidbody>().velocity.y, gameObject.GetComponent<Rigidbody>().velocity.z);

          
        //check if input and not fully rotated either way
        if (leftRightInput != 0 && gameObject.GetComponent<Rigidbody>().rotation.z < tiltAngle && gameObject.GetComponent<Rigidbody>().rotation.z > -tiltAngle)
        {
            gameObject.GetComponent<Rigidbody>().rotation = new Quaternion(gameObject.GetComponent<Rigidbody>().rotation.x, gameObject.GetComponent<Rigidbody>().rotation.y, gameObject.GetComponent<Rigidbody>().rotation.z - (tiltStep * leftRightInput), 1.0f);

        }

        //if drone is tilted but left/right input is not active
        else if (gameObject.GetComponent<Rigidbody>().rotation.z != 0 && leftRightInput == 0)
        {
            //make suretilt is corrected in correct direction
            if (gameObject.GetComponent<Rigidbody>().rotation.z < 0)
            {
                gameObject.GetComponent<Rigidbody>().rotation = new Quaternion(gameObject.GetComponent<Rigidbody>().rotation.x, gameObject.GetComponent<Rigidbody>().rotation.y, gameObject.GetComponent<Rigidbody>().rotation.z + tiltStep, 1.0f).normalized;

            }
            else
            {
                gameObject.GetComponent<Rigidbody>().rotation = new Quaternion(gameObject.GetComponent<Rigidbody>().rotation.x, gameObject.GetComponent<Rigidbody>().rotation.y, gameObject.GetComponent<Rigidbody>().rotation.z - tiltStep, 1.0f).normalized;

            }
            //check if angle needs zeroing 
            if (gameObject.GetComponent<Rigidbody>().rotation.z < tiltStep && gameObject.GetComponent<Rigidbody>().rotation.z > -tiltStep)
            {
                gameObject.GetComponent<Rigidbody>().rotation = new Quaternion(gameObject.GetComponent<Rigidbody>().rotation.x, gameObject.GetComponent<Rigidbody>().rotation.y, 0.0f, 1.0f);

            }
        }
    }
    void MoveUpDown()
    {
        //move drone up/down
        //gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + (upDownInput * speed), gameObject.transform.position.z);
        //Debug.Log(upDownInput);
        if(upDownInput != 0)
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x, (upDownInput * riseSpeed), gameObject.GetComponent<Rigidbody>().velocity.z);

        }
    }
    void MoveForwardBack()
    {
        //move drone left/right
        //gameObject.transform.position = new Vector3(gameObject.transform.position.x , gameObject.transform.position.y, gameObject.transform.position.z + (forwardBackInput * speed));
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x, gameObject.GetComponent<Rigidbody>().velocity.y, forwardBackInput * riseSpeed);


        //check if input and not fully rotated either way
        if (forwardBackInput != 0 && gameObject.GetComponent<Rigidbody>().rotation.x < tiltAngle && gameObject.GetComponent<Rigidbody>().rotation.x > -tiltAngle)
        {
            gameObject.GetComponent<Rigidbody>().rotation = new Quaternion(gameObject.GetComponent<Rigidbody>().rotation.x + (tiltStep * forwardBackInput), gameObject.GetComponent<Rigidbody>().rotation.y, gameObject.GetComponent<Rigidbody>().rotation.z , 1.0f);

        }

        //if drone is tilted but left/right input is not active
        else if (gameObject.GetComponent<Rigidbody>().rotation.x != 0 && forwardBackInput == 0)
        {
            //make suretilt is corrected in correct direction
            if (gameObject.GetComponent<Rigidbody>().rotation.x > -0.06 && gameObject.GetComponent<Rigidbody>().rotation.x  < 0.06)
            {
                gameObject.GetComponent<Rigidbody>().rotation = new Quaternion(0, gameObject.GetComponent<Rigidbody>().rotation.y, gameObject.GetComponent<Rigidbody>().rotation.z, 1.0f);

            }
            if (gameObject.GetComponent<Rigidbody>().rotation.x < 0)
            {
                gameObject.GetComponent<Rigidbody>().rotation = new Quaternion(gameObject.GetComponent<Rigidbody>().rotation.x + tiltStep, gameObject.GetComponent<Rigidbody>().rotation.y, gameObject.GetComponent<Rigidbody>().rotation.z, 1.0f);

            }
            else
            {
                gameObject.GetComponent<Rigidbody>().rotation = new Quaternion(gameObject.GetComponent<Rigidbody>().rotation.x - tiltStep, gameObject.GetComponent<Rigidbody>().rotation.y, gameObject.GetComponent<Rigidbody>().rotation.z, 1.0f);

            }

        }
    }
    void Rotate()
    {
        //only rotate if input
        if (rotateInput != 0)
        {
            //rotate drone
            gameObject.GetComponent<Rigidbody>().rotation = new Quaternion(gameObject.GetComponent<Rigidbody>().rotation.x, gameObject.GetComponent<Rigidbody>().rotation.y + (rotateStep * rotateInput), gameObject.GetComponent<Rigidbody>().rotation.z, 1.0f);
            //correct x and z rotation of  camera
            //camera.gameObject.transform.rotation = new Quaternion(camera.gameObject.transform.rotation.x - gameObject.transform.rotation.x, camera.gameObject.transform.rotation.y, camera.gameObject.transform.rotation.z - gameObject.transform.rotation.z, 1.0f);

        }

    }

}