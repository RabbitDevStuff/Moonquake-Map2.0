using UnityEngine;

public class MoonQuakeMap : MonoBehaviour
{
    public Transform moonSurface; // Reference to your Moon's 3D model
    public GameObject moonquakeMarkerPrefab; // Prefab for moonquake event markers

    // The actual radius of the Moon in meters
    private float moonRealRadius = 1737100.0f;


    void Start()
    {
        CreateMoonquakeMarker(26, 3);
        Debug.Log("Marked");
    }

    public void CreateMoonquakeMarker(float latitude, float longitude)
    {
        // Determine the scaling factor based on the model size
        float scalingFactor = moonRealRadius / (Mathf.Max(moonSurface.localScale.x, moonSurface.localScale.y, moonSurface.localScale.z) * 0.5f);

        // Convert latitude and longitude to radians
        float theta = (90.0f - latitude) * Mathf.Deg2Rad;
        float phi = (longitude + 180.0f) * Mathf.Deg2Rad;

        // Calculate 3D position with the scaled radius
        float x = scalingFactor * Mathf.Sin(theta) * Mathf.Cos(phi);
        float y = scalingFactor * Mathf.Sin(theta) * Mathf.Sin(phi);
        float z = scalingFactor * Mathf.Cos(theta);

        // Instantiate a moonquake event marker at the calculated position
        Vector3 moonquakePosition = new Vector3(x, y, z);
        Instantiate(moonquakeMarkerPrefab, moonquakePosition, Quaternion.identity, moonSurface);
    }
}
