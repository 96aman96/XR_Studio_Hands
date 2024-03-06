using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public float initialSpeed = 5.0f;
    public float minimumSpeed = 0.5f;
    private float currentSpeed;
    private Transform cameraTransform;
    private Vector3 initialDirection;
    private Vector3 targetPosition;
    private float destructionDistance = 8.0f;

    void Start()
    {
        cameraTransform = Camera.main.transform;

        // Initially point the bullet towards the camera and calculate the initial direction
        transform.LookAt(cameraTransform);
        initialDirection = transform.forward;
        targetPosition = cameraTransform.position;

        currentSpeed = initialSpeed;
    }

    void Update()
    {
        // Move the bullet in the initial direction
        transform.position += initialDirection * currentSpeed * Time.deltaTime;

        // Calculate the current distance to the camera
        float distanceToCamera = Vector3.Distance(transform.position, cameraTransform.position);

        // Dynamically adjust the speed based on the distance to the camera
        currentSpeed = Mathf.Lerp(minimumSpeed, initialSpeed, distanceToCamera / (distanceToCamera + 1));

        // Keep the bullet facing the camera
        transform.LookAt(cameraTransform);

        // Destroy the bullet if it has moved 8 units beyond the camera in its initial direction
        if (Vector3.Distance(transform.position, targetPosition) > destructionDistance)
        {
            Destroy(gameObject);
        }
    }
}
