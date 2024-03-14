using UnityEngine;

public class MusicSliderScript : SliderScript
{
    private void Start()
    {
        ChangeMusicVolume();
    }

    public void ChangeMusicVolume()
    {
        ChangeVolume();
        _audioMixer.SetFloat("MusicVolume", Mathf.Log10(_slider.value / 100f) * 20 + 1);
        SoundVolume.Instance.MusicParam = _slider.value;
    }
}
