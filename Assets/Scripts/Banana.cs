using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
    public Player player;
    private Player playerScript;
    private bool isLocked = false;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<Player>();
    }

    // Update is called once per frame
    IEnumerator SpeedBoost()
    {
        if (!isLocked)
        {
            isLocked = true;
            playerScript.speed *= 2;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            yield return new WaitForSeconds(3f);
            playerScript.speed /= 2;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(SpeedBoost());
        }
    }
}
