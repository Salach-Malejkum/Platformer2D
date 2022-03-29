using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject myPlayer = GameObject.FindGameObjectWithTag("Player");
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        if (myPlayer.transform.localScale.x > 0)
            rigidBody.velocity = new Vector2(bulletSpeed, 0f);
        else 
        rigidBody.velocity = new Vector2(-bulletSpeed, 0f);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
