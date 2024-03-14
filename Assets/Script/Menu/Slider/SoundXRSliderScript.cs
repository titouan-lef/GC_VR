using UnityEngine;

public class XRSoundSliderScript : XRSliderScript
{
    [SerializeField] private AudioSource _audioSource;

    private void Awake()
    {
        _slider.value = SoundVolume.Instance.SoundParam;
        ChangeSoundVolume();
    }

    public void ChangeSoundVolume()
    {
        _sliderText.text = "Sound : " + (100 * _slider.value).ToString("0") + " %";
        _audioMixer.SetFloat("SoundVolume", Mathf.Log10(_slider.value) * 20 + 1);
        SoundVolume.Instance.SoundParam = _slider.value;
        _audioSource.Play();
    }
}
