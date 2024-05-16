using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    [SerializeField] private float minFov = 15.0f;
    [SerializeField] private float maxFov = 90.0f;
    [SerializeField] private float sens = 1.0f;
    private float velocity = 0f;
    [SerializeField] private float smoothTime = 0.25f;
    private float currentFov;
    private Camera cam;
    Vector3 newPosition;

    void Start()
    {
        cam = GetComponent<Camera>();
        currentFov = cam.orthographicSize;
    }
    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        currentFov -= scroll * sens;
        currentFov = Mathf.Clamp(currentFov, minFov, maxFov);
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, currentFov, ref velocity, smoothTime);

    }
}
