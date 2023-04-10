using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    public Slider volumeSlider;
    public Toggle notificationToggle;

    public bool notificationEnabled = false;

    public static GameSettings instance;
    private void Awake()
    {
        instance = this;

        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 0.5f);
        }

        if (!PlayerPrefs.HasKey("notificationEnabled"))
        {
            PlayerPrefs.SetInt("notificationEnabled", 1);
        }

        Save();
    }

    private void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
        SetVolume(volumeSlider.value);

        int notif = PlayerPrefs.GetInt("notificationEnabled");

        if (notif == 1)
        {
            notificationToggle.isOn = true;
            notificationEnabled = true;
        }
        else
        {
            notificationToggle.isOn = false;
            notificationEnabled = false;
        }
    }

    public void SetNotificationToggle(bool x)
    {
        if (x)
        {
            PlayerPrefs.SetInt("notificationEnabled", 1);
            notificationEnabled = true;
        }
        else
        {
            PlayerPrefs.SetInt("notificationEnabled", 0);
            notificationEnabled = false;
        }
    }

    public void SetVolume(float x)
    {
        PlayerPrefs.SetFloat("volume", x);
        // Update the volume of your audio sources here
        Save();
    }

    private void Save()
    {
        PlayerPrefs.Save();
    }
}
