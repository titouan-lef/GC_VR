using UnityEngine;

public class MusicXRSliderScript : XRSliderScript
{
    private void Awake()
    {
        _slider.value = SoundVolume.Instance.MusicParam;
        ChangeMusicVolume();
    }

    public void ChangeMusicVolume()
    {
        _sliderText.text = "Music : " + (100 * _slider.value).ToString("0") + " %";
        _audioMixer.SetFloat("MusicVolume", Mathf.Log10(_slider.value) * 20 + 1);
        SoundVolume.Instance.MusicParam = _slider.value;
    }
}
