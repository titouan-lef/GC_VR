using UnityEngine;

public class SoundSliderScript : SliderScript
{
    private void Start()
    {
        ChangeSoundVolume();
    }

    public void ChangeSoundVolume()
    {
        ChangeVolume();
        _audioMixer.SetFloat("SoundVolume", Mathf.Log10(_slider.value / 100f) * 20 + 1);
        SoundVolume.Instance.SoundParam = _slider.value;
    }
}
