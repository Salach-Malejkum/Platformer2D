using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FallLostScript : MonoBehaviour
{
    public TextMeshPro lostText;

    // Start is called before the first frame update
    void Start()
    {
        lostText.enabled = false;
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
