using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class InputBtn : MonoBehaviour
{
    public GameObject[] Difficultometer;
    public GameObject Processor;
    public GameObject Dozator;
    public GameObject Closer;
    public GameObject tmp;
    public Text memory;
    public int CountLvls;
    public string lvl;
    public string pa;
    public byte ansi;
    public byte countSlots;
    public byte numIn;
    public Material[] Materials;

    private GameObject[] ObjectNum;
    private GameObject[] ObjectAns;
    private Levels wtd;
    private Settings sts;
    private TMP_Text tmt;
    private TMP_Text[] HisIn;
    private TMP_Text[] HisOut;
    private List<string> histi;
    private List<string> histo;

    private void Start()
    {
        tmt = tmp.GetComponent<TMP_Text>();
        sts = Processor.GetComponent<Settings>();
        wtd = Processor.GetComponent<Levels>();
        HisIn = sts.HisIn;
        HisOut = sts.HisOut;
        histi = sts.histi;
        histo = sts.histo;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)) Tap();
    }

    private void OnMouseUp()
    {
        Tap();
    }

    private void Tap()
    {
        if (!sts.inputing)
        {
            if (sts.CurrentLvl != "") lvl = sts.CurrentLvl;
            else lvl = memory.text;
            
            if (sts.menu && memory.text != "" && int.TryParse(lvl, out _)) // in menu with inputed lvl
            {
                lvl = int.Parse(lvl).ToString();
                byte di = 0;
                if (wtd.elementary.Contains(lvl)) di = 1;
                else if (wtd.easy.Contains(lvl)) di = 2;
                else if (wtd.medium.Contains(lvl)) di = 3;
                else if (wtd.hard.Contains(lvl)) di = 4;
                else if (wtd.impossible.Contains(lvl)) di = 5;
                Difficultometer[di - 1].GetComponent<MeshRenderer>().material = Materials[di];
                if (int.Parse(lvl) < CountLvls)
                {
                    sts.end = false;
                    sts.CurrentLvl = memory.text;
                    if (sts.lastlvl != sts.CurrentLvl) HistClear();
                    sts.menu = false;
                    countSlots = wtd.slots[int.Parse(lvl)];
                    numIn = 0;
                    string countInputs = "";
                    if (countSlots > 1) countInputs = "   первое";
                    tmt.text = "Уровень " + lvl + "\nВведите" + countInputs + "   число:\n";
                    memory.text = "";
                }
                else
                {
                    tmt.text = "Такого   уровня   ещё   нет\nВведите  номер   поменьше:\n";
                    memory.text = "";
                }
            }
            else if (!sts.menu && int.TryParse(memory.text, out _) && !sts.test) // in lvl with normal inputed num
            {
                StartCoroutine(DelIn());
                ObjectAns = GameObject.FindGameObjectsWithTag("Finish");
                if (ObjectAns.Length > 0) StartCoroutine(Delans());
                wtd.input[numIn] = int.Parse(memory.text);
                if (numIn + 1 < countSlots)
                {
                    numIn++;
                    string countInputs = "   второе";
                    if (numIn == 2)
                    {
                        sts.inputches[1] = memory.text;
                        countInputs = "   третье";
                    }
                    else sts.inputches[0] = memory.text;
                    tmt.text = "Уровень " + lvl + "\nВведите" + countInputs + "   число:\n";
                }
                else
                {
                    wtd.work = true;
                    sts.inputches[2] = memory.text;
                }
                memory.text = "";
            }
            else if (!int.TryParse(memory.text, out _) && memory.text != "") // in lvl with inputed invalid num
            {
                memory.text = "";
                tmt.text = "Уровень " + lvl + "\nНекорректный   ввод\nВведите   число:\n";
                numIn = 0;
                StartCoroutine(sts.Deller());
            }
            if (wtd.a[0, 0] != -32768 && sts.test && sts.vvod && memory.text != "") // vvod during testing
            {
                ObjectAns = GameObject.FindGameObjectsWithTag("Finish");
                if (ObjectAns.Length > 0) StartCoroutine(Delans());
                pa = memory.text;
                if (ansi == 0) ansi = wtd.count;
                for (byte k = 0; k < 3; k++)
                    wtd.input[k] = wtd.a[wtd.count - ansi, k];
                wtd.work = true;
                wtd.stop = true;
                ansi--;
                sts.vvod = false;
            }
            sts.vvod = false;
        }
    }

    private IEnumerator DelIn()
    {
        sts.canans = false;
        yield return new WaitForSeconds(0.1f);
        Dozator.GetComponent<Animation>().Play("DoUpD");
        yield return new WaitForSeconds(0.8f);
        ObjectNum = GameObject.FindGameObjectsWithTag("Respawn");
        for (int i = 0; i < ObjectNum.Length; i++)
            if (ObjectNum[i] != null)
            {
                ObjectNum[i].GetComponent<Rigidbody>().velocity += new Vector3(-20f, 0, 0);
                yield return new WaitForSeconds(0.05f);
            }
        Dozator.GetComponent<Animation>().Play("DoDownD");
        yield return new WaitForSeconds(2f);
        sts.canans = true;
    }

    private IEnumerator Delans()
    {
        ObjectAns = GameObject.FindGameObjectsWithTag("Finish");
        Closer.GetComponent<Animation>().Play("DoDownC");
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < ObjectAns.Length; i++) Destroy(ObjectAns[i]);
        Closer.GetComponent<Animation>().Play("DoUpC");
    }

    private void HistClear()
    {
        for (int i = 0; i < 8; i++)
        {
            HisIn[i].text = "";
            HisOut[i].text = "";
            histi.Clear();
            histo.Clear();
            sts.lasts = 0;
        }
    }
}
