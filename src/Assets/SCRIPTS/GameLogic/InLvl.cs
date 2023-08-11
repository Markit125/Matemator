using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InLvl : MonoBehaviour
{
	public GameObject MatematorBody;
	public GameObject tmp;
	public GameObject Processor;
	public GameObject InputTap;
	public Text memory;

	private string tagg;
	private string inputTxt;
	private Settings sts;
	private TMP_Text tmt;

	private void Start()
    {
		tmt = tmp.GetComponent<TMP_Text>();
		sts = Processor.GetComponent<Settings>();
	}

	private void OnTriggerEnter(Collider other)
	{
		MatematorBody.GetComponent<Animation>().Play("Barahlo");
		tmp.GetComponent<SpotSpace>().enabled = false;
		
		int l = tmt.text.Length;
		if (tmt.text[l - 1].Equals('_'))
			tmt.text = tmt.text.Remove(l - 1);
		
		tagg = other.tag;
		switch (tagg)
		{
			case "Num0": inputTxt = "0"; break;
			case "Num1": inputTxt = "1"; break;
			case "Num2": inputTxt = "2"; break;
			case "Num3": inputTxt = "3"; break;
			case "Num4": inputTxt = "4"; break;
			case "Num5": inputTxt = "5"; break;
			case "Num6": inputTxt = "6"; break;
			case "Num7": inputTxt = "7"; break;
			case "Num8": inputTxt = "8"; break;
			case "Num9": inputTxt = "9"; break; 
		}

		if (!sts.menu)
        {
			sts.Endlvl();
			StartCoroutine(sts.Deller());
			sts.menu = true;
			tmt.text = "Переход на уровень:\n";
			sts.lastlvl = sts.CurrentLvl;
			sts.CurrentLvl = "";
			sts.inputing = false;
		}

		memory.text += inputTxt;
		tmt.text += inputTxt;
		tmt.text += '_';
		tmt.GetComponent<SpotSpace>().lost = false;
		tmt.GetComponent<SpotSpace>().enabled = true;
	}
}
