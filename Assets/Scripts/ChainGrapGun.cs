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
    GameObject spawnBullet;
    bool weShoot;

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
    }
    private void Update()
    {
        if (!weShoot)
        {
            bullet.gameObject.transform.position = barrel.position;
            bullet.gameObject.transform.rotation = barrel.rotation;

        }
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