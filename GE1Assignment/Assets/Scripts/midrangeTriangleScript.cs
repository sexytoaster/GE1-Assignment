using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class midrangeTriangleScript : MonoBehaviour
{
    public GameObject triangle;
    public GameObject mainCamera;
    public Vector3 lastPosition = new Vector3(0, 0, 0);
    public Vector3 offsetVector = new Vector3(5, 0, 0);
    float x;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(mainCamera.transform.position, lastPosition);
        if (distance < 200)
        {
            x += 5;
            GameObject triangleInstance = GameObject.Instantiate(triangle, lastPosition + offsetVector, Quaternion.identity);
            lastPosition = triangleInstance.transform.position;
            triangleInstance.transform.rotation = Quaternion.Euler(x, 0, 0);
        }

    }
}
