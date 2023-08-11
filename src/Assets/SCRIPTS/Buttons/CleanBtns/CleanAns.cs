using System.Collections;
using UnityEngine;

public class CleanAns : MonoBehaviour
{
    public GameObject Closer;
    public GameObject Processor;
    public GameObject[] ObjectAns;

    private void Update()
    {
        if((Input.GetKeyDown(KeyCode.C))) StartCoroutine(Delans());
    }

    private void OnMouseUp()
    {
        StartCoroutine(Delans());
    }

    private IEnumerator Delans()
    {
        if (!Processor.GetComponent<Settings>().outing)
        {
            ObjectAns = GameObject.FindGameObjectsWithTag("Finish");
            if (ObjectAns.Length > 0)
            {
                Closer.GetComponent<Animation>().Play("DoDownC");
                yield return new WaitForSeconds(0.5f);
                ObjectAns = GameObject.FindGameObjectsWithTag("Finish");
                for (int i = 0; i < ObjectAns.Length; i++) Destroy(ObjectAns[i]);
                Closer.GetComponent<Animation>().Play("DoUpC");
            }
        }
    }
}
