public class MusicSliderScript : SliderScript
{
    private void Start()
    {
        _slider.value = SoundVolume.Instance.MusicParam * 100.0f;
        _sliderText.text = _slider.value.ToString("0") + " %";
        Init();
    }

    protected override void SetSliderValue(float value)
    {
        SoundVolume.Instance.ChangeMusicVolume(value / 100.0f);
    }
}
