using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTriangle : MonoBehaviour
{
    public int band;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        distance = Vector3.Distance(Camera.main.transform.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (.1 >= AudioPeer.audioBandBuffer[band])
        {
            Destroy(gameObject);
            if (midrangeTriangleScript.direction == true)
            {
                midrangeTriangleScript.x -= 5;
            }
            if (midrangeTriangleScript.direction == false)
            {
                midrangeTriangleScript.x += 5;
            }
           
            if (Vector3.Distance(Camera.main.transform.position, transform.position) < Vector3.Distance(Camera.main.transform.position, midrangeTriangleScript.lastPosition))
            {
                midrangeTriangleScript.lastPosition = transform.position;
            }
            
        }

        if (Camera.main.transform.position.x > transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
