using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class VolumeEdit : MonoBehaviour
{

    public Slider slider; //llamar el slider
    public float sliderValue;
    public Image imageM; //imagen de mute
    
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value;
        CheckMute();

        
    }

   
    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = slider.value;
        CheckMute();
        
    }

    public void CheckMute()
    {
        if (sliderValue == 0)
        {
            imageM.enabled = true;
        }
        else
        {
            imageM.enabled = false;
        }

    }
}
