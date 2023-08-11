using System.Collections;
using UnityEngine;

public class LightOnOff : MonoBehaviour
{
    public GameObject RedLight;
    public GameObject AreaLight;

    private bool l = false;

    private void OnMouseUp()
    {
        if (l)
        {
            RedLight.GetComponent<Light>().enabled = true;
            AreaLight.GetComponent<Light>().enabled = false;
            l = false;
        }
        else
        {
            RedLight.GetComponent<Light>().enabled = false;
            AreaLight.GetComponent<Light>().enabled = true;
            l = true;
        }
    }
}
