using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using BoingKit;
using UnityEngine.SceneManagement;
using System;

public class RotateScript : MonoBehaviour
{
    public Transform Top, Bottom, Child;
    bool SwitchParent = false;
    private Transform rotateObj;
    public float rotSpeed = 3f;
    public bool start = false;
    Transform ray;
    public LayerMask layer;
    private BoingEffector TopEffector, BottomEffector;
    public GameObject[] bubbleEffect;
    public MeshRenderer[] playerColors;
    public ParticleSystem popeffects;
   
    void Start()
    {
        rotateObj = Top;
        ray = Child.GetChild(0);
        BottomEffector = Child.GetChild(0).GetComponent<BoingEffector>();
        TopEffector = Child.GetChild(1).GetComponent<BoingEffector>();
        foreach (MeshRenderer colors in playerColors)
        {
            colors.material = GameManager.Instance.playerMat[GameManager.Instance.selectedNo];
        }

        
    }
    //1.1
    //0.8
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !EventSystem.current.currentSelectedGameObject)
        {
            start = true;
            RaycastHit hit;
            if (Physics.Raycast(ray.position, Vector3.down, out hit, 10f, layer))
            {
                transform.SetParent(hit.transform.parent.parent);
            }
            else if(!GameManager.Instance.gameOver)
            {
                rotSpeed = 0;
                Collider[] colls = Physics.OverlapSphere(transform.position, 5f);
                foreach (Collider obj in colls)
                {
                    if(obj.GetComponent<Rigidbody>())
                    {
                        Rigidbody rb = obj.GetComponent<Rigidbody>();
                        rb.isKinematic = false;
                        rb.useGravity = true;
                    }
                }
                foreach (GameObject buble in bubbleEffect)
                {
                    buble.SetActive(true);
                }
                CanvasManager.Instance.LevelFailPanel.SetActive(true);
                if(Audiomanager.Instance)
                Audiomanager.Instance.AudioClip.volume = 0;
                // Invoke("retryMethod", 2f);
            }
            if (!SwitchParent)
            {
                SwitchParent = true;
                Top.DetachChildren();
                Child.SetParent(Bottom);
                Top.SetParent(Bottom);
                this.transform.position = Child.GetChild(1).position;
                Bottom.SetParent(this.transform);
                ray = Child.GetChild(1);
                rotateObj = Bottom;
                rotSpeed = -rotSpeed;
            }else
            {
                SwitchParent = false;
                Bottom.DetachChildren();
                Child.SetParent(Top);
                Bottom.SetParent(Top);
                this.transform.position = Child.GetChild(1).position;
                Top.SetParent(this.transform);
                ray = Child.GetChild(0);
                rotateObj = Top;
                rotSpeed = -rotSpeed;
            }
           
         
        }
        Debug.DrawRay(ray.position, Vector3.down, Color.red);
        rotateObj.transform.Rotate(0f, 90.0f * rotSpeed * Time.deltaTime, 0.0f, Space.Self);
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag!="Player"&&start)
        {
            GameManager.Instance.ColorMethod(other);
            other.gameObject.tag = "Player";
            GameManager.Instance.collected++;
            //other.transform.SetParent(GameManager.Instance.collectedParent);
            print(other.gameObject);
           // Destroy(other);
            if(other.transform.GetChild(0))
            other.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = GameManager.Instance.lastColor[GameManager.Instance.selectedNo];
            Vibration.Vibrate(20);
        }

    }
}
