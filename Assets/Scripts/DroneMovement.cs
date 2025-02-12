using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DroneMovement : MonoBehaviour
{
    public GameObject camera; 
    public float tiltAngle; //in degrees
    public float speed;
    public float tiltStep;
    public float rotateStep;

    float upDownInput = 0.0f;
    float leftRightInput = 0.0f;
    float forwardBackInput = 0.0f;
    float rotateInput = 0.0f;

    private void Update()
    {
        //move drone 
        MoveUpDown();
        MoveLeftRight();
        MoveForwardBack();
        Rotate();


    }
    public void OnUpDown(InputAction.CallbackContext ctx)
    {
        upDownInput = ctx.ReadValue<float>(); //reads direction 
    }
    public void OnLeftRight(InputAction.CallbackContext ctx)
    {
        leftRightInput = ctx.ReadValue<float>(); //reads direction
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
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + (leftRightInput * speed), gameObject.transform.position.y, gameObject.transform.position.z);
        //check if input and not fully rotated either way
        if (leftRightInput != 0 && gameObject.transform.rotation.z < tiltAngle && gameObject.transform.rotation.z > -tiltAngle)
        {
            gameObject.transform.rotation = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z - (tiltStep * leftRightInput), 1.0f);

        }

        //if drone is tilted but left/right input is not active
        else if (gameObject.transform.rotation.z != 0 && leftRightInput == 0)
        {
            //make suretilt is corrected in correct direction
            if (gameObject.transform.rotation.z < 0)
            {
                gameObject.transform.rotation = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z + tiltStep, 1.0f);

            }
            else
            {
                gameObject.transform.rotation = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z - tiltStep, 1.0f);

            }
            //check if angle needs zeroing 
            if (gameObject.transform.rotation.z < tiltStep && gameObject.transform.rotation.z > -tiltStep)
            {
                gameObject.transform.rotation = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, 0.0f, 1.0f);

            }
        }
    }
    void MoveUpDown()
    {
        //move drone up/down
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + (upDownInput * speed), gameObject.transform.position.z);
    }
    void MoveForwardBack()
    {
        //move drone left/right
        gameObject.transform.position = new Vector3(gameObject.transform.position.x , gameObject.transform.position.y, gameObject.transform.position.z + (forwardBackInput * speed));
        //check if input and not fully rotated either way
        if (forwardBackInput != 0 && gameObject.transform.rotation.x < tiltAngle && gameObject.transform.rotation.x > -tiltAngle)
        {
            gameObject.transform.rotation = new Quaternion(gameObject.transform.rotation.x + (tiltStep * forwardBackInput), gameObject.transform.rotation.y, gameObject.transform.rotation.z , 1.0f);

        }

        //if drone is tilted but left/right input is not active
        else if (gameObject.transform.rotation.x != 0 && forwardBackInput == 0)
        {
            //make suretilt is corrected in correct direction
            if (gameObject.transform.rotation.x < 0)
            {
                gameObject.transform.rotation = new Quaternion(gameObject.transform.rotation.x + tiltStep, gameObject.transform.rotation.y, gameObject.transform.rotation.z, 1.0f);

            }
            else
            {
                gameObject.transform.rotation = new Quaternion(gameObject.transform.rotation.x - tiltStep, gameObject.transform.rotation.y, gameObject.transform.rotation.z, 1.0f);

            }

        }
    }
    void Rotate()
    {
        //only rotate if input
        if (rotateInput != 0)
        {
            //rotate drone
            //gameObject.transform.rotation = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y + (rotateStep * rotateInput), gameObject.transform.rotation.z, 1.0f);
            //rotate camera
            //camera.gameObject.transform.rotation = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y + (rotateStep * rotateInput), gameObject.transform.rotation.z, 1.0f);

        }

    }

}