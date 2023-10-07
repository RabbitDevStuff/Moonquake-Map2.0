using UnityEngine;

public class EarthOrbit : MonoBehaviour
{
    public Transform moon; // Reference to the Moon GameObject.
    public float rotationSpeed = 10.0f; // Rotation speed of Earth on its own axis (degrees per second).
    public float orbitSpeed = 30.0f; // Orbit speed around the Moon (degrees per second).
    public Vector3 orbitAxis = Vector3.up; // Axis around which Earth orbits the Moon.
    public float orbitalRadius = 5.0f; // Radius of the Earth's orbital circle.

    private LineRenderer orbitPath;

    void Start()
    {
        // Create and configure the LineRenderer for the orbit path.
        orbitPath = gameObject.AddComponent<LineRenderer>();
        orbitPath.positionCount = 360; // Number of line segments to create a circle.
        orbitPath.startWidth = 0.1f; // Width of the line.
        orbitPath.endWidth = 0.1f;

        // Set the Earth's initial position.
        UpdateOrbitPath();
    }

    void Update()
    {
        // Rotate Earth on its own axis.
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Orbit around the Moon.
        OrbitAroundMoon();
    }

    void OrbitAroundMoon()
    {
        if (moon != null)
        {
            // Calculate the orbit rotation.
            Quaternion orbitRotation = Quaternion.AngleAxis(orbitSpeed * Time.deltaTime, orbitAxis);

            // Apply the orbit rotation relative to the Moon's position.
            transform.position = orbitRotation * (transform.position - moon.position) + moon.position;
            transform.rotation = orbitRotation * transform.rotation;

            // Update the orbit path.
            UpdateOrbitPath();
        }
    }

    void UpdateOrbitPath()
    {
        // Draw a circle for the orbit path.
        for (int i = 0; i < 360; i++)
        {
            float angle = i * Mathf.Deg2Rad;
            float x = Mathf.Cos(angle) * orbitalRadius;
            float z = Mathf.Sin(angle) * orbitalRadius;
            Vector3 point = new Vector3(x, transform.position.y, z);
            orbitPath.SetPosition(i, point);
        }
    }
}
