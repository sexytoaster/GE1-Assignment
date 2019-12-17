using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class midrangeTriangleScript : MonoBehaviour
{
    public GameObject triangle;
    public GameObject mainCamera;
    public static Vector3 lastPosition = new Vector3(0, 0, 0);
    public Vector3 offsetVector = new Vector3(10, 0, 0);
    public static float x;
    public int band;
    public static bool direction = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("ChangeDirection");
        float distance = Vector3.Distance(mainCamera.transform.position, lastPosition);
        if (distance < -15 + (1500 * AudioPeer.audioBandBuffer[band]))
        {
            if(direction == true)
            { x += 5; }
            if (direction == false)
            { x -= 5; }
            GameObject triangleInstance = GameObject.Instantiate(triangle, lastPosition + offsetVector, Quaternion.identity);
            triangleInstance.transform.rotation = Quaternion.Euler(x, 0, 0);
            lastPosition = triangleInstance.transform.position;
            triangleInstance.transform.parent = gameObject.transform;
        }
       
        if (lastPosition.x < Camera.main.transform.position.x)
        {
            lastPosition.x = Camera.main.transform.position.x;
        }

    }

    IEnumerator ChangeDirection()
    {
        if(AudioPeer.audioBandBuffer[band]<= .1)
        {
            direction = !direction;
            Debug.Log(direction);
            yield return null;
        }
        else
        {
            Debug.Log(direction);
            yield return null;
        }
    }
}
