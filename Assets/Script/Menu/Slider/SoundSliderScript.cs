public class SoundSliderScript : SliderScript
{
    private void Start()
    {
        _slider.value = SoundVolume.Instance.SoundParam * 100.0f;
        _sliderText.text = _slider.value.ToString("0") + " %";
        Init();
    }
    
    protected override void SetSliderValue(float value)
    {
        SoundVolume.Instance.ChangeSoundVolume(value / 100.0f);
    }
}
