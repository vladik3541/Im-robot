using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float GRAVITY = -9.81f;
    [SerializeField] private float speed;
    [SerializeField] private float smosmoothTimeRotation;

    [SerializeField] private Transform body;

    private InputSystem inputSystem;
    private CharacterController characterController;
    private Targeter targeter;

    private float currentVelocity;
    void Start()
    {
        inputSystem = new InputSystem();
        targeter = GetComponentInChildren<Targeter>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        RotateToDirection();
        RotateToTarget();
    }

    private void Movement()
    {
        Vector3 movementInput = new Vector3(inputSystem.GetMovementInput().x * speed,GRAVITY , inputSystem.GetMovementInput().y * speed);
        characterController.Move(movementInput * Time.deltaTime);
    }
    private void RotateToDirection()
    {
        Vector3 move = inputSystem.GetMovementInput();
        if (move.sqrMagnitude == 0) return;
        float targetAngel = Mathf.Atan2(move.x, move.y) * Mathf.Rad2Deg;
        float angel = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngel, ref currentVelocity, smosmoothTimeRotation);
        transform.rotation = Quaternion.Euler(0, angel, 0);
    }
    private void RotateToTarget()
    {
        if (targeter.CurrentTarget == null)
        {
            body.rotation = transform.rotation;
        }
        else
        {
            Vector3 direction = targeter.CurrentTarget.position - transform.position;
            direction.y = 0;
            body.rotation = Quaternion.LookRotation(direction);
        }
        
    }
}
