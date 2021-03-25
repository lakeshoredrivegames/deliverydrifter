using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float currentBrakeForce;
    private float currentSteeringAngle;

    private bool isBraking;
    private bool changeCamera;
    private CameraFollow cam;
    

    [SerializeField] private float motorForce;
    [SerializeField] private float brakeForce;
    [SerializeField] private float maxSteeringAngle;

    [SerializeField] private WheelCollider frontDriverWheelCollider;
    [SerializeField] private WheelCollider frontPassengerWheelCollider;
    [SerializeField] private WheelCollider rearDriverWheelCollider;
    [SerializeField] private WheelCollider rearPassengerWheelCollider;

    [SerializeField] private Transform frontDriverWheelTransform;
    [SerializeField] private Transform frontPassengerWheelTransform;
    [SerializeField] private Transform rearDriverWheelTransform;
    [SerializeField] private Transform rearPassengerWheelTransform;

    private void Start()
    {
        //find camera 
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
    }

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        ChangeCamera();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isBraking = Input.GetKey(KeyCode.Space);
        changeCamera = Input.GetKey(KeyCode.Return);
        Debug.Log("horizontalInput: " + horizontalInput);
    }

    private void HandleMotor()
    {
        frontDriverWheelCollider.motorTorque = verticalInput * motorForce;
        frontPassengerWheelCollider.motorTorque = verticalInput * motorForce;
        currentBrakeForce = isBraking ? brakeForce : 0f;
        ApplyBrakes();

    }

    private void ApplyBrakes()
    {
        frontDriverWheelCollider.brakeTorque = currentBrakeForce;
        frontPassengerWheelCollider.brakeTorque = currentBrakeForce;
        rearDriverWheelCollider.brakeTorque = currentBrakeForce;
        rearPassengerWheelCollider.brakeTorque = currentBrakeForce;
    }

    private void HandleSteering()
    {
        currentSteeringAngle = maxSteeringAngle * horizontalInput;
        frontDriverWheelCollider.steerAngle = currentSteeringAngle;
        frontPassengerWheelCollider.steerAngle = currentSteeringAngle;
    }

    private void UpdateWheels()
    {
        UpdateWheels(frontDriverWheelCollider, frontDriverWheelTransform);
        UpdateWheels(frontPassengerWheelCollider, frontPassengerWheelTransform);
        UpdateWheels(rearDriverWheelCollider, rearDriverWheelTransform);
        UpdateWheels(rearPassengerWheelCollider, rearPassengerWheelTransform);
        
    }

    private void UpdateWheels(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

    private void ChangeCamera()
    {
        if(changeCamera)
        {
            cam.changeCamera = !cam.changeCamera;
            cam.cameraOffsetY = 2;
            //cam.cameraOffsetZ = -2;
        }
    }
}
