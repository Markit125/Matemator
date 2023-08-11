using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{
    public bool menu = true;
    public bool candel = false;
    public bool test = false;
    public bool canans = false;
    public bool outing = false;
    public bool inputing = false;
    public bool vvod = false;
    public bool end = false;
    public bool firstone;

    public string CurrentLvl;
    public string lastlvl;
    public Text memory;
    public GameObject Readybtn;
    public GameObject InputTap;
    public GameObject Dozator;
    public GameObject Limit;
    public GameObject CubeIO;
    public GameObject tmp;
    public GameObject CubeText;

    public TMP_Text[] HisIn = new TMP_Text[8];
    public TMP_Text[] HisOut = new TMP_Text[8];
    public List<string> histi = new List<string>();
    public List<string> histo = new List<string>();
    public int lasts = 0;
    public byte nextIn;
    public string[] inputches;

    private bool fallans = false;
    private bool limit = false;
    private float answer;
    private InputBtn ibtn;
    private Levels levels;
    private GameObject[] ObjectNum;
    private TMP_Text tmt;

    private void Start()
    {
        for(int i = 0; i < 8; i++)
        {
            HisIn[i].text = "";
            HisOut[i].text = "";
        }
        inputches = new string[] { "", "", "" };
        ibtn = InputTap.GetComponent<InputBtn>();
        tmt = tmp.GetComponent<TMP_Text>();
        levels = GetComponent<Levels>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) Application.Quit();

        if (memory.text.Length > 8 && !limit)
        {
            Limit.GetComponent<Animation>().Play("GoA");
            limit = true;
        }
        else if (memory.text.Length <= 8 && limit)
        {
            Limit.GetComponent<Animation>().Play("GoB");
            limit = false;
        }
        
        if (ibtn.pa != "" && test) // After inputing during test
        {
            if (int.Parse(ibtn.pa) == levels.output && ibtn.ansi > 0)
            {
                ibtn.numIn = 0;
                tmt.text = "Верно!                          Тест " + (levels.count - ibtn.ansi + 1).ToString() + "/" + levels.count;
                string sec = "";
                
                if (levels.a[levels.count - ibtn.ansi, 1] != -32768) sec = "    " + levels.a[levels.count - ibtn.ansi, 1].ToString();
                tmt.text += "\nВвод:\n" + levels.a[levels.count - ibtn.ansi, 0].ToString() + sec + "\nВведите предполагаемый вывод:\n";
                StartCoroutine(Injant(levels.a[levels.count - ibtn.ansi, 0].ToString())); // output
                outing = true;
                StartCoroutine(Out(levels.output.ToString()));
            }
            else if (ibtn.ansi == 0 && int.Parse(ibtn.pa) == levels.output)
            {   
                outing = true;
                StartCoroutine(Out(levels.output.ToString()));
                StartCoroutine(WaitOuting());
                tmt.text = "Уровень   " + CurrentLvl + "   пройден!";
                ibtn.numIn = 0;
                StartCoroutine(Deller());
            }
            else
            {
                Endlvl();
                StartCoroutine(Dovodchik());
                tmt.text = "Неверно!\nНажмите   на   кнопу   готонвости,   чтобы   снова   пройти   тестирование.";
                StartCoroutine(Deller());
            }
            ibtn.pa = "";
        }

        if (levels.work && !fallans) fallans = true;
        else if (!levels.work && fallans && !test && canans && ibtn.numIn + 1 == ibtn.countSlots)
        {
            int l = tmt.text.Length;
            if (tmt.text[l - 1].Equals('_'))
                tmt.text = tmt.text.Remove(l - 1);
            answer = levels.output;
            outing = true;
            StartCoroutine(Out(answer.ToString()));
            StartCoroutine(Deller());

            string countInputs = "";
            if (ibtn.countSlots > 1) countInputs = "     первое";
            tmt.text = "Уровень " + int.Parse(CurrentLvl).ToString() + "\nОтвет:\n" + answer.ToString() + "\nВведите" + countInputs + "   число:\n";
            levels.stop = true;
            fallans = false;
            canans = false;
            ibtn.numIn = 0;
        }

        if (!vvod && !candel)
            candel = true;

        if (candel && !menu && !end)
        {
            Clean();
            candel = false;
            vvod = true;
        }

        if (firstone && levels.a[0, 0] != -32768 && test)
        {
            ibtn.countSlots = levels.slots[int.Parse(ibtn.lvl)];
            ibtn.ansi = levels.count;
            string sec = "";
            if (levels.a[0, 1] != -32768) sec = "    " + levels.a[0, 1].ToString();
            tmt.text = "Тест 1/" + levels.count + "\nВвод:\n" + levels.a[0, 0].ToString() + sec + "\nВведите предполагаемый вывод:\n";
            StartCoroutine(Injant(levels.a[0, 0].ToString()));
            firstone = false;
        }
    }

    private void Clean()
        {
            char[] Nums = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-', '.', '_' };
            int l, i;
            bool number = true;
            l = tmt.text.Length;
            i = 1;
            while (number)
            {
                number = false;
                for (int c = 0; c < 13; c++)
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

    private IEnumerator Injant(string s) // Input during test
    {
        for (int i = 0; i < s.Length; i++)
        {
            GameObject Cube = Instantiate(CubeIO, new Vector3(7.17f, 4.278f, Random.Range(-0.357f, -0.363f)), Quaternion.identity);
            GameObject tx = Instantiate(CubeText, new Vector3(7.22f, 4.26f, -0.576f), Quaternion.identity);
            if (s[i] != '-') tx.GetComponent<TextMeshPro>().text = (" " + s[i]).ToString();
            else tx.GetComponent<TextMeshPro>().text = "—";
            Cube.GetComponent<FixedJoint>().connectedBody = tx.GetComponent<Rigidbody>();
            Cube.GetComponent<Rigidbody>().velocity += new Vector3(-15f, 0, 0);
            yield return new WaitForSeconds(0.05f);
        }
        StartCoroutine(DelIn());
    }

    private IEnumerator DelIn() // integration nums in Matemator
    {
        Dozator.GetComponent<Animation>().Play("DoUpD");
        yield return new WaitForSeconds(0.7f);
        ObjectNum = GameObject.FindGameObjectsWithTag("Respawn");
        for (int i = 0; i < ObjectNum.Length; i++)
            if (ObjectNum[i] != null)
                if (ObjectNum[i].GetComponent<Transform>().position.y > 4f)
                {
                    ObjectNum[i].GetComponent<Rigidbody>().velocity += new Vector3(-21f, 0, 0);
                    yield return new WaitForSeconds(0.05f);
                }
        yield return new WaitForSeconds(0.05f);
        Dozator.GetComponent<Animation>().Play("DoDownD");
        if (ibtn.countSlots - 1 > ibtn.numIn)
        {
            ibtn.numIn++;
            StartCoroutine(Injant(levels.a[levels.count - ibtn.ansi, ibtn.numIn].ToString()));
        }
    }

    public IEnumerator Deller()
    {
        ObjectNum = GameObject.FindGameObjectsWithTag("Respawn");
        for (int i = 0; i < ObjectNum.Length; i++)
            if (ObjectNum[ObjectNum.Length - i - 1] != null)
                ObjectNum[ObjectNum.Length - i - 1].GetComponent<Transform>().position += new Vector3(0f, 0f, 0.9f);
        for (int i = 0; i < ObjectNum.Length; i += 2)
            if (ObjectNum[ObjectNum.Length - i - 1] != null && ObjectNum[ObjectNum.Length - i - 2] != null)
            {
                if (ObjectNum[ObjectNum.Length - i - 1].GetComponent<Transform>().position.y > 4f)
                    ObjectNum[ObjectNum.Length - i - 2].GetComponent<Rigidbody>().velocity += new Vector3(40f, 0, 0);
                yield return new WaitForSeconds(0.25f);
                if (i < ObjectNum.Length)
                    if (ObjectNum[ObjectNum.Length - i - 1] != null && ObjectNum[ObjectNum.Length - i - 2] != null)
                    {
                        Destroy(ObjectNum[ObjectNum.Length - i - 1]);
                        Destroy(ObjectNum[ObjectNum.Length - i - 2]);
                    }
            }
    }

    private IEnumerator Out(string s) // output answer from Matemator
    {
        if (!test)
        {
            byte k = 1;
            if (inputches[0] != "")
            {
                histi.Add(inputches[0]);
                histo.Add("");
                History(s, inputches[0], k);
                k++;
            }
            if (inputches[1] != "")
            {
                histi.Add(inputches[1]);
                histo.Add("");
                History(s, inputches[1], k);
                k++;
            }
            histi.Add(inputches[2]);
            histo.Add(s);
            lasts = histi.Count;
            History(s, inputches[2], k);
            for (byte j = 0; j < 3; j++)
                inputches[j] = "";
        }
        else yield return new WaitForSeconds(0.5f);

        string outCubeText = "";
        for (int i = 0; i < s.Length; i++)
        {
            GameObject Cube = Instantiate(CubeIO, new Vector3(-1.39f, -2.65f, -0.397f), Quaternion.identity);
            GameObject tx = Instantiate(CubeText, new Vector3(-1.34f, -2.7f, -0.6f), Quaternion.identity);
            Cube.tag = "Finish";
            tx.tag = "Finish";

            if ("0123465789,".Contains(s[s.Length - i - 1].ToString())) outCubeText = (" " + s[s.Length - i - 1]).ToString();
            else
            {
                if (s[s.Length - i - 1] == '+') outCubeText = " +";
                else if (s[s.Length - i - 1] == '-') outCubeText = "—";
                else outCubeText = " E";
            }

            tx.GetComponent<TextMeshPro>().text = outCubeText;
            Cube.GetComponent<FixedJoint>().connectedBody = tx.GetComponent<Rigidbody>();
            Cube.GetComponent<Rigidbody>().velocity += new Vector3(10f, 0, 0);
            yield return new WaitForSeconds(0.05f);
        }
        inputing = false;
        outing = false;
        StartCoroutine(Dovodchik());
    }

    private void History(string s, string input, byte k)
    {
        if (HisIn[6].text == "")
        {
            for (int i = 0; i < 7; i++)
                if (HisIn[i].text == "")
                {
                    HisIn[i].text = input;
                    if (k < ibtn.countSlots) HisOut[i].text = "";
                    else HisOut[i].text = s;
                    break;
                }
        }
        else
        {
            if (HisIn[7].text != "")
                for (int i = 0; i < 8; i++)
                    if (histi.Count >= 8)
                    {
                        HisIn[i].text = histi[histi.Count - 8 + i];
                        HisOut[i].text = histo[histo.Count - 8 + i];
                    }
            HisIn[7].text = input;
            HisOut[7].text = s;
        }
    }

    private IEnumerator WaitOuting()
    {
        yield return new WaitForSeconds(0.1f);
        Endlvl();
    }

    private IEnumerator Dovodchik()
    {
        GameObject[] g;
        g = GameObject.FindGameObjectsWithTag("Finish");
        byte x = 0;
        while (x < 20)
        {
            yield return new WaitForSeconds(0.05f);
            for (byte i = 0; i < g.Length; i++) if (g[i] != null) g[i].GetComponent<Rigidbody>().velocity += new Vector3(1f, 0, 0);
            x++;
        }
    }

    public void Endlvl()
    {
        levels.masready = false;
        canans = false;
        vvod = false;
        test = false;
        end = true;
        levels.stop = true;
        memory.text = "";
        levels.input = new int[3];
        levels.output = 0;
        ibtn.ansi = 0;
        ibtn.pa = "";
        for (byte i = 0; i < 8; i++)
            for (byte j = 0; j < 3; j++)
                if (j > 0) levels.a[i, j] = -32768;
                else levels.a[i, j] = 0;
        levels.a[0, 0] = -32768;
        ibtn.numIn = 0;
        for (byte j = 0; j < 3; j++)
            inputches[j] = "";
        for (byte j = 0; j < 5; j++)
            ibtn.Difficultometer[j].GetComponent<MeshRenderer>().material = ibtn.Materials[0];
    }
}