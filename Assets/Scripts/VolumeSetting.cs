using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private AudioSettings audioSettings;

    private void Start()
    {
        LoadSettings();
        ApplySettings();
    }

    public void SetMasterVolume()
    {
        float volume = masterSlider.value;
        audioSettings.masterVolume = volume;
        ApplySettings();
        SaveSettings();
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        audioSettings.musicVolume = volume;
        ApplySettings();
        SaveSettings();
    }

    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        audioSettings.sfxVolume = volume;
        ApplySettings();
        SaveSettings();
    }

    private void SaveSettings()
    {
        // Save the audio data in the ScriptableObject
        PlayerPrefs.SetFloat("MasterVolume", audioSettings.masterVolume);
        PlayerPrefs.SetFloat("MusicVolume", audioSettings.musicVolume);
        PlayerPrefs.SetFloat("SFXVolume", audioSettings.sfxVolume);

        // Save the slider positions
        PlayerPrefs.SetFloat("MasterSlider", masterSlider.value);
        PlayerPrefs.SetFloat("MusicSlider", musicSlider.value);
        PlayerPrefs.SetFloat("SFXSlider", sfxSlider.value);

        PlayerPrefs.Save();
    }

    private void LoadSettings()
    {
        // Load the audio data from the ScriptableObject
        audioSettings.masterVolume = PlayerPrefs.GetFloat("MasterVolume", audioSettings.masterVolume);
        audioSettings.musicVolume = PlayerPrefs.GetFloat("MusicVolume", audioSettings.musicVolume);
        audioSettings.sfxVolume = PlayerPrefs.GetFloat("SFXVolume", audioSettings.sfxVolume);

        // Load the slider positions
        masterSlider.value = PlayerPrefs.GetFloat("MasterSlider", masterSlider.value);
        musicSlider.value = PlayerPrefs.GetFloat("MusicSlider", musicSlider.value);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXSlider", sfxSlider.value);
    }

    private void ApplySettings()
    {
        // Apply the volume values to the audio channels
        audioMixer.SetFloat("Master", Mathf.Log10(audioSettings.masterVolume) * 20f);
        audioMixer.SetFloat("Music", Mathf.Log10(audioSettings.musicVolume) * 20f);
        audioMixer.SetFloat("SFX", Mathf.Log10(audioSettings.sfxVolume) * 20f);
    }
}