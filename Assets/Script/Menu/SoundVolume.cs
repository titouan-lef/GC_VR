using UnityEngine;
using UnityEngine.Audio;

public class SoundVolume
{
    [SerializeField] private AudioMixer _soundMixer;
    [SerializeField] private AudioMixer _musicMixer;

    private static SoundVolume _instance;

    private float _soundParam = 0.2f;
    private float _musicParam = 0.2f;

    public float SoundParam { get => _soundParam; }
    public float MusicParam { get => _musicParam; }

    public static SoundVolume Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SoundVolume();
            }
            return _instance;
        }
    }

    public void Init()
    {
        ChangeSoundVolume(_soundParam);
        ChangeMusicVolume(_musicParam);
    }

    public void ChangeSoundVolume(float value)
    {
        _soundParam = value;
        //_soundMixer.SetFloat("SoundVolume", Mathf.Log10(value) * 20);
    }

    public void ChangeMusicVolume(float value)
    {
        _musicParam = value;
        //_musicMixer.SetFloat("SoundVolume", Mathf.Log10(value) * 20);
    }
}
