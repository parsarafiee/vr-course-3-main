using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScripts : MonoBehaviour
{
    private GameObject spark;

    private void Start()
    {
        spark = Resources.Load<GameObject>("Prefabs/SparksRed");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag =="Box")
        {
           GameObject a =  Instantiate(spark,transform.position,Quaternion.identity);
            GameObject.Destroy(gameObject);
        }
    }
}
