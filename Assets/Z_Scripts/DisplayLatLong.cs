using UnityEngine;
using UnityEngine.UI;

public class DisplayLatLong : MonoBehaviour
{
    public Text latLongText;
    public Camera cam;
    public float radius = 300f;

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 pos = hit.point;
            float latitude = Mathf.Asin(pos.y / radius) * Mathf.Rad2Deg;
            float longitude = Mathf.Atan2(pos.z, pos.x) * Mathf.Rad2Deg;

            latLongText.text = "Latitude: " + latitude.ToString("F2") + ", Longitude: " + longitude.ToString("F2");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green; // Set the Gizmos color

        // Draw a sphere Gizmo at the GameObject's position
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
