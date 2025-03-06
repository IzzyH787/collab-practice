using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DroneMovement : MonoBehaviour
{
    float upDownInput = 0.0f;
    float leftRightInput = 0.0f;
    float forwardBackInput = 0.0f;
    float rotateInput = 0.0f;
    public float riseSpeed = 8;
    public int targetHoop = 1;
    Rigidbody rb;
    private LevelManager levelManager;

    float upDownAxis, forwardBackwardAxis, leftRightAxis;
    float forwardBackAngle = 0, leftRightAngle = 0, yAxisAngle = 0;

    public float speed, angle, riseMultiplier, slowMultiplier, maxSpeed;
    //Animator animator
    bool isOnGround = false;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        //animator = gameObject.GetComponent<Animator>();
    }

    void Controls()
    {
        #region upDownMovement
        //if moving up
        if (upDownInput > 0)
        {
            upDownAxis = riseMultiplier * upDownInput;
            //animator.SetBool("Fly", true));
        }
        //if moving down
        else if (upDownInput < 0)
        {
            upDownAxis = riseMultiplier * upDownInput;
            //animator.SetBool("Fly", false));
        }
        else
        {
            if (Mathf.Abs(rb.velocity.y) > 0.1)
            {
                upDownAxis = 0;
                rb.velocity = new Vector3(rb.velocity.x, Mathf.Lerp(rb.velocity.y, 0, Time.deltaTime), rb.velocity.z) * slowMultiplier ;
            }
            else
            {
                upDownAxis = 0;
            }
            // upDownAxis -= Mathf.Lerp(upDownAxis, 0, Time.deltaTime);
            //animator.SetBool("Fly", false));
        }
        #endregion
        #region forwardBackMovement
        //if moving forward
        if (forwardBackInput > 0)
        {
            forwardBackAngle = Mathf.Lerp(forwardBackAngle, angle, Time.deltaTime);
            forwardBackwardAxis = speed;
            //animator.SetBool("Fly", true);
        }
        //if moving backward
        else if (forwardBackInput < 0)
        {
            forwardBackAngle = Mathf.Lerp(forwardBackAngle, -angle, Time.deltaTime);
            forwardBackwardAxis = speed;
            //animator.SetBool("Fly", true);
        }
        //no input
        else
        {
            forwardBackAngle = Mathf.Lerp(forwardBackAngle, 0, Time.deltaTime);
            forwardBackwardAxis = 0;
        }
        #endregion
        #region leftRightMovement
        if(leftRightInput > 0)
        {
            leftRightAngle = Mathf.Lerp(leftRightAngle, angle, Time.deltaTime);
            leftRightAxis = speed;
            //animator.SetBool("Fly", true);
        }
        //if moving backward
        else if (leftRightInput < 0)
        {
            leftRightAngle = Mathf.Lerp(leftRightAngle, -angle, Time.deltaTime);
            leftRightAxis = speed;
            //animator.SetBool("Fly", true);
        }
        //no input
        else
        {
            leftRightAngle = Mathf.Lerp(leftRightAngle, 0, Time.deltaTime);
            leftRightAxis = 0;
        }
        #endregion

        #region forwardRightMovement
        if (forwardBackInput > 0 && leftRightInput > 0)
        {
            forwardBackAngle = Mathf.Lerp(forwardBackAngle, angle, Time.deltaTime);
            leftRightAngle = Mathf.Lerp(leftRightAngle, angle, Time.deltaTime);
            forwardBackwardAxis = 0.5f * speed;
            leftRightAxis = 0.5f;
        }
        #endregion
        #region forwardLeftMovement
        if (forwardBackInput > 0 && leftRightInput < 0)
        {
            forwardBackAngle = Mathf.Lerp(forwardBackAngle, angle, Time.deltaTime);
            leftRightAngle = Mathf.Lerp(leftRightAngle, -angle, Time.deltaTime);
            forwardBackwardAxis = 0.5f * speed;
            leftRightAxis = 0.5f * speed;
        }
        #endregion
        #region backRightMovement
        if (forwardBackInput < 0 && leftRightInput > 0)
        {
            forwardBackAngle = Mathf.Lerp(forwardBackAngle, -angle, Time.deltaTime);
            leftRightAngle = Mathf.Lerp(leftRightAngle, angle, Time.deltaTime);
            forwardBackwardAxis = 0.5f * speed;
            leftRightAxis = 0.5f * speed;
        }
        #endregion
        #region backLeftMovement
        if (forwardBackInput < 0 && leftRightInput < 0)
        {
            forwardBackAngle = Mathf.Lerp(forwardBackAngle, -angle, Time.deltaTime);
            leftRightAngle = Mathf.Lerp(leftRightAngle, -angle, Time.deltaTime);
            forwardBackwardAxis = 0.5f * speed;
            leftRightAxis = 0.5f;
        }
        #endregion


        //rotate about y axis
        yAxisAngle = Mathf.Lerp(yAxisAngle, yAxisAngle + (90 * rotateInput), Time.deltaTime);
    }

    

    private void Update()
    {
        Controls();
        transform.localEulerAngles = Vector3.back * leftRightAngle + Vector3.right * forwardBackAngle + Vector3.up * yAxisAngle;
    }

    private void FixedUpdate()
    {
        rb.AddRelativeForce(leftRightAxis * leftRightInput, upDownAxis, forwardBackwardAxis * forwardBackInput);

        //cap speed
        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector3(maxSpeed, rb.velocity.y, rb.velocity.z);
        }
        if (rb.velocity.y > maxSpeed)
        {
            rb.velocity = new Vector3(rb.velocity.x, maxSpeed, rb.velocity.z);
        }
        if (rb.velocity.z > maxSpeed)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, maxSpeed);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
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

   /* void MoveLeftRight()
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

    }*/

}