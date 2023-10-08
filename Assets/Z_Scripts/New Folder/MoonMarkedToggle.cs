using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoonMarkedToggle : MonoBehaviour
{
    public Material[] materials;
    public int x;
    Renderer rend;

    [SerializeField] Text toggleText;

    void Start()
    {
        x=0;
        rend = GetComponent<Renderer>();
        rend.sharedMaterial = materials[x];

        toggleText.text = "Off";

    }

    public void ChangeMat()
    {
        if(x<1)
        {
            x++;
            rend.sharedMaterial = materials[x];
            toggleText.text = "On";
        }
        else
        {
            x = 0;
            rend.sharedMaterial = materials[x];
            toggleText.text = "Off";
        }
    }

}
