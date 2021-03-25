using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float cameraOffsetX;
    public float cameraOffsetY = 5.0f;
    public float cameraOffsetZ;
    public float zOffset;
    public bool changeCamera = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (changeCamera)
        {
            cameraOffsetZ = target.position.z - zOffset;
        }
        else
        {
            cameraOffsetX = target.position.x;
            cameraOffsetZ = target.position.z;
        }
        transform.position = new Vector3(cameraOffsetX, cameraOffsetY, cameraOffsetZ);
        gameObject.transform.LookAt(target);
    }
}
