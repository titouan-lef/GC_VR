using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _sliderText;
    [SerializeField] protected Slider _slider;
    [SerializeField] protected AudioMixer _audioMixer;

    protected void ChangeVolume()
    {
        _sliderText.text = _slider.value.ToString("0") + " %";
    }
}
