using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DroneMovement : MonoBehaviour
{
    public float tiltAngle; //in degrees
    public float speed;
    public float tiltStep;

    float upDownInput = 0.0f;
    float leftRightInput = 0.0f;
    float forwardBackInput = 0.0f;
    float rotateInput = 0.0f;

    private void Update()
    {
        //move drone up/down
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + (upDownInput * speed), gameObject.transform.position.z);
        Debug.Log(gameObject.transform.rotation.z);
        //move drone left/right
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + (leftRightInput * speed), gameObject.transform.position.y, gameObject.transform.position.z);
        //rotate drone left/right
        //if not fully tilted and left right input is true
        //(gameObject.transform.rotation.z > -tiltAngle && leftRightInput < 0)  || (gameObject.transform.rotation.z < tiltAngle && leftRightInput > 0)
        //check if input and not fully rotated either way
        if (leftRightInput != 0 && gameObject.transform.rotation.z < tiltAngle && gameObject.transform.rotation.z > -tiltAngle)
        {
            gameObject.transform.rotation = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z - (tiltStep * leftRightInput), 1.0f);

        }
        
        
        //if drone is tilted but left/right input is not active
        else if (gameObject.transform.rotation.z != 0 && leftRightInput == 0)
        {
            //make sur etilt is corrected in correct direction
            if (gameObject.transform.rotation.z < 0)
            {
                gameObject.transform.rotation = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z + tiltStep, 1.0f);

            }
            else
            {
                gameObject.transform.rotation = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z - tiltStep, 1.0f);

            }

        }
        //move drone forward/back

        //rotate drone forward/back

        //rotate drone

        //rotate camera

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
}
