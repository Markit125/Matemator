using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HisPageUp : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.PageUp)) pageup();
    }
    private void OnMouseUp()
    {
        pageup();
    }

    private void pageup()
    {
        if (histi.Count > 8 && sts.lasts > 8)
        {
            sts.lasts -= 8;
            if (sts.lasts > 8)
                for (int i = 0; i < 8; i++)
                {
                    HisIn[i].text = histi[sts.lasts - 8 + i];
                    HisOut[i].text = histo[sts.lasts - 8 + i];
                }
            else
            {
                sts.lasts = 8;
                for (int i = 0; i < 8; i++)
                {
                    HisIn[i].text = histi[i];
                    HisOut[i].text = histo[i];
                }
            }
        }
    }
}
