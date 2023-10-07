using UnityEngine;

public class EarthOrbit : MonoBehaviour
{
    public float rotationSpeed = 10.0f; // Rotation speed of the Earth on its axis
    public float revolutionSpeed = 1.0f; // Revolution speed around the Sun
    public float distanceFromSun = 5.0f; // Initial distance from the Sun
    private Vector3 axisOfRotation = Vector3.up; // Earth's axis of rotation
    public Transform sun; // Reference to the Sun Transform

    private void Start()
    {
        // Find the Sun GameObject by tag or set the Sun reference manually
        sun = GameObject.FindGameObjectWithTag("Sun").transform;

        if (sun == null)
        {
            Debug.LogError("Sun not found. Make sure you have a GameObject with the 'Sun' tag.");
        }

        // Set the initial position of the Earth
        transform.position = sun.position + (transform.position - sun.position).normalized * distanceFromSun;
    }

    void Update()
    {
        // Rotate the Earth on its own axis
        transform.Rotate(axisOfRotation, rotationSpeed * Time.deltaTime);

        // Orbit the Sun
        OrbitAroundSun();
    }

    void OrbitAroundSun()
    {
        // Calculate the direction to the Sun
        Vector3 toSun = (sun.position - transform.position).normalized;

        // Calculate the desired position based on the distance from the Sun
        Vector3 desiredPosition = sun.position + toSun * distanceFromSun;

        // Smoothly interpolate the position to create an orbit effect
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * revolutionSpeed);
    }
}
