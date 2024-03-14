using UnityEngine;

public class MusicSliderScript : SliderScript
{
    private void Start()
    {
        _slider.value = SoundVolume.Instance.MusicParam;
        ChangeMusicVolume();
    }

    public void ChangeMusicVolume()
    {
        ChangeVolume();
        _audioMixer.SetFloat("MusicVolume", Mathf.Log10(_slider.value) * 40 + 1);
        SoundVolume.Instance.MusicParam = _slider.value;
    }
}
