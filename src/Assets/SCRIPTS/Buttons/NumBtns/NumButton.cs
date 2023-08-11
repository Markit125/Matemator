using System.Collections;
using UnityEngine;

public class NumButton : MonoBehaviour
{
    public GameObject Processor;
    private void OnMouseUp()
    {
        string s = " ";
        if (name[3] == '—') s = "";
        Processor.GetComponent<ProcessNum>().I(s + name[3]);
    }
}
