using UnityEngine;
using UnityEngine.UI;

public class AudioVolumen : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image imagenMute;

    void Start()
    {
        sliderValue = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        slider.value = sliderValue; 
        AudioListener.volume = sliderValue;
        RevisaMute();
    }

    public void CambiarSlider(float valor)
    {
        sliderValue = valor; 
        slider.value = sliderValue; 
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = sliderValue; 
        RevisaMute();
    }

    public void RevisaMute()
    {
        if (imagenMute != null)
        {
            imagenMute.enabled = (sliderValue == 0);
        }
    }
}
