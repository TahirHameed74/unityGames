using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RingCollisionWithBall : MonoBehaviour
{
    public GameObject Ball;
    public GameObject Panel;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            collision.gameObject.SetActive(false);
        }

        Panel.gameObject.SetActive(true);
       

    }

   

// Update is called once per frame
void Update()
    {
        Vector3 a = transform.position;
        if (Ball.transform.position.x < a.x -3f )
        {
            transform.position = new Vector3(a.x - 48f, transform.position.y, Random.Range(-1.8f, 1.8f));

            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
       
    }


}



