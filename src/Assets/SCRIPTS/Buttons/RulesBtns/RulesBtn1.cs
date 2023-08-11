using System.Collections;
using UnityEngine;

public class RulesBtn1 : MonoBehaviour
{
    public GameObject Monitor;
    public GameObject Processor;
    public GameObject btn;
    public GameObject Screen;
    public GameObject Rules;

    private bool a = true;

    private void OnMouseUp()
    {
        a = false;
        Monitor.GetComponent<Animation>().Play("RulesDown");
        Screen.GetComponent<Animation>().Play("456");
        btn.GetComponent<Animation>().Play("123");
        GetComponent<Animation>().Play("RulesoutB");
        Rules.GetComponent<Animation>().Play("Rulesout");
        StartCoroutine(Rolsout());
    }
    private void Update()
    {
        if (!Processor.GetComponent<Settings>().menu && a)
        {
            a = false;
            GetComponent<Animation>().Play("RulesoutB");
            Rules.GetComponent<Animation>().Play("Rulesout");
            StartCoroutine("Rolsout");
        }
    }
    private IEnumerator Rolsout()
    {
        yield return new WaitForSeconds(2f);
        Destroy(Rules);
        Destroy(gameObject);
    }
}
