using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Ready : MonoBehaviour
{
    public GameObject Processor;
    public GameObject tmp;
    public GameObject InputTap;
    public Text memory;

    private GameObject[] ObjectNum;
    private Settings sts;
    private Levels levels;
    private InputBtn ibtn;

    private void Start()
    {
        sts = Processor.GetComponent<Settings>();
        levels = Processor.GetComponent<Levels>();
        ibtn = InputTap.GetComponent<InputBtn>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) Rd();
    }

    private void OnMouseUp()
    {
        Rd();
    }

    private void Rd()
    {
        if (!sts.menu && !sts.inputing)
        {
            StartCoroutine(Deller());
            sts.test = true;
            sts.firstone = true;
            sts.end = false;
            levels.masready = false;
            ibtn.ansi = 0;
            ibtn.pa = "";
            ibtn.numIn = 0;
            memory.text = "";
        }
    }

    private IEnumerator Deller()
    {
        ObjectNum = GameObject.FindGameObjectsWithTag("Respawn");
        for (int i = 0; i < ObjectNum.Length; i++)
        {
            yield return new WaitForSeconds(0.2f);
            if (ObjectNum.Length - i - 1 >= 0)
                if (ObjectNum[ObjectNum.Length - i - 1] != null)
                    Destroy(ObjectNum[ObjectNum.Length - i - 1]);
        }
    }
}
