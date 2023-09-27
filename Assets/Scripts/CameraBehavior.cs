using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
struct CameraOptions
{
    public Vector3 offset;
    public float sensitivity;
    public int maxPitch;
}

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] private Transform origin;

    [SerializeField] private Transform target;

    [SerializeField] private CameraOptions options;

    [SerializeField] private PlayerInput cameraInputs;

    private Vector2 _axis;

    private float _currentPitch;
    // Start is called before the first frame update
    void Start()
    {
        _currentPitch = origin.rotation.eulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        _axis = cameraInputs.actions["movement"].ReadValue<Vector2>() * (options.sensitivity * 100 * Time.deltaTime);
        var targetPosition = target.position;
        origin.RotateAround(targetPosition, Vector3.up, _axis.x);
        _currentPitch += -_axis.y;
        _currentPitch = Mathf.Clamp(_currentPitch, -options.maxPitch, options.maxPitch);
        var cameraRotation = origin.rotation;
        origin.rotation = Quaternion.Lerp(origin.rotation, Quaternion.Euler(_currentPitch, cameraRotation.eulerAngles.y, cameraRotation.eulerAngles.z), 0.1f);
        var nextPosition = targetPosition - (origin.forward * 10) + new Vector3(0, 2, 0);
        origin.position = nextPosition;
    }
}
