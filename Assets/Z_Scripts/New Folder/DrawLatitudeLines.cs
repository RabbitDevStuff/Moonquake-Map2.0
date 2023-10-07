using UnityEngine;
using System.Collections.Generic;

public class DrawLatitudeLines : MonoBehaviour
{
    public int numberOfLines = 10;
    public float radius = 1f;
    public Material lineMaterial;

    List<GameObject> lineRendererList = new List<GameObject>();
    bool isOn;

    void Start()
    {
        isOn = false;
        GenerateLatitude();
        DisableLatitude();
    }

    public void EnableLatitude()
    {
        if(!isOn)
        {
            isOn = true;
            foreach (GameObject line in lineRendererList)
            {
                line.SetActive(true);
            }
        }
        else
        {
            isOn = false;
            DisableLatitude();
        }
    }
    
    public void DisableLatitude()
    {
        foreach (GameObject line in lineRendererList)
        {
            line.SetActive(false);
        }
    }


    public void GenerateLatitude()
    {
        for (int i = 0; i < numberOfLines; i++)
        {
            GameObject lineObject = new GameObject();
            lineRendererList.Add(lineObject);
            lineObject.transform.parent = this.transform;
            LineRenderer lineRenderer = lineObject.AddComponent<LineRenderer>();
            lineRenderer.material = lineMaterial;
            lineRenderer.widthMultiplier = 0.01f;

            float latitude = (i / (float)numberOfLines) * Mathf.PI - Mathf.PI / 2f;
            DrawLatitudeLine(lineRenderer, latitude);
        }
    }

    void DrawLatitudeLine(LineRenderer lineRenderer, float latitude)
    {
        int segments = 100;
        lineRenderer.positionCount = segments + 1;

        for (int i = 0; i <= segments; i++)
        {
            float longitude = (i / (float)segments) * Mathf.PI * 2f;
            Vector3 position = new Vector3(
                radius * Mathf.Cos(latitude) * Mathf.Cos(longitude),
                radius * Mathf.Sin(latitude),
                radius * Mathf.Cos(latitude) * Mathf.Sin(longitude)
            );
            lineRenderer.SetPosition(i, position);
        }
    }
}