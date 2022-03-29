using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Slider slider;
    public TMP_Text mText;
    public AudioSource audio;
    public Toggle musicOn;
    // Start is called before the first frame update
    void Start()
    {
        Player.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        mText.SetText("Volume: " + (slider.value * 100).ToString("F0"));
        audio.volume = slider.value;

        if (musicOn.isOn)
        {
            mText.SetText("Volume: " + (slider.value * 100).ToString("F0"));
            audio.volume = slider.value;
        }
        else
        {
            audio.volume = 0;

        }
    }
}
