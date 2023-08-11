using System.Collections;
using UnityEngine;
using TMPro;

public class RulesBtn : MonoBehaviour
{
    public GameObject Monitor;
    public GameObject Screen;
    public GameObject Processor;
    public GameObject r0;
    public GameObject r1;
    public GameObject r2;
    public GameObject r3;

    private bool a = false;

    private void OnMouseUp()
    {
        if (a)
        {
            Destroy(r3);
            Destroy(r2);
            Destroy(r1);
            Destroy(r0);
            Monitor.GetComponent<Animation>().Play("RulesUp");
            Screen.GetComponent<Animation>().Play("4562");
            GetComponent<Animation>().Play("1232");
            StartCoroutine(FullDestruction());
        }
        else
        {
            r0.GetComponent<TMP_Text>().enabled = true;
            r1.GetComponent<TMP_Text>().enabled = true;
            r2.GetComponent<TMP_Text>().enabled = true;
            r3.GetComponent<TMP_Text>().enabled = true;
            a = true;
        }
    }

    private IEnumerator FullDestruction()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(Monitor);
        Destroy(Screen);
        Destroy(gameObject);
    }

    private void Update()
    {
        if (!Processor.GetComponent<Settings>().menu && !a)
        {
            a = true;
            StartCoroutine(FullDestruction());
            Destroy(r3);
            Destroy(r2);
            Destroy(r1);
            Destroy(r0);
        }
    }
}
