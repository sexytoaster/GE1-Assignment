using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbitOrbs : MonoBehaviour
{
    public float yOrbit;
    public float zOrbit;
    public float xOffset;
    public Transform cameraPosition;
    public int band;
    public float rotationSpeed;
    public bool rotateClockwise;
    public float scaleMulti;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * rotationSpeed;
        Rotate();

    }

    void Rotate()
    {
        if(rotateClockwise)
        {
            float y = (-Mathf.Cos(timer) * yOrbit) + (AudioPeer.audioBandBuffer[band] * scaleMulti);
            float z = Mathf.Sin(timer) * zOrbit; // + (AudioPeer.audioBandBuffer[band] * scaleMulti);
            Vector3 pos = new Vector3(xOffset, y, z);
            transform.position = pos + cameraPosition.position;
        }
        else
        {
            float y = Mathf.Cos(timer) * yOrbit + (AudioPeer.audioBandBuffer[band] * scaleMulti);
            float z = Mathf.Sin(timer) * zOrbit; // + (AudioPeer.audioBandBuffer[band] * scaleMulti);
            Vector3 pos = new Vector3(xOffset, y, z);
            transform.position = pos + cameraPosition.position;
        }
    }
}
