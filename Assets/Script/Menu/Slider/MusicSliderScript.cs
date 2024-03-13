public class MusicSliderScript : SliderScript
{
    protected override void SetSliderValue(float value)
    {
        SoundVolume.Instance.MusicParam = value / 100.0f;
    }
}
