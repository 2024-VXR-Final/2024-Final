using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjIsGrabbed : MonoBehaviour
{
    public bool grabbed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Grabbed(SelectEnterEventArgs args)
    {
        grabbed = true;
    }

    public void Released(SelectExitEventArgs args)
    {
        grabbed = false;
    }
}
