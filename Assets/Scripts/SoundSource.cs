using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSource : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audio;

    private void Awake()
    {
        DontDestroyOnLoad(audio.gameObject);
    }
}