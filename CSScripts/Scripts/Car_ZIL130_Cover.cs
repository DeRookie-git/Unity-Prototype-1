using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_ZIL130_Cover : MonoBehaviour
{
    public float power = 1500f;
    public float steeringAngle = 40f;

    public WheelCollider Truck_Wheel_FL;
    public WheelCollider Truck_Wheel_FR;
    public WheelCollider Truck_Wheel_BL;
    public WheelCollider Truck_Wheel_BR;

    public Transform Visual_Truck_Wheel_FL;
    public Transform Visual_Truck_Wheel_FR;
    public Transform Visual_Back_Wheels;

    private float inputHorizontal;
    private float inputVertical;
    private float frontLeftInitialYRotation;
    public Rigidbody rb { get; private set; }

    void Start()
    {
        frontLeftInitialYRotation = Visual_Truck_Wheel_FL.localEulerAngles.y; //nes vienas ratas 180 apsuktas
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");
        Steer();
        Accelerate();
        UpdateVisualWheels();
    }

    private void Steer()
    {
        float currentSteerAngle = steeringAngle * inputHorizontal;
        Truck_Wheel_FL.steerAngle = currentSteerAngle;
        Truck_Wheel_FR.steerAngle = currentSteerAngle;
        Visual_Truck_Wheel_FL.localEulerAngles = new Vector3(0, frontLeftInitialYRotation + Truck_Wheel_FL.steerAngle, 0);
        Visual_Truck_Wheel_FR.localEulerAngles = new Vector3(0, Truck_Wheel_FR.steerAngle, 0);
    }

    private void Accelerate()
    {
        float motorTorque = power * inputVertical;
        Truck_Wheel_BL.motorTorque = motorTorque;
        Truck_Wheel_BR.motorTorque = motorTorque;
    }

    private void UpdateVisualWheels()
    {
        float speed = rb.velocity.magnitude;
        float rotationSpeed = speed / (2 * Mathf.PI * Truck_Wheel_BL.radius) * 360 * Time.deltaTime;
        Visual_Truck_Wheel_FL.Rotate(rotationSpeed, 0, 0);
        Visual_Truck_Wheel_FR.Rotate(rotationSpeed, 0, 0);
        float averageBackWheelRPM = (Truck_Wheel_BL.rpm + Truck_Wheel_BR.rpm) / 2;
        float backRotationSpeed = averageBackWheelRPM / 60 * 360 * Time.deltaTime; 
        Visual_Back_Wheels.Rotate(backRotationSpeed, 0, 0);
    }
}


