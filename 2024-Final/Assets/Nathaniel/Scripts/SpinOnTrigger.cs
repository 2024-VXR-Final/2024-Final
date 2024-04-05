using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SpinOnTrigger : MonoBehaviour
{
    Animator animator;
    Rigidbody rigidBody;
    SpinOnTrigger spinScript;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            animator = GetComponentInChildren<Animator>();
            rigidBody = GetComponentInChildren<Rigidbody>();
        }
        finally { }

    }

    private void OnTriggerEnter(Collider other)
    {
/*        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Ray"))
        {
            Debug.Log("hit");
            animator.Play("RaiseAndSpin");
            rigidBody.AddTorque(Vector3.up * 10);
        }*/
    }

    public void SpinEvent(HoverEnterEventArgs args)
    {
        spinScript = args.interactableObject.transform.gameObject.GetComponent<SpinOnTrigger>();
        spinScript.SpinThing();
    }

    public void SpinThing()
    {
        Debug.Log("hit");
        animator.Play("RaiseAndSpin");
        rigidBody.AddTorque(Vector3.up * 2, ForceMode.Impulse);
    }
}
