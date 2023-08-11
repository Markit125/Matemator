using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CleanNums : MonoBehaviour
{
    public Text outt;
    public Text memory;
    public GameObject Processor;
    public GameObject tmp;

    private int i;
    private int l;
    private bool number;
    private TMP_Text tmt;
    private GameObject[] ObjectNum;
    private char[] Nums = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-', '_' };

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Backspace))) C();
    }

    private void OnMouseUp()
    {
        C();
    }

    private void C()
    {
        tmt = tmp.GetComponent<TMP_Text>();
        Clean();
        if (!Processor.GetComponent<Settings>().test) StartCoroutine(Processor.GetComponent<Settings>().Deller());
    }

    private void Clean()
    {
        Processor.GetComponent<Settings>().inputing = false;
        number = true;
        l = tmt.text.Length;
        i = 1;
        while (number)
        {
            number = false;
            for (int c = 0; c < 12; c++)
                if (tmt.text[l - i].Equals(Nums[c]))
                {
                    tmt.text = tmt.text.Remove(l - i);
                    number = true;
                    break;
                }
            i++;
        }
        memory.text = "";
    }
}