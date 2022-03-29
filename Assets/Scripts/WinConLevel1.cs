using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinConLevel1 : MonoBehaviour
{
    public TextMeshPro winText;
    public Player player;
    private Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
        winText.enabled = false;
        playerScript = player.GetComponent<Player>();
    }

    IEnumerator LevelCompleted()
    {
        playerScript.win = true;
        winText.enabled = true;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level2");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(LevelCompleted());
        }
    }
}
