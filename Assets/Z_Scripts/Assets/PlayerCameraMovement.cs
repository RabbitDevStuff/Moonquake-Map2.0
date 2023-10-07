using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraMovement : MonoBehaviour
{
    [SerializeField] public Camera cam;
    [SerializeField] private Transform target;
    private Vector3 previousPosition;

    float speed = 180f;


    float minFov = 35f;
    float maxFov = 100f;
    float sensitivity = 20f;


    void Start()
    {

    }


    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }

        if(Input.GetMouseButton(0))
        {
            Vector3 direction = previousPosition - cam.ScreenToViewportPoint(Input.mousePosition);

            cam.transform.position = target.position; //new Vector3();


            //direction.y = Mathf.Clamp(cam.transform.position.y , -90 , 90);

            cam.transform.Rotate(new Vector3( 1, 0 , 0) , direction.y  *  speed);

            cam.transform.Rotate(new Vector3(0 , 1, 0), -direction.x * speed , Space.World);
            cam.transform.Translate(new Vector3( 0 , 0, -20));

            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);

        }

        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * -sensitivity;
        fov = Mathf.Clamp(fov , minFov, maxFov);
        Camera.main.fieldOfView = fov;
    }
}
