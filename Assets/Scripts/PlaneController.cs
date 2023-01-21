using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public GameObject plane;
    [SerializeField] public float roll;
    [SerializeField] public float pitch;
    [SerializeField] public float yaw;
    [SerializeField] public float throttle;
    [SerializeField] public float throttleIncrement;
    [SerializeField] public float maxThrottle = 200.0f;
    [SerializeField] public float sensitivity;
    [SerializeField] public float thrust = 5.0f;
    [SerializeField] public float maxThrust = 5.0f;

    [SerializeField] public float sensitivityScale = 10.0f;

    [SerializeField] public string rollAxis = "Roll";
    [SerializeField] public string pitchlAxis = "Pitch";
    [SerializeField] public string yawAxis = "Yaw";
    [SerializeField] public string throttleKey = "Mouse0";
    [SerializeField] public string brakeKey = "Mouse1";

    [SerializeField] public float collisionCrashIndex = 500.0f;

    [SerializeField] public Rigidbody rb;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ControllerProcessing();
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * thrust * throttle );
        float adjustedSensitivity = getAdjustedSensitivity(); 
        rb.AddTorque(transform.up * yaw * adjustedSensitivity);
        rb.AddTorque(transform.right * pitch * adjustedSensitivity);
        rb.AddTorque(-transform.forward * roll * adjustedSensitivity);
    }

    public float getAdjustedSensitivity()
    {
        return (rb.mass/sensitivityScale) * sensitivity;    
    }


    public void ControllerProcessing()
    {
        roll = Input.GetAxis(rollAxis);
        pitch = Input.GetAxis(pitchlAxis);
        yaw = Input.GetAxis(yawAxis);

        if (Input.GetButton(throttleKey))
        {
           // Debug.Log("Throttle on"); 
            throttle += throttleIncrement; 

            if(throttle >=maxThrottle)
            {
                throttle = maxThrottle; 
            }
        }

        else if (Input.GetButton(brakeKey))
        {
           // Debug.Log("Brakes on");
            throttle -= throttleIncrement;

            if (throttle < 0)
            {
                throttle = 0;
            }
        }
    }
}
