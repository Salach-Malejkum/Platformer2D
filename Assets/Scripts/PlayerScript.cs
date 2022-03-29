using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playerTransform;
    public float smoothMovement;

    // Update is called once per frame
    void FixedUpdate()
    {
        FollowPlayer();
    }
    
    void FollowPlayer() 
    {
        Vector3 smoothPosition = Vector3.Lerp(transform.position, playerTransform.position + new Vector3(0f, 0f, -10f), smoothMovement * Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}