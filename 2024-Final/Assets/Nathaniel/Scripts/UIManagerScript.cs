using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


/// <summary>
/// This script needs to be put on the trigger objects that you want to spin,
/// and it has to be put on an empty so you only need to reference it once
/// 
/// The objects that you're spinning need to be children of the trigger as shown in the RigTesting scene
/// </summary>
public class UIManagerScript : MonoBehaviour
{
    SpinObject spinScript;
    ToolTip toolTipScript;

    //Reference this in the onhover event on each controller
    public void HoverEvent(HoverEnterEventArgs args)
    {
        if (args.interactableObject.transform.gameObject.TryGetComponent<SpinObject>(out spinScript))
        {
            spinScript.SpinThing();
        } else if (args.interactableObject.transform.gameObject.TryGetComponent<ToolTip>(out toolTipScript))
        {
            toolTipScript.ShowTip();    
        }
        else
        {
            Debug.Log("Thing not found");
        }

    }

    public void OnHoverExit(HoverExitEventArgs args)
    {
        if (args.interactableObject.transform.gameObject.TryGetComponent<ToolTip>(out toolTipScript))
        {
            toolTipScript.HideTip();
        }
    }

}
