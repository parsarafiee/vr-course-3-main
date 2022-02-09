using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class GrapplingGun : MonoBehaviour
{
    public LineRenderer lr;
    public LayerMask whatIsGrappleable;
    public Transform gunTip;
    public Transform Player;
    public float maxDistance = 100;
    private SpringJoint joint;
    private Vector3 grapplePoint;
   // public Player playerScript;



    
    private void LateUpdate()
    {
        DrawRope();
    }

    public void Swing()
    {
        
        //  playerScript.enabled = false;
        RaycastHit hit;
        if (Physics.Raycast(gunTip.position, gunTip.forward, out hit, maxDistance, whatIsGrappleable))
        {
            grapplePoint = hit.point;
            joint = Player.gameObject.AddComponent<SpringJoint>();

            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;
            float distanceFromPoint = Vector3.Distance(Player.position, grapplePoint);

            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;


            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lr.positionCount = 2;
        }
    }

    public void StopSWing()
    {
        //  playerScript.enabled = true;
        lr.positionCount = 0;
        Destroy(joint);
    }
    void DrawRope()
    {
        if (!joint) return;

           lr.SetPosition(0, gunTip.position);
            lr.SetPosition(1, grapplePoint);
     
    }

}
