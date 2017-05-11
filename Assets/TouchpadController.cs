using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class TouchpadController : MonoBehaviour
{

    public GameObject teleportManager;
    public TeleportController teleportScript;

    private void Start()
    {
        teleportScript = teleportManager.GetComponent<TeleportController>();
        //GetComponent<VRTK_ControllerEvents>().TriggerAxisChanged += new ControllerInteractionEventHandler(DoTriggerAxisChanged);
        GetComponent<VRTK_ControllerEvents>().TouchpadAxisChanged += new ControllerInteractionEventHandler(DoTouchpadAxisChanged);

       // GetComponent<VRTK_ControllerEvents>().TriggerReleased += new ControllerInteractionEventHandler(DoTriggerReleased);
        GetComponent<VRTK_ControllerEvents>().TouchpadTouchEnd += new ControllerInteractionEventHandler(DoTouchpadTouchEnd);

       // GetComponent<VRTK_ControllerEvents>().ButtonOnePressed += new ControllerInteractionEventHandler(DoCarReset);
    }

    private void DoTouchpadAxisChanged(object sender, ControllerInteractionEventArgs e)
    {
        teleportScript.SetTouchAxis(e.touchpadAxis);
    }

    //private void DoTriggerAxisChanged(object sender, ControllerInteractionEventArgs e)
    //{
    //    teleportScript.SetTriggerAxis(e.buttonPressure);
    //}

    private void DoTouchpadTouchEnd(object sender, ControllerInteractionEventArgs e)
    {
        teleportScript.SetTouchAxis(Vector2.zero);
    }

    //private void DoTriggerReleased(object sender, ControllerInteractionEventArgs e)
    //{
    //    teleportScript.SetTriggerAxis(0f);
    //}

    //private void DoCarReset(object sender, ControllerInteractionEventArgs e)
    //{
    //    teleportScript.ResetCar();
    //}
}
