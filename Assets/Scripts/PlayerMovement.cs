using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Turorial: https://www.youtube.com/watch?v=-0GFb9l3NHM
    private PlayerInput _input;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    private Camera cam;
    
    
    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
    }
    private void Update()
    {
        var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);

        var MovementVector =  MoveTowardTarget(targetVector);

        RotateTowardMovementVector(MovementVector);
        

    }
    private void RotateTowardMovementVector (Vector3 MovementVector)
    {
        if (MovementVector.magnitude == 0)
        {
            return;
        }
        var rotation = Quaternion.LookRotation(MovementVector);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed);
    }

    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        var speed = moveSpeed * Time.deltaTime;
 
        var targetPosition = transform.position + targetVector * speed;
        transform.position = targetPosition;
        return targetVector;
    }
}
