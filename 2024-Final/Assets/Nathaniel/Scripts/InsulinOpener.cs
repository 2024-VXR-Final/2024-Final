using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using VInspector;

public class InsulinOpener : MonoBehaviour
{
    [Tab("InsulinKeyStatic")]
    public UnityEvent openCell;
    public UnityEvent closeCell;

    [Tab("InsulinHole")]
    [SerializeField] GameObject staticInsulinKey;

    [EndTab]


    // Start is called before the first frame update
    void Start()
    {
        staticInsulinKey.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("ShowInsulin") && other.gameObject.CompareTag("InsulinKey"))
        {
            staticInsulinKey.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (gameObject.CompareTag("ShowInsulin") && other.gameObject.CompareTag("InsulinKey"))
        {
            staticInsulinKey.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }
}
