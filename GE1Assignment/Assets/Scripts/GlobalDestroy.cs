using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalDestroy : MonoBehaviour
{
    public int band;
    float distance;
    GameObject[] triangles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        triangles = GameObject.FindGameObjectsWithTag("triangle");
        Vector3 last = midrangeTriangleScript.lastPosition;
        int count = 0;
        for(int i = 0; i < triangles.Length; i++)
        {
            if (Vector3.Distance(Camera.main.transform.position, triangles[i].transform.position) >= 5 + (1500 * AudioPeer.audioBandBuffer[band]))
            {
                Destroy(triangles[i].gameObject);
                count += 5;
               

                if (Vector3.Distance(Camera.main.transform.position, triangles[i].transform.position) < Vector3.Distance(Camera.main.transform.position, last))
                {
                    last = triangles[i].transform.position;
                }

            }
        }
        midrangeTriangleScript.lastPosition = last;
        midrangeTriangleScript.x -= count;
    }
}
