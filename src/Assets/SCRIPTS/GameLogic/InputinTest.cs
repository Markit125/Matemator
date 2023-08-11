using System.Collections;
using UnityEngine;

public class InputinTest : MonoBehaviour
{
    public GameObject Processor;
    public float timeafter;

    private void OnTriggerStay(Collider other)
    {
        Processor.GetComponent<Settings>().inputing = true;
    }
    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(WaitIn());
    }
    private IEnumerator WaitIn()
    {
        yield return new WaitForSeconds(timeafter);
        Processor.GetComponent<Settings>().inputing = false;
    }
}
