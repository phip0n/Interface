using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Slider))]
public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Menu _menu;
    [SerializeField] private AudioData.VolumeGroup _chanel;
    
    private string _chanelName;

    private void Awake()
    {
        _chanelName = _chanel.ToString();
        Slider slider = GetComponent<Slider>();
        float sliderValue = Mathf.Pow(10, _menu.GetMixerValue(_chanelName) / AudioData.Multiplyer);
        slider.SetValueWithoutNotify(sliderValue);
    }

    public void ChangeVolume(float value)
    {
        _menu.ChangeVolume(_chanelName, Mathf.Log10(value) * AudioData.Multiplyer);
    }
}
