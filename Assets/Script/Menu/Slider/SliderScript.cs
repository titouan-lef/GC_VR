using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField] protected Slider _slider;
    [SerializeField] protected TextMeshProUGUI _sliderText;

    protected void Init()
    {
        _slider.onValueChanged.AddListener(v =>
        {
            _sliderText.text = v.ToString("0") + " %";
            SetSliderValue(v);
        });
    }

    protected virtual void SetSliderValue(float value)
    {
    }
}
