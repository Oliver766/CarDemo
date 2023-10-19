using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayercarController : MonoBehaviour
{
    [Header("Wheels Collider")]
    public WheelCollider frontRightWheel;
    public WheelCollider frontLeftWheel;
    public WheelCollider backRightWheel;
    public WheelCollider backLeftWheel;

    [Header("Wheels Tansform")]
    public Transform frontLeftwheelTransform;
    public Transform frontRightwheelTransform;
    public Transform backLeftwheelTransform;
    public Transform backRightwheelTransform;

    [Header("Car Engine")]
    public float accelerationForce = 300f;
    public float breakingForce = 3000f;
    private float presentBreakForce = 0f;
    private float presentAcceleration = 0f;

    [Header("Car Steering")]
    public float wheelsToque = 35f;
    private float presentTurnAngle = 0f;

    private void MoveCar()
    {
        frontLeftWheel.motorTorque = presentAcceleration;
        frontRightWheel.motorTorque = presentAcceleration;
        backLeftWheel.motorTorque = presentAcceleration;
        backRightWheel.motorTorque = presentAcceleration;

        presentAcceleration = accelerationForce * Input.GetAxis("Vertical");
    }

    private void CarSteering()
    {
        presentTurnAngle = wheelsToque * Input.GetAxis("Horizontal");
        frontLeftWheel.steerAngle = presentTurnAngle;
        frontRightWheel.steerAngle = presentTurnAngle;
    }

    private void Update()
    {
        MoveCar();
        CarSteering();
    }

}
