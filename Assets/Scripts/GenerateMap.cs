using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    float x = 0;
    float y = 0;
    float z = 0;

   
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject Prefab1 , Prefab2, Prefab3;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        Vector3 a = Prefab1.gameObject.transform.position;
        x += a.y;

        Vector3 b = Prefab2.gameObject.transform.position;
        y += b.y;
      
        Vector3 c = Prefab3.gameObject.transform.position;
        z += c.y;
    }
    int rand = 0;

    float Time_c;
    float Time_s = 0.3f;
    // Update is called once per frame
    void Update()
    {
        rand=Random.Range(0, 3);
        Time_c += Time.deltaTime;
        if (Time_c > Time_s)
        {
            if (rand == 0)
            {

                Vector3 a = Prefab1.gameObject.transform.position;
                x += 51f;
                Instantiate(Prefab1, new Vector3(0.23f, x, 0), Quaternion.identity);
            }
            else if (rand == 1)
            {

                Vector3 b = Prefab2.gameObject.transform.position;
                y += 51f;
                Instantiate(Prefab2, new Vector3(0.23f, y, 0), Quaternion.identity);
            }
            else if (rand == 2)
            {
                Vector3 c = Prefab3.gameObject.transform.position;
                z += 51f;
                Instantiate(Prefab3, new Vector3(0.23f, z, 0), Quaternion.identity);
            }

            Time_c = 0.0f;
        }
    }
}


