﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MakeHole : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            Destroy(other.transform.parent.gameObject);
           // GameManager.Instance.totalCount-=1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Destroy(collision.transform.parent.gameObject);
         //   GameManager.Instance.totalCount -= 1;
        }
    }
}
