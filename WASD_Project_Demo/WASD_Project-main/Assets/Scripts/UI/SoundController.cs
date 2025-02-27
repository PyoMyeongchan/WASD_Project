using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider MasterVolumeSlider;
    [SerializeField] private Slider BGMslider;
    [SerializeField] private Slider SfXSlider;

    private void Awake()
    {

        MasterVolumeSlider.onValueChanged.AddListener(SetMaster);
        BGMslider.onValueChanged.AddListener(SetBGM);
        SfXSlider.onValueChanged.AddListener(SetSFX);
    }


    public void SetMaster(float volume)
    {
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);

    }

    public void SetBGM(float volume)
    {
        audioMixer.SetFloat("BGM", Mathf.Log10(volume) * 20);

    }

    public void SetSFX(float volume)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);

    }


}
