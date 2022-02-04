using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction;
using Unity.XR.CoreUtils;

public class ContinuousMovement : MonoBehaviour
{
    public float speed;
    public XRNode inputSource;
    private XRRig rig;
    Vector2 inputAxis;
    private CharacterController character;

    // Start is called before the first frame update
    void Start()
    {
       // rig = GetComponent<XRRig>();
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
        
    }
    private void FixedUpdate()
    {
        //Quaternion headYaw = Quaternion.Euler(0, rig.CameraFloorOffsetObject.transform.eulerAngles.y,0);
        Vector3 direction = new Vector3(inputAxis.x, 0, inputAxis.y);

        character.Move(direction*Time.deltaTime* speed);
    }
}
