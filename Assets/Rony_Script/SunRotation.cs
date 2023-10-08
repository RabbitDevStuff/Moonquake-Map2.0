using UnityEngine;
using UnityEngine.UI;

public class SunRotation : MonoBehaviour
{
    public Slider rotationSpeedSlider; // Reference to the UI slider.
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
            RotateSun();
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

    private void RotateSun()
    {
        float direction = isClockwise ? -1f : 1f;
        float speed = rotationSpeedSlider.value * 6.0f; // Double the rotation speed.
        transform.Rotate(rotationAxis, direction * speed * Time.deltaTime);
    }
}
