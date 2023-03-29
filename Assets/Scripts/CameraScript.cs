using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject Ball;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        //difference between camera postion and the ball position
        offset = transform.position - Ball.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(Ball.transform.position.x,4f,0) + new Vector3(offset.x,0,0);
       
    }
}
