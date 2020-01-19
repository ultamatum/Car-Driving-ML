using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelCollider frontRightW, frontLeftW, backRightW, backLeftW;
    public Transform frontRightT, frontLeftT, backRightT, backLeftT;
    public float maxSteerAngle = 30;
    public float torque = 100;

    private float horizontalInput;
    private float verticalInput;
    private float steeringAngle;

    void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    void Steer()
    {
        steeringAngle = maxSteerAngle * horizontalInput;

        frontRightW.steerAngle = steeringAngle;
        frontLeftW.steerAngle = steeringAngle;
    }

    void Accelerate()
    {
        backRightW.motorTorque = torque * verticalInput;
        backLeftW.motorTorque = torque * verticalInput;
    }

    void UpdateWheelPoses()
    {

    }

    void UpdateWheelPose(WheelCollider collider, Transform transform)
    {

    }

    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
    }
}
