using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class DrawLongitudeLines : MonoBehaviour
{
    public int numberOfLongitudeLines = 10;
    public int numberOfLatitudeLines = 5;
    public float radius = 1f;

    public Material lineMaterial;

    List<GameObject> lineRendererList = new List<GameObject>();
    bool isOn;
    [SerializeField] Text toogleText;

    void Start()
    {
        isOn = false;
        GenerateLongitude();
        DisableLongitude();
        toogleText.text = "Off";
    }

    public void EnableLongitude()
    {
        if(!isOn)
        {
            isOn = true;
            foreach (GameObject line in lineRendererList)
            {
                line.SetActive(true);
            }
            toogleText.text = "On";
        }
        else
        {
            isOn = false;
            DisableLongitude();
        }
    }
    
    public void DisableLongitude()
    {
        foreach (GameObject line in lineRendererList)
        {
            line.SetActive(false);
        }
        toogleText.text = "Off";
    }


    public void GenerateLongitude()
    {
        for (int i = 0; i <= numberOfLongitudeLines; i++)
        {
            GameObject longitudeLine = new GameObject();
            lineRendererList.Add(longitudeLine);
            longitudeLine.transform.parent = transform;
            LineRenderer longitudeLR = longitudeLine.AddComponent<LineRenderer>();
            longitudeLR.material = lineMaterial;
            //longitudeLR.startColor = longitudeLR.endColor = Color.red;
            longitudeLR.startWidth = longitudeLR.endWidth = 0.025f;
            longitudeLR.positionCount = numberOfLatitudeLines + 1;

            float theta = (360f / numberOfLongitudeLines) * i;
            float thetaRadians = theta * Mathf.Deg2Rad;

            for (int j = 0; j <= numberOfLatitudeLines; j++)
            {
                float phi = (180f / numberOfLatitudeLines) * j - 90f;
                float phiRadians = phi * Mathf.Deg2Rad;

                // Calculate positions, rotating the latitude by 90 degrees along the Y-axis
                float x = radius * Mathf.Cos(phiRadians) * Mathf.Cos(thetaRadians);
                float y = radius * Mathf.Sin(phiRadians);
                float z = radius * Mathf.Cos(phiRadians) * Mathf.Sin(thetaRadians);

                longitudeLR.SetPosition(j, new Vector3(x, y, z));
            }
        }
    }

}
