using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayHandler()
    {
        SceneManager.LoadScene("Level1");
    }
}
