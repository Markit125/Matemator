using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpotSpace : MonoBehaviour
{
    public bool lost;
    public GameObject Processor;

    private Text txt;
    private string s;
    private char c;
    private float tm;
    private TMP_Text tmt;

    private void Start()
    {
        tmt = GetComponent<TMP_Text>();
        tmt.text += '_';
        tm = Time.time;
        lost = false;
    }

    private void Update()
    {
        tmt = GetComponent<TMP_Text>();
        if (Processor.GetComponent<Settings>().vvod || Processor.GetComponent<Settings>().CurrentLvl == "")
        {
            if (Time.time - tm > 0.8f && lost)
            {
                tmt.text += '_';
                tm = Time.time;
                lost = false;
            }
            else if (Time.time - tm > 1f && !lost)
            {
                int l = tmt.text.Length;
                int i = 1;
                s = tmt.text;
                c = s[l - i];
                while (!c.Equals('_') && i < 3)
                {
                    i++;
                    c = s[l - i];
                }
                if (i < 3)
                    tmt.text = tmt.text.Remove(l - i, 1);

                tm = Time.time;
                lost = true;
            }
        }
    }
}
