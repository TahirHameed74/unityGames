using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forward : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 b = transform.position;

        b.x += -2.750000f * Time.fixedDeltaTime;
        transform.position = b;



    }
}
