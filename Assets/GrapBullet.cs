using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapBullet : MonoBehaviour
{    public Rigidbody bulletRigidBody;
     FixedJoint joint;
 //   public GameObject chain;
    public Transform barrel;
    public float gap;
    public ChainGrapGun chainGrapGun;
    public bool hit;
    public GameObject gun;

    public Vector3 collitionPositon;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag =="House")
        {
            joint = gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = collision.gameObject.GetComponent<Rigidbody>();
             collitionPositon= collision.contacts[0].point;
            joint.connectedAnchor = collitionPositon;

            float distance = Vector3.Distance(barrel.position, collitionPositon);
            int numberOfChain =(int)( distance);

            List<GameObject> gameObjects= new List<GameObject>();
            hit = true;

            chainGrapGun.lr.positionCount = 2;
            chainGrapGun.Swing(collitionPositon, collision.gameObject.GetComponent<Rigidbody>());
        }
    }
    public void DestroyJoint()
    {
        hit = false;
        Destroy(joint);
    }

}
//{    public Rigidbody rb;
//SpringJoint joint;


//private void OnCollisionEnter(Collision collision)
//{
//    if (collision.gameObject.tag == "House")
//    {
//        joint = gameObject.AddComponent<SpringJoint>();
//        joint.connectedBody = collision.gameObject.GetComponent<Rigidbody>();
//        joint.connectedAnchor = collision.contacts[0].point;
//        joint.minDistance = 0.5f;

//        Debug.Log("collide with : " + collision.gameObject.name);
//        Debug.Log(collision.contacts[0].point);
//    }
            //for (int i = 0; i < numberOfChain; i++)
            //{
            //    //GameObject ch = Instantiate(chain,(collitionPositon - barrel.position).normalized * i+barrel.position,Quaternion.identity);
            //    //gameObjects.Add(ch);
            //    //if (i==0)
            //    //{
            //    //    SpringJoint joint;
            //    //    joint= ch.gameObject.AddComponent<SpringJoint>();
            //    //    joint.connectedBody = gun.gameObject.GetComponent<Rigidbody>();
            //    //    joint.spring = 1000;
            //    //    joint.damper = 10;
            //    //    joint.tolerance = 0.001f;

            //    //}

            //    //else
            //    //{
            //    //    SpringJoint joint;
            //    //    joint = ch.gameObject.AddComponent<SpringJoint>();
            //    //    joint.connectedBody = gameObjects[i-1].gameObject.GetComponent<Rigidbody>();
            //    //    joint.spring = 1000;
            //    //    joint.damper = 10;
            //    //    joint.tolerance = 0.001f;
            //    //}

            //}