using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeBands45 : MonoBehaviour
{
    public GameObject band4;
    public GameObject band5;
    public float xOffset;
    public float zOffset;
    public int band;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 posBand4 = new Vector3(xOffset, 0, zOffset);
        Vector3 posBand5 = new Vector3(xOffset + 20, 0, zOffset + 10);
        for (int i = 0; i < 2; i++)
        {
            
            GameObject band4Instance = GameObject.Instantiate(band4, posBand4, Quaternion.identity);
            GameObject band5Instance = GameObject.Instantiate(band5, posBand5, Quaternion.identity);
            band4Instance.transform.parent = Camera.main.transform;
            band5Instance.transform.parent = Camera.main.transform;
            if (i == 1)
            {
                band4Instance.GetComponentInChildren<floatingBalls>().zOffset = posBand5.z * -1;
                band5Instance.GetComponentInChildren<floatingBalls>().zOffset = posBand4.z * -1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    
}
