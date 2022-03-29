using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public int speed = 2;
    public bool direction = true;
    public int limitRight = 15;
    public int limitLeft = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (direction)
        {
            if (transform.position.x < limitRight)
                transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0f, 0f);
            else 
                direction = !direction;
        }
        else
        {
            if (transform.position.x > limitLeft)
                transform.position = transform.position + new Vector3(-speed * Time.deltaTime, 0f, 0f);
            else 
                direction = !direction;
        }
    }
}
