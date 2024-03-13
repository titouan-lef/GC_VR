public class SoundSliderScript : SliderScript
{
    protected override void SetSliderValue(float value)
    {
        SoundVolume.Instance.SoundParam = value / 100.0f;
    }
}
