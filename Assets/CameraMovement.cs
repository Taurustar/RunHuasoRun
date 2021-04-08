using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject objectToFollow;
    [Tooltip("Sets the minimum X position value that camera can have")]
    public float leftBoundaryPosition;
    [Tooltip("Sets the maximum X position value that camera can have")]
    public float rightBoundartPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {       

       
            transform.position = new Vector3(objectToFollow.transform.position.x, transform.transform.position.y, transform.position.z);

            if (transform.position.x >= rightBoundartPosition)
            {
                transform.position = new Vector3(rightBoundartPosition, transform.position.y, transform.position.z);
            }
            if (transform.position.x <= leftBoundaryPosition)
            {
                transform.position = new Vector3(leftBoundaryPosition, transform.position.y, transform.position.z);
            }
        

    }
}
