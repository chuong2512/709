using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayPP : MonoBehaviour
{
    public bool once,COLLECTED;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Collider>().enabled = false;
        //PlayerPrefs.SetInt("ONCE", PlayerPrefs.GetInt("ONCE", 0) + 1);
        //if (PlayerPrefs.GetInt("ONCE", 0) > 2)
        //{
        //    this.gameObject.SetActive(true);
        //}
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!once)
        {
            if (other.gameObject.tag == "Player")
            {
                if (!COLLECTED)
                {
                    //Time.timeScale = 0;
                    this.gameObject.SetActive(false);
                    
                    COLLECTED = true;
                }
                once = true;
            }
        }

    }
}
