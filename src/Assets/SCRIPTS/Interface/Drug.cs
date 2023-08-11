using UnityEngine;
using System.Collections;

public class Drug : MonoBehaviour
{
    private bool _mouseState;
    public Vector3 screenSpace;
    public Vector3 offset;

    private Vector3 lastPos;
    private Rigidbody Lvl;
    private bool c = false;

    private void OnMouseDown()
    {
        c = true;
    }

    private void OnMouseUp()
    {
        c = false;
    }

    private void Update()
    {
        if (c)
        {
            Lvl = GetComponent<FixedJoint>().connectedBody;
            if (Input.GetMouseButtonDown(0))
                if (gameObject != null)
                {
                    _mouseState = true;
                    screenSpace = Camera.main.WorldToScreenPoint(gameObject.transform.position);
                    offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
                }
            if (Input.GetMouseButtonUp(0)) _mouseState = false;
            if (_mouseState)
            {
                var curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
                var curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
                gameObject.transform.position = curPosition;
                gameObject.GetComponent<Rigidbody>().velocity = (curPosition - lastPos) * 30f;
                Lvl.GetComponent<Transform>().position = curPosition + new Vector3(0f, 0f, -0.215f);
                lastPos = curPosition;
            }
        }
    }
    GameObject GetClickedObject(out RaycastHit hit)
    {
        GameObject gameObject = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit)) gameObject = hit.collider.gameObject;
        return gameObject;
    }
}