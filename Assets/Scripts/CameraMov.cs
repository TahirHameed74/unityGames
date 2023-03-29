using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMov : MonoBehaviour
{
    public GameObject car_yellow_3;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        //difference between camera postion and the ball position
        offset = transform.position - car_yellow_3.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = car_yellow_3.transform.position + offset;
    }
}

