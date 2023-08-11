using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HisDown : MonoBehaviour
{
    public GameObject Processor;

    private Settings sts;
    private TMP_Text[] HisIn;
    private TMP_Text[] HisOut;
    private List<string> histi;
    private List<string> histo;

    private void Start()
    {
        sts = Processor.GetComponent<Settings>();
        HisIn = sts.HisIn;
        HisOut = sts.HisOut;
        histi = sts.histi;
        histo = sts.histo;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow)) hisdown();
    }

    private void OnMouseUp()
    {
        hisdown();
    }

    private void hisdown()
    {
        if (histi.Count > 8 && sts.lasts < histi.Count)
        {
            sts.lasts++;
            for (int i = 0; i < 8; i++)
            {
                HisIn[i].text = histi[sts.lasts - 8 + i];
                HisOut[i].text = histo[sts.lasts - 8 + i];
            }
        }
    }
}
