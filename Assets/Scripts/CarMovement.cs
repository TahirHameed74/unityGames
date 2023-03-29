using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public static int Score;
    public GameObject Panel;

    [SerializeField]
    bool driftClock = true, driftCounterClock = false;
    Vector3 carPos;
    Quaternion faceRight = Quaternion.Euler(0, 0, 270);
    Quaternion faceLeft = Quaternion.Euler(0, 0, 90);
    Quaternion faceUp = Quaternion.Euler(0, 0, 0);
    Quaternion faceDown = Quaternion.Euler(0, 0, 180);
    [SerializeField]
    Quaternion startPos = Quaternion.Euler(0, 0, 0);
    Quaternion startRot = Quaternion.Euler(0, 0, 0);
    public List<GameObject> barrels;
    [SerializeField]
    GameObject current;
    void Start()
    {
        Application.targetFrameRate = 60;
    }


    void MoveForward()
    { // move to where the car is looking

        Quaternion _rotate = transform.rotation;
        Vector3 _pos = transform.position;
        if (_rotate == Quaternion.Euler(0, 0, -90))
            _rotate = faceRight;
        if (_rotate == Quaternion.Euler(0, 0, -180))
            _rotate = faceDown;


        if (_rotate == faceRight)
        {//go right

            _pos = transform.position;
            _pos.x += 5 * Time.deltaTime;
            transform.position = _pos;
        }
        if (_rotate == faceLeft)
        {//go left

            _pos = transform.position;
            _pos.x += -5 * Time.deltaTime;
            transform.position = _pos;
        }
        if (_rotate == faceDown)
        {//go down
            _pos = transform.position;
            _pos.y += -5 * Time.deltaTime;
            transform.position = _pos;
        }
        if (_rotate == faceUp)
        {//go up
            _pos = transform.position;
            _pos.y += 5 * Time.deltaTime;
            transform.position = _pos;
        }

    }
    void RotateCorrectPos()
    { //rotate the car after turn



        if (45 < transform.eulerAngles.z && transform.eulerAngles.z < 135)
        {

            transform.rotation = Quaternion.Euler(0, 0, 90);
            startPos = faceLeft;
        }
        if (225 < transform.eulerAngles.z && transform.eulerAngles.z < 315)
        {

            transform.rotation = Quaternion.Euler(0, 0, 270);
            startPos = faceRight;
        }

        if (135 < transform.eulerAngles.z && transform.eulerAngles.z < 225)
        {


            transform.rotation = Quaternion.Euler(0, 0, 180);
            startPos = faceDown;

        }
        if (315 < transform.eulerAngles.z && transform.eulerAngles.z < 360
                || 0 < transform.eulerAngles.z && transform.eulerAngles.z < 45)
        {

            transform.rotation = Quaternion.Euler(0, 0, 0);
            startPos = faceUp;

        }


        if (transform.eulerAngles.z - startRot.z > 135)
        {

        }
    }
    void FindClosest()
    {
        GameObject[] barrels = GameObject.FindGameObjectsWithTag("barrel");
        // GameObject current = barrels[0];
        //GameObject closest = null;
        current = barrels[0];
        float dist = Mathf.Infinity;
        Vector3 _currentPos = transform.position;

        foreach (GameObject barrel in barrels)
        {
            Vector3 diff = barrel.transform.position - _currentPos;
            float curDistance = diff.sqrMagnitude;

            if (curDistance < dist)
            {
                current = barrel;
                dist = curDistance;

            }
        }
    }
    void Drift()
    {
        float _speed;
        float _radius = 5;
        float _difX, _difY;
        _difX = transform.position.x - current.transform.position.x;
        _difY = transform.position.y - current.transform.position.y;
        _speed = 500 / (Mathf.Abs(_difX) + Mathf.Abs(_difY));

        Score++;


        if (_radius >= (_difX * _difX) + (_difY * _difY))
        {

            if (startPos == faceUp)
            {
                if (current.transform.position.x > carPos.x)
                    transform.RotateAround(current.transform.position, new Vector3(0, 0, -20f), _speed * Time.deltaTime);
                if (current.transform.position.x < carPos.x)
                    transform.RotateAround(current.transform.position, new Vector3(0, 0, 20f), _speed * Time.deltaTime);
            }
            if (startPos == faceDown)
            {
                if (current.transform.position.x > carPos.x)
                    transform.RotateAround(current.transform.position, new Vector3(0, 0, 20f), _speed * Time.deltaTime);
                if (current.transform.position.x < carPos.x)
                    transform.RotateAround(current.transform.position, new Vector3(0, 0, -20f), _speed * Time.deltaTime);
            }
            if (startPos == faceRight)
            {
                if (current.transform.position.y > carPos.y)
                    transform.RotateAround(current.transform.position, new Vector3(0, 0, 20f), _speed * Time.deltaTime);
                if (current.transform.position.y < carPos.y)
                    transform.RotateAround(current.transform.position, new Vector3(0, 0, -20f), _speed * Time.deltaTime);
            }
            if (startPos == faceLeft)
            {
                if (current.transform.position.y > carPos.y)
                    transform.RotateAround(current.transform.position, new Vector3(0, 0, -20f), _speed * Time.deltaTime);
                if (current.transform.position.y < carPos.y)
                    transform.RotateAround(current.transform.position, new Vector3(0, 0, 20f), _speed * Time.deltaTime);
           }
        }




    }
    void  OnTriggerEnter2D(Collider2D collision)
    {

        Time.timeScale = 0;
        Panel.gameObject.SetActive(true);


    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FindClosest();
            carPos = transform.position;
        }

        MoveForward();
        if (Input.GetMouseButton(0))
            Drift();
        if (Input.GetMouseButtonUp(0))
            RotateCorrectPos();
    }




}
