using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class moveObject : MonoBehaviour
{
    public enum axis {X,Z };
    public axis moveAxis;
    public GameObject startPos, EndPos;
    bool switchPos = false;
    public float moveSpeed = 5f;
    public float DistanceToMove = 5f;
    void Start()
    {
        MoveMethod();

    }

    // Update is called once per frame
    void Update()
    {
        if(!switchPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos.transform.position, moveSpeed * Time.deltaTime);
            float distance = Vector3.Distance(transform.position, startPos.transform.position);
            if(distance<.01f)
            {
                switchPos = true;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, EndPos.transform.position, moveSpeed * Time.deltaTime);
            float distance = Vector3.Distance(transform.position, EndPos.transform.position);
            if (distance < .01f)
            {
                switchPos = false;
            }

        }
    }
    void MoveMethod()
    {
        startPos = new GameObject("StartPos");
        EndPos = new GameObject("EndPos");
        switch (moveAxis)
        {
            case axis.X:
                Vector3 newPos = new Vector3(transform.position.x + DistanceToMove, transform.position.y, transform.position.z);
                Vector3 newEndPos = new Vector3(transform.position.x - DistanceToMove, transform.position.y, transform.position.z);
                startPos.transform.position = newPos;
                EndPos.transform.position = newEndPos;
                break;
            case axis.Z:
                Vector3 newPos1 = new Vector3(transform.position.x, transform.position.y, transform.position.z + DistanceToMove);
                Vector3 newEndPos1 = new Vector3(transform.position.x, transform.position.y, transform.position.z - DistanceToMove);
                startPos.transform.position = newPos1;
                EndPos.transform.position = newEndPos1;
                break;
            default:
                break;
        }
    }
}
