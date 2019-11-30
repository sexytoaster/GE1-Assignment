using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCircle : MonoBehaviour
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
        if (Camera.main.transform.position.x > transform.position.x)
        {
            Destroy(gameObject);
        }
        if (distance >= 500 + (2000 * AudioPeer.audioBandBuffer[band]))
        {
            
            Vector3 lastPosRing = GetComponentInParent<makeBass>().lastPosition;
            if (Vector3.Distance(Camera.main.transform.position, transform.position) < Vector3.Distance(Camera.main.transform.position, lastPosRing))
            {
                GetComponentInParent<makeBass>().lastPosition = transform.position;
            }
            Destroy(gameObject);
        }
    }
}