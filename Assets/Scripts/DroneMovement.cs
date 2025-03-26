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
    public float gravityForce;
    Rigidbody rb;
    private LevelManager levelManager;

    public GameObject propeller1;
    public GameObject propeller2;
    public float maxRotSpeed;

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
        /*else if (upDownInput < 0)
        {
            upDownAxis = riseMultiplier * upDownInput;
            //animator.SetBool("Fly", false));
        }*/
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
            forwardBackwardAxis = speed * upDownInput;
            //animator.SetBool("Fly", true);
        }
        //if moving backward
        else if (forwardBackInput < 0)
        {
            forwardBackAngle = Mathf.Lerp(forwardBackAngle, -angle, Time.deltaTime);
            forwardBackwardAxis = speed * upDownInput;
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
            leftRightAxis = speed * upDownInput;
            //animator.SetBool("Fly", true);
        }
        //if moving backward
        else if (leftRightInput < 0)
        {
            leftRightAngle = Mathf.Lerp(leftRightAngle, -angle, Time.deltaTime);
            leftRightAxis = speed * upDownInput;
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
            forwardBackwardAxis = 0.5f * speed * upDownInput;
            leftRightAxis = 0.5f;
        }
        #endregion
        #region forwardLeftMovement
        if (forwardBackInput > 0 && leftRightInput < 0)
        {
            forwardBackAngle = Mathf.Lerp(forwardBackAngle, angle, Time.deltaTime);
            leftRightAngle = Mathf.Lerp(leftRightAngle, -angle, Time.deltaTime);
            forwardBackwardAxis = 0.5f * speed * upDownInput;
            leftRightAxis = 0.5f * speed * upDownInput;
        }
        #endregion
        #region backRightMovement
        if (forwardBackInput < 0 && leftRightInput > 0)
        {
            forwardBackAngle = Mathf.Lerp(forwardBackAngle, -angle, Time.deltaTime);
            leftRightAngle = Mathf.Lerp(leftRightAngle, angle, Time.deltaTime);
            forwardBackwardAxis = 0.5f * speed * upDownInput;
            leftRightAxis = 0.5f * speed * upDownInput;
        }
        #endregion
        #region backLeftMovement
        if (forwardBackInput < 0 && leftRightInput < 0)
        {
            forwardBackAngle = Mathf.Lerp(forwardBackAngle, -angle, Time.deltaTime);
            leftRightAngle = Mathf.Lerp(leftRightAngle, -angle, Time.deltaTime);
            forwardBackwardAxis = 0.5f * speed * upDownInput;
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
        propeller1.gameObject.transform.localEulerAngles += Vector3.up * maxRotSpeed * upDownAxis;
        propeller2.gameObject.transform.localEulerAngles += Vector3.up * maxRotSpeed * upDownAxis;
    }

    private void FixedUpdate()
    {
        rb.AddRelativeForce(leftRightAxis * leftRightInput, upDownAxis + gravityForce, forwardBackwardAxis * forwardBackInput);

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


}