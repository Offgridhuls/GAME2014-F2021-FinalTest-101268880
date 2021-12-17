using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Shrinking Platform
//Julian Sangiorgio
//101268880
//2021-12-17
public class MovingPlatform : MonoBehaviour
{
    [Header("Reference to target transforms")]
    public Transform target1,
        target2;

    [Header("Target positions")]
    private Vector3 targetPosition1,
        targetPosition2;

    [Header("Target")]
    private Vector3 targetPosition;

    public float speed = 2.0f;

    void Start()
    {
        targetPosition1 = target1.position;
        targetPosition2 = target2.position;
        targetPosition = targetPosition1;
    }


   void Update()
   {
     if (transform.position == targetPosition1) // If the gameobjects' position == to the first target position
     {
        targetPosition = targetPosition2; // switch the target position to the second targetposition
     }
     else if (transform.position == targetPosition2) // else if gameobjects' position == to the second target position
     {
        targetPosition = targetPosition1; // switch the target position to the first targetposition
     }

     transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime); // move towards the target position that we set here above ^^
   }

}
