using System.Collections;
using UnityEngine;

public class DestroyerIn : MonoBehaviour
{
    public GameObject MatematorBody;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            Destroy(other.gameObject.GetComponent<FixedJoint>().connectedBody.gameObject);
            Destroy(other.gameObject);
        }
    }
}
