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
        if(verticalInput >= 0.0f)
        {
            backRightW.motorTorque = torque * verticalInput;
            backLeftW.motorTorque = torque * verticalInput;
        } else if (verticalInput <= 0.0f)
        {
            backRightW.brakeTorque = torque * verticalInput * -1;
            backLeftW.brakeTorque = torque * verticalInput * -1;


            Debug.Log(verticalInput);
        }
    }

    void UpdateWheelPoses()
    {
        UpdateWheelPose(frontRightW, frontRightT);
        UpdateWheelPose(frontLeftW, frontLeftT);
        UpdateWheelPose(backRightW, backRightT);
        UpdateWheelPose(backLeftW, backLeftT);
    }

    void UpdateWheelPose(WheelCollider coll, Transform trans)
    {
        Vector3 pos = trans.position;
        Quaternion rot = trans.rotation;

        coll.GetWorldPose(out pos, out rot);

        trans.position = pos;
        trans.rotation = rot;
    }

    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
    }
}
