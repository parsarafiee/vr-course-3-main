using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainGrapGun : MonoBehaviour
{
    public float speed = 40;
    public GrapBullet bullet;
    public Rigidbody BulletRB;
    public Transform barrel;
    public AudioClip audioClip;
    public AudioSource audioSource;
    public LineRenderer lr;

    bool weShoot;

    public GameObject player;
    private SpringJoint jointToPlayer;


    private void LateUpdate()
    {
        if (!weShoot)
        {
            bullet.gameObject.transform.position = barrel.position;
            bullet.gameObject.transform.rotation = barrel.rotation;

        }
        DrawRope(bullet.collitionPositon);
    }

    //  public XRController controller;

    // Update is called once per frame
    public void FireBullet()
    {
        //  controller.gameObject.GetComponent<XRDirectInteractor>().playHapticsOnSelectEnter = true;
        weShoot=true;
        BulletRB.velocity = speed * barrel.forward;
        audioSource.PlayOneShot(audioClip);
       
    }
    public void CancelGrappling()
    {
           weShoot = false;
        bullet.DestroyJoint();
        StopSWing();
    }
    private void Update()
    {

        MakeRayCastToHit();
    }

    public void Swing(Vector3 PointToSwing,Rigidbody rbConnected)
    {
        jointToPlayer = player.gameObject.AddComponent<SpringJoint>();
        jointToPlayer.autoConfigureConnectedAnchor = false;
        jointToPlayer.connectedBody = rbConnected;
        jointToPlayer.connectedAnchor = rbConnected.gameObject.transform.position - PointToSwing;
        jointToPlayer.anchor = new Vector3(0,0,0);
       // jointToPlayer.connectedAnchor = PointToSwing;
        float distanceFromPoint = Vector3.Distance(player.transform.position, PointToSwing);

        jointToPlayer.maxDistance = distanceFromPoint * 0.8f;
        jointToPlayer.minDistance = distanceFromPoint * 0.25f;


        jointToPlayer.spring = 4.5f;
        jointToPlayer.damper = 7f;
        jointToPlayer.massScale = 4.5f;

    }

    public void StopSWing()
    {
        lr.positionCount = 0;

        Destroy(jointToPlayer);

    }
    void DrawRope(Vector3 hitPoint)
    {
        if (!bullet.hit) return;

        lr.SetPosition(0, barrel.position);
        lr.SetPosition(1, hitPoint);

    }

    void MakeRayCastToHit()
    {
        RaycastHit hit;
        Ray ray = new Ray(barrel.position,(bullet.gameObject.transform.position -player.transform.position).normalized);
        if (Physics.Raycast(ray, out hit, Vector3.Distance(barrel.position, bullet.gameObject.transform.position) - 1))
            CancelGrappling();

    }
}





//public float speed = 40;
//public GameObject bullet;
//public Transform barrel;
//public AudioClip audioClip;
//public AudioSource audioSource;
//GameObject spawnBullet;
//bool weShoot;
////  public XRController controller;

//// Update is called once per frame
//public void FireBullet()
//{
//    //  controller.gameObject.GetComponent<XRDirectInteractor>().playHapticsOnSelectEnter = true;
//    spawnBullet = Instantiate(bullet, barrel.position, barrel.rotation);
//    spawnBullet.GetComponent<Rigidbody>().velocity = speed * barrel.forward;
//    audioSource.PlayOneShot(audioClip);

//}
//public void CancelGrappling()
//{
//    GameObject.Destroy(spawnBullet);
//}