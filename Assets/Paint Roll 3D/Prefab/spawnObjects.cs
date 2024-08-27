using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BoingKit;



public class spawnObjects : MonoBehaviour
{
    public GameObject itemsToSpawn,cube;
    public List<Vector3> grids;
    public float gridSpacingOffset = 1f;
    public BoingReactorField boingEffect;
    public Color bushColor;
    Transform spawnPoint;
    int count = 0;
    bool switchPos = false;
    public enum spawnMethod {Double,Single };
    public spawnMethod SpawnObj;
    public bool spawnObj = false;
    public Transform bushParent;
    void Start()
    {
        if(spawnObj)
        {
            spawnPoint = this.transform;
            for (int i = 0; i < grids.Count; i++)
            {
                SpawnGrid();
            }
        }else
        {
            //GameManager.Instance.totalCount = bushParent.childCount;
        }
     
    }
    void SpawnGrid()
    {
        for (int x = 0; x < grids[count].x; x++)
        {
            for (int z = 0; z < grids[count].z; z++)
            {
                if(SpawnObj ==spawnMethod.Double)
                {
                    Vector3 spawnPos, spawnPos1;
                    spawnPos = new Vector3(x * gridSpacingOffset, 0, z * gridSpacingOffset) + spawnPoint.position;
                    spawnPos1 = new Vector3(x * -gridSpacingOffset, 0, z * gridSpacingOffset) + spawnPoint.position;
                    GameObject clone = Instantiate(itemsToSpawn, spawnPos, Quaternion.identity);
                    GameObject clone1 = Instantiate(itemsToSpawn, spawnPos1, Quaternion.identity);
                  //  clone.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().material.color = bushColor;
                    clone.transform.GetChild(0).GetComponent<BoingReactorFieldCPUSampler>().ReactorField = boingEffect;
                    clone.transform.SetParent(GameManager.Instance.bushParent);
                   // clone1.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().material.color = bushColor;
                    clone1.transform.GetChild(0).GetComponent<BoingReactorFieldCPUSampler>().ReactorField = boingEffect;
                    clone1.transform.SetParent(GameManager.Instance.bushParent);
                  //  GameManager.Instance.totalCount += 2;
                }else
                {
                    Vector3 spawnPos;
                    spawnPos = new Vector3(x * gridSpacingOffset, 0, z * gridSpacingOffset) + spawnPoint.position;
                    GameObject clone = Instantiate(itemsToSpawn, spawnPos, Quaternion.identity);                   
                   // clone.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().material.color = bushColor;
                    clone.transform.GetChild(0).GetComponent<BoingReactorFieldCPUSampler>().ReactorField = boingEffect;
                    clone.transform.SetParent(GameManager.Instance.bushParent);
                   // GameManager.Instance.totalCount += 1;
                }
               
               
            }
        }

        Vector3 newPos = new Vector3(transform.position.x, 0,transform.position.z+grids[count].z*gridSpacingOffset);
        spawnPoint.position = newPos;
        print(spawnPoint.position);
        count++;
       
    }

 
}
