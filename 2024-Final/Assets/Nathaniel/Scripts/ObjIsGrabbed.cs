using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjIsGrabbed : MonoBehaviour
{
    public bool grabbed = false;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Grabbed(SelectEnterEventArgs args)
    {
        grabbed = true;
    }

    public void Released(SelectExitEventArgs args)
    {
        grabbed = false;
        rb.isKinematic = false;
        rb.useGravity = true;
    }
}
