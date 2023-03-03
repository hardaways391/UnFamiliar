using UnityEngine.Audio;
using UnityEngine;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer mainMixer;

    public void SetVolume(float volume)
    {
        mainMixer.SetFloat("Volume", volume);
    }

    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetQuality(int qualityIndex)

    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
