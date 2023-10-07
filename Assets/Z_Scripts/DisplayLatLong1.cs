using UnityEngine;

public class DisplayLatLong1 : MonoBehaviour
{
    public Transform moon; // Assign your moon object here in the inspector
    public float moonRadius = 3.03f; // Set this to the radius of your moon

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == moon)
                {
                    Vector3 localPos = moon.InverseTransformPoint(hit.point);
                    Vector3 normalizedLocalPos = localPos.normalized;

                    float latitude = 90 - Mathf.Acos(normalizedLocalPos.y) * Mathf.Rad2Deg;
                    float longitude = Mathf.Atan2(normalizedLocalPos.z, normalizedLocalPos.x) * Mathf.Rad2Deg;

                    Debug.Log("Latitude: " + latitude + ", Longitude: " + longitude);
                }
            }
        }
    }
}