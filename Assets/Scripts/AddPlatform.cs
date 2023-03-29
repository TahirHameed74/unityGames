using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlatform : MonoBehaviour
{

    public GameObject Ball;
    public GameObject Ring;
    float x = -42f;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 a = transform.position;
        if (Ball.transform.position.x < a.x - 3f)
        {
            transform.position = new Vector3(a.x + x,0, 0);


       
        }

    }
}
