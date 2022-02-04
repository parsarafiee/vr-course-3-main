using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    public GameObject boxPrefab;
    public Transform player;
    public int speed;
    public float timeToRespawn;
    float timer;

    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer > timeToRespawn)
        {
            GameObject b = Instantiate(boxPrefab, transform.position + new Vector3(1, 0, 0), Quaternion.identity, transform);
            GameObject a = Instantiate(boxPrefab, transform.position + new Vector3(-1, 0, 0), Quaternion.identity, transform);

            b.GetComponent<Rigidbody>().velocity = (player.transform.position - b.transform.position).normalized * speed * Time.deltaTime;
            a.GetComponent<Rigidbody>().velocity = (player.transform.position - a.transform.position).normalized * speed * Time.deltaTime;

            timer = 0;
        }

    }
}
