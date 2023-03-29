using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallCode : MonoBehaviour
{


    public static int Score;
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Diamond")
        {
            collision.gameObject.SetActive(false);
            Score = Score + 1;
        }

    }

    [SerializeField]
    bool isUp = false, isDown = true;
 
    // Update is called once per frame
    void Update()
    {
        Vector3 a = transform.position;

        if (a.y <= (0.67f))
        {
            isDown = true;
            isUp = false;
        }


        if (a.y >= (2.259f))
        {
            isUp = true;
            isDown = false;
        }
      
        if (isUp)
        {
            a.y += -3f * Time.fixedDeltaTime;
        }
        if (isDown)
        {
            a.y += 3f * Time.fixedDeltaTime;
        }
        transform.position = a;

    }
 
}
