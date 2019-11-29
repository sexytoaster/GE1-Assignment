using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public GameObject mainCamera;
    public float speed = 50.0f;
    public int band;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = this.speed;
        transform.position += mainCamera.transform.forward * speed * Time.deltaTime * (AudioPeer.audioBand[band] + 1);
    }
}
