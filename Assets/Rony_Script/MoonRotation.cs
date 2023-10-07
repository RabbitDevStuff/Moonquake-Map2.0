using UnityEngine;

public class MoonRotation : MonoBehaviour
{
    public float rotationSpeed = 10.0f; // Rotation speed in degrees per second.
    public Vector3 rotationAxis = Vector3.up; // Rotation axis, you can change this in the Inspector.
    public bool isClockwise = false; // Whether the rotation is clockwise or counterclockwise.
    public bool rotateOnStart = true; // Start rotating when the game begins.

    private void Start()
    {
        if (rotateOnStart)
        {
            StartRotation();
        }
    }

    private void Update()
    {
        if (isRotating)
        {
            RotateMoon();
        }
    }

    private bool isRotating = false;

    public void StartRotation()
    {
        isRotating = true;
    }

    public void StopRotation()
    {
        isRotating = false;
    }

    private void RotateMoon()
    {
        float direction = isClockwise ? -1f : 1f;
        transform.Rotate(rotationAxis, direction * rotationSpeed * Time.deltaTime);
    }
}
