using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRHaptics : MonoBehaviour
{
    XRController _controller;
    [SerializeField] float hapticAmplitude = 0.2f;
    [SerializeField] float hapticDuration = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<XRController>();
    }

    public void RunHaptics()
    {
        if (_controller != null) 
        {
            _controller.SendHapticImpulse(hapticAmplitude, hapticDuration);
        }
    }

}
