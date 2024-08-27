using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasteffect : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform movepos;
    public float speed = 3f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveMethod();
    }

    void moveMethod()
    {
        transform.position = Vector3.MoveTowards(transform.position, movepos.position, speed * Time.deltaTime);
    }
}
