using System.Collections;
using UnityEngine;

public class Buffer : MonoBehaviour
{
    public int power;
    private float direct;

    private void OnTriggerEnter(Collider other)
    {
        direct = power / 1000;
    }

    private void OnTriggerStay(Collider other)
    {
        other.GetComponent<Rigidbody>().velocity += new Vector3(direct, 0f);
    }
}