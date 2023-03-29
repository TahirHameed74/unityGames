using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MouseControl : MonoBehaviour
{
    float first_x = 0f;
    float second_x = 0f;
    float diff = 0f;
    private void Update()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        if (Input.GetMouseButtonDown(0))
        {
             first_x = Input.mousePosition.x;
        }

        if (Input.GetMouseButton(0))
        {
             second_x = Input.mousePosition.x;
        }
        if (Input.GetMouseButton(0))
        {
             diff = first_x - second_x;
             diff = diff / 40;
             diff = Mathf.Abs(diff);
             diff = Mathf.Clamp(diff, 0.03f, 0.137f);
           

            if (first_x > second_x && transform.position.z >= -1.8f)
            { 

                transform.Translate(0,0,-diff * 1  );

            }
            else if (first_x < second_x && transform.position.z <= 1.8f )
            {
                transform.Translate(0, 0,diff * 1 );

            }
        }

    }
  }


