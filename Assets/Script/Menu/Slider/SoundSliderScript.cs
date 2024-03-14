using UnityEngine;

public class SoundSliderScript : SliderScript
{
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        _slider.value = SoundVolume.Instance.SoundParam;
        ChangeSoundVolume();
    }

    public void ChangeSoundVolume()
    {
        ChangeVolume();
        _audioMixer.SetFloat("SoundVolume", Mathf.Log10(_slider.value) * 20 + 1);
        SoundVolume.Instance.SoundParam = _slider.value;
        _audioSource.Play();
    }
}
