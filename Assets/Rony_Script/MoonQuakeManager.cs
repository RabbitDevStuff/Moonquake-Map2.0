using UnityEngine;

public class MoonQuakeManager : MonoBehaviour
{
    public GameObject[] moonQuakeZoneObjects; // An array of Moon Quake Zone Objects
    public GameObject[] moonQuakeDetailsPanelObjects; // An array of Moon Quake Details Panel Objects
    public GameObject[] vcamObjects; // An array of Cinemachine Virtual Camera GameObjects

    private int activeZoneIndex = -1; // Index of the currently active Moon Quake Zone Object

    public void ActivateMoonQuakeZone(int index)
    {
        ActivateObjectByIndex(moonQuakeZoneObjects, index);
        activeZoneIndex = index;
    }

    public void ActivateMoonQuakeDetailsPanel(int index)
    {
        ActivateObjectByIndex(moonQuakeDetailsPanelObjects, index);
    }

    public void ActivateVcam(int index)
    {
        ActivateObjectByIndex(vcamObjects, index);
    }

    private void ActivateObjectByIndex(GameObject[] objects, int index)
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i] != null)
            {
                objects[i].SetActive(i == index);
            }
        }
    }
}
