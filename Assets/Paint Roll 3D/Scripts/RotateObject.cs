using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WrappingRopeLibrary.Scripts;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class RotateObject : MonoBehaviour
{
    public Transform ropeParent;
    public List<Vector3> cubepose = new List<Vector3>();
    public GameObject spawner;
    public List<Transform> CubeTransform = new List<Transform>();
    int totalno;
    bool levelcompleted;
    int levelno;
    GameObject levelwinpanel;
    private float horizontalSpeed = 40F;
    private float verticalSpeed = 40F;
    public float timer,threshold =.1f;
    bool dragging;
    Rope ropescript ;
    public GameObject Coineffect, StarEffect;
    private void Start()
    {
        levelwinpanel = GameObject.Find("LevelWinPanel");
        levelno = SceneManager.GetActiveScene().buildIndex;
        ropeParent = GameObject.Find("Rope").GetComponent<Transform>();
        foreach (Transform connectpoint in ropeParent)
        {
         cubepose.Add(connectpoint.GetComponent<Piece>().BackBandPoint.PositionInWorldSpace);
        }
        for (int i = 0; i < cubepose.Count; i++)
        {
            GameObject go = Instantiate(spawner, cubepose[i], Quaternion.identity);
            go.transform.SetParent(transform);
            CubeTransform.Add(go.transform);
            go.name = "Cubes" + i;
       }
        totalno = cubepose.Count;
        levelwinpanel.SetActive(false);
        ropescript = ropeParent.GetComponent<Rope>();
    }
    void Update()
    {
        for (int i = 0; i < totalno; i++)
        {
          
            if (i < ropeParent.childCount)
            {
                CubeTransform[i].gameObject.SetActive(true);
            }
            else
            {
                GameObject Coins = Instantiate(Coineffect, CubeTransform[0].transform.position, Coineffect.transform.rotation);
                GameObject Stars = Instantiate(StarEffect, CubeTransform[0].transform.position, StarEffect.transform.rotation);
                  Destroy(CubeTransform[0].gameObject);
                 totalno--;
                CubeTransform.Remove(CubeTransform[0]);
              //  CubeTransform[i].gameObject.SetActive(false);
                print(CubeTransform[0].gameObject.name);

            }
        }

        if (ropeParent.childCount==1&&!levelcompleted)
        {
            levelcompleted = true;  
            print("Level Completed");
            levelwinpanel.SetActive(true);
        
        }
       
        float h = horizontalSpeed * Time.deltaTime * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Time.deltaTime * Input.GetAxis("Mouse Y");
        Vector3 pos = new Vector3(v, -h, 0);
       
        if (Input.GetMouseButton(0)&&!EventSystem.current.currentSelectedGameObject)
        {
            timer += Time.deltaTime;
            if(timer>threshold)
            {
                dragging = true;
                transform.Rotate(pos, Space.World);
            }else
            {
        
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            timer = 0;
             dragging = false;

        }




    }
    public void retrylevel()
    {
       
        SceneManager.LoadScene(levelno);

    }
}
