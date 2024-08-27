using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EditorTry : MonoBehaviour
{
    public GameObject itemsToSpawn, cube;
    public List<Vector3> grids;
    public float gridSpacingOffset = 1f;
    public Color bushColor;
    Transform spawnPoint;
    int count = 0;
    bool switchPos = false;
    public enum spawnMethod { Double, Single };
    public spawnMethod SpawnObj;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Test!");
        spawnPoint = this.transform;
        for (int i = 0; i < grids.Count; i++)
        {
            SpawnGrid();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnGrid()
    {
        for (int x = 0; x < grids[count].x; x++)
        {
            for (int z = 0; z < grids[count].z; z++)
            {
                if (SpawnObj == spawnMethod.Double)
                {
                    Vector3 spawnPos, spawnPos1;
                    spawnPos = new Vector3(x * gridSpacingOffset, 0, z * gridSpacingOffset) + spawnPoint.position;
                    spawnPos1 = new Vector3(x * -gridSpacingOffset, 0, z * gridSpacingOffset) + spawnPoint.position;
                    GameObject clone = Instantiate(itemsToSpawn, spawnPos, Quaternion.identity);
                    GameObject clone1 = Instantiate(itemsToSpawn, spawnPos1, Quaternion.identity);
                }
                else
                {
                    Vector3 spawnPos;
                    spawnPos = new Vector3(x * gridSpacingOffset, 0, z * gridSpacingOffset) + spawnPoint.position;
                    GameObject clone = Instantiate(itemsToSpawn, spawnPos, Quaternion.identity);
                }


            }
        }

        Vector3 newPos = new Vector3(transform.position.x, 0, transform.position.z + grids[count].z * gridSpacingOffset);
        spawnPoint.position = newPos;
        print(spawnPoint.position);
        count++;

    }

}
