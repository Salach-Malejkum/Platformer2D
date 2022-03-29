using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EnemyScript : MonoBehaviour
{
    public int speed = 1;
    public bool direction = true;
    public float limitRight = 15;
    public float limitLeft = 10;
    public TextMeshPro lostText;

    // Start is called before the first frame update
    void Start()
    {
        lostText.enabled = false;
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

    IEnumerator Wait()
    {
        lostText.enabled = true;
        yield return new WaitForSeconds(2f);
        Destroy(GameObject.FindGameObjectWithTag("BgMusic"));
        Destroy(GameObject.FindGameObjectWithTag("MainCamera"));
        SceneManager.LoadScene("Menu");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            StartCoroutine(Wait());
        }
    }
}
