
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction;
using Unity.XR.CoreUtils;

public class Gun : MonoBehaviour
{
    public float speed = 40;
    public GameObject bullet;
    public Transform barrel;
    public AudioClip audioClip;
    public AudioSource audioSource;
    GameObject spawnBullet;
    bool weShoot;
    //  public XRController controller;



    // Update is called once per frame
    public void Fire()
    {
      //  controller.gameObject.GetComponent<XRDirectInteractor>().playHapticsOnSelectEnter = true;
        spawnBullet = Instantiate(bullet,barrel.position,barrel.rotation);
        spawnBullet.GetComponent<Rigidbody>().velocity = speed * barrel.forward;
        audioSource.PlayOneShot(audioClip); 
        Destroy(spawnBullet,2);
    }


}
