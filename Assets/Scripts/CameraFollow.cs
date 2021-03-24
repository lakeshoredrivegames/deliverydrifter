using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float cameraOffsetX;
    public float cameraOffsetY = 10.0f;
    public float cameraOffsetZ;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        cameraOffsetX = target.position.x;
        cameraOffsetZ = target.position.z;
        transform.position = new Vector3(target.position.x, cameraOffsetY, target.position.z);
    }
}
