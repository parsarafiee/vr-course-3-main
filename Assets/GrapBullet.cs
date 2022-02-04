using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapBullet : MonoBehaviour
{    public Rigidbody rb;
    public FixedJoint joint;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag =="House")
        {
            joint = gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = collision.gameObject.GetComponent<Rigidbody>();
            Debug.Log("collide with : "+collision.gameObject.name);
            Debug.Log(collision.contacts[0].point);
        }
    }
    public void DestroyJoint()
    {
        Destroy(joint);
    }

}
