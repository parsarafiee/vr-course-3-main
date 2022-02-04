using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Climber : MonoBehaviour
{
    private CharacterController characterController;
    public static XRController ClimbingHand;
    void Start()
    {
        characterController=GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ClimbingHand)
        {
            Climb();
        }
    }

    private void Climb()
    {
        InputDevices.GetDeviceAtXRNode(ClimbingHand.controllerNode).TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity);

        characterController.Move(transform.rotation*-velocity*Time.deltaTime);
    }
}
