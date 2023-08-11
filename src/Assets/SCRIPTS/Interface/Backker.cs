using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Rigidbody>().velocity = -other.GetComponent<Rigidbody>().velocity;
    }
}
