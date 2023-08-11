using System.Collections;
using UnityEngine;

public class CoverDU : MonoBehaviour
{
    public GameObject Processor;
    public bool m;
    public bool u = true;
    public bool d = false;

    private void Update()
    {
        m = Processor.GetComponent<Settings>().menu;
        if (m && d)
        {
            GetComponent<Animation>().Play("UpCover");
            d = false;
            u = true;
        }
        else if(!m && u)
        {
            GetComponent<Animation>().Play("DownCover");
            u = false;
            d = true;
        }
    }
}
