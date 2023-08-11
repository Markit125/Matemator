using System.Collections;
using UnityEngine;

public class Interface : MonoBehaviour
{
    public GameObject CamS;
    public GameObject CamB;

    private bool I = true;

    private void OnMouseUp()
    {
        if (I)
        {
            CamS.GetComponent<Camera>().enabled = false;
            CamB.GetComponent<Camera>().enabled = true;
            I = false;
        }
        else
        {
            CamB.GetComponent<Camera>().enabled = false;
            CamS.GetComponent<Camera>().enabled = true;
            I = true;
        }
    }
}
