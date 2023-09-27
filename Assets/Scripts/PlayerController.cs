using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour 
{
    [SerializeField] private PlayerInput input;

    [SerializeField] private Transform character;

    [SerializeField] private Rigidbody body;

    private Vector2 _movementAxis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _movementAxis = input.actions["movement"].ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        body.AddRelativeForce(new Vector3(_movementAxis.x, 0, _movementAxis.y) * (Time.deltaTime * 5000f));
    }
}