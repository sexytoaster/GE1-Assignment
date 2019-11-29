using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class makeBass : MonoBehaviour
{
    public GameObject ring;
    public GameObject mainCamera;
    public Vector3 lastPosition = new Vector3(0, 0, 0);
    public Vector3 offsetVector = new Vector3(10, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(mainCamera.transform.position, lastPosition);
        if (distance < 100)
        {
            GameObject ringInstance = GameObject.Instantiate(ring, lastPosition + offsetVector, Quaternion.identity);
            lastPosition = ringInstance.transform.position;
        }
    }
}
