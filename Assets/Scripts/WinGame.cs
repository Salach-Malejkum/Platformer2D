using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinGame : MonoBehaviour
{
    public TextMeshPro winText;
    public Player player;
    private Player playerScript;
    private GameObject audio;

    // Start is called before the first frame update
    void Start()
    {
        winText.enabled = false;
        playerScript = player.GetComponent<Player>();
        audio = GameObject.FindWithTag("BgMusic");
    }

    IEnumerator LevelCompleted()
    {
        playerScript.win = true;
        winText.enabled = true;
        yield return new WaitForSeconds(2f);
        Destroy(audio);
        SceneManager.LoadScene("Menu");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(LevelCompleted());
        }
    }
}
