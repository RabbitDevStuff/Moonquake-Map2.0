using UnityEngine;
using UnityEngine.UI;

public class DisplayLatLong : MonoBehaviour
{
    public Text latLongText;
    public Camera cam;
    public float radius = 1f;

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
}