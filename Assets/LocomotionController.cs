using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionController : MonoBehaviour
{
    public XRController teleportationController;
   // public XRController RightTeleportRay;
    public InputHelpers.Button teleportActivationButton;
    public float activationThreshold = 0.1f;
    public  GameObject leftRay;

    public bool EnableTeleport { get; set; } = true;
    void Update()
    {
        if (teleportationController)
        {
            teleportationController.gameObject.SetActive(EnableTeleport && ChechIfActivated(teleportationController));
        }



        
    }

    public bool ChechIfActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice,teleportActivationButton,out bool isActivated,activationThreshold);
        return isActivated;
    }
}
