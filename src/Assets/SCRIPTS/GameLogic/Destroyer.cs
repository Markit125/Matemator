using System.Collections;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public GameObject MatematorBody;

    private void OnTriggerEnter(Collider other)
    {
        MatematorBody.GetComponent<Animation>().Play("Barahlo");
        if (other.CompareTag("Respawn"))
        {
            Destroy(other.gameObject.GetComponent<FixedJoint>().connectedBody.gameObject);
            Destroy(other.gameObject);
        }
    }
}
