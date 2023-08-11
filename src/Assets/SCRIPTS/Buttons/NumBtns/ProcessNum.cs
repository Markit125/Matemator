using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProcessNum : MonoBehaviour
{
    public GameObject CubIn;
    public GameObject Screen;
    public GameObject InTxt;
    public Text memory;
    
    private TMP_Text tmt;
    private Settings sts;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadMinus) || Input.GetKeyDown(KeyCode.Minus)) I("—");
        else if (Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown(KeyCode.Alpha0)) I(" 0");
        else if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1)) I(" 1");
        else if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2)) I(" 2");
        else if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3)) I(" 3");
        else if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4)) I(" 4");
        else if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Alpha5)) I(" 5");
        else if (Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.Alpha6)) I(" 6");
        else if (Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.Alpha7)) I(" 7");
        else if (Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Alpha8)) I(" 8");
        else if (Input.GetKeyDown(KeyCode.Keypad9) || Input.GetKeyDown(KeyCode.Alpha9)) I(" 9");
    }

    public void I(string number)
    {
        tmt = Screen.GetComponent<TMP_Text>();
        sts = GetComponent<Settings>();
        if (sts.vvod && !sts.inputing && memory.text.Length < 17 && tmt.text[0] != 'П')
        {
            Screen.GetComponent<SpotSpace>().enabled = false;
            int l = tmt.text.Length;
            if (tmt.text[l - 1].Equals('_'))
                tmt.text = tmt.text.Remove(l - 1);

            string symbol;
            if (number[0] != ' ') symbol = "-";
            else symbol = number[1].ToString();
            memory.text += symbol;
            tmt.text += symbol + '_';

            Screen.GetComponent<SpotSpace>().lost = false;
            Screen.GetComponent<SpotSpace>().enabled = true;
            if (!sts.test)
            {
                GameObject Cube = Instantiate(CubIn, new Vector3(9.5f, 4.278f, Random.Range(-0.357f, -0.363f)), Quaternion.identity);
                GameObject tx = Instantiate(InTxt, new Vector3(9.547f, 4.235f, -0.576f), Quaternion.identity);
                tx.GetComponent<TextMeshPro>().text = number;

                Cube.GetComponent<FixedJoint>().connectedBody = tx.GetComponent<Rigidbody>();
                Cube.GetComponent<Rigidbody>().velocity += new Vector3(-13f, 0, 0);
            }
        }
    }
}