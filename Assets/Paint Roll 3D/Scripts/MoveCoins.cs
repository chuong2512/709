using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCoins : MonoBehaviour
{
    private Transform movepos, firstpos;
    public float speed = 2f;
    bool change = false;
    private void Start()
    {
        movepos = GameObject.Find("CoinPos").transform;
        firstpos = GameObject.Find("firstpos").transform;

    }
    void Update()
    {
        if(!change)
        {

            transform.position = Vector3.MoveTowards(transform.position, firstpos.position, speed * Time.deltaTime);
            float distance = Vector3.Distance(transform.position, firstpos.position);
            if(distance<.1f)
            {
                change = true;
                speed = 5f;
            }
        }else
        {
            transform.position = Vector3.MoveTowards(transform.position, movepos.position, speed * Time.deltaTime);
            float distance = Vector3.Distance(transform.position, movepos.position);
            if (distance < .1f)
            {
                Destroy(gameObject);
            }
        }
        transform.Rotate(0, 8, 0);
    }
}
