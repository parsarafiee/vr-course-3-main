using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class CapuleFollowHeadSet : MonoBehaviour
{
    private XROrigin xr;
    public GameObject camera;
    private CharacterController character;
    public float addtionalHeight = 0.2f;
    void Start()
    {
        character = GetComponent<CharacterController>();

    }

    void FollowPlayer()
    {
        character.height = camera.transform.position.y + addtionalHeight;
        Vector3 capsuleCenter = transform.InverseTransformPoint(camera.transform.position);

        character.center = new Vector3(capsuleCenter.x,character.height/2+character.skinWidth,capsuleCenter.z);   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FollowPlayer();
    }
}
