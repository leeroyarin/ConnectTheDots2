using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class ColorSettings : MonoBehaviour
{
    
    [SerializeField] Slider brightnessSlider;
    [SerializeField] Slider contrastSlider;
    [SerializeField] Slider saturationSlider;

    [SerializeField] private Volume v;
    [SerializeField] private ColorAdjustments setting;

    public SettingsManager colourSettings;

    public void Awake()
    {
        colourSettings = FindObjectOfType<SettingsManager>();
        brightnessSlider = colourSettings.GetBrightness();
        contrastSlider = colourSettings.GetContrast();
        saturationSlider = colourSettings.GetSaturation();
    }
    public void Start()
    {
        v = GetComponent<Volume>();
        v.profile.TryGet(out setting);
        
        #region Adjusting Maximum Value
        brightnessSlider.maxValue = 1f;
        brightnessSlider.minValue = -2f;

        contrastSlider.maxValue = 100f;
        contrastSlider.minValue = -50f;

        saturationSlider.maxValue = 100f;
        saturationSlider.minValue = -100f;
        #endregion

        if (PlayerPrefs.HasKey("Brightness"))
        {
            setting.postExposure.value = brightnessSlider.value = PlayerPrefs.GetFloat("Brightness");
            setting.contrast.value = contrastSlider.value = PlayerPrefs.GetFloat("Contrast");
            setting.saturation.value = saturationSlider.value = PlayerPrefs.GetFloat("Saturation");
        }
        else
        {
            setting.postExposure.value = brightnessSlider.value = 0f;
            setting.contrast.value = contrastSlider.value = 0f;
            setting.saturation.value = saturationSlider.value = 0f;
        }
    }

    public void resetColour()
    {
        if (setting != null)
        {
            setting.postExposure.value = brightnessSlider.value = 0.01194698f;
            setting.contrast.value = contrastSlider.value = 0.83559f;
            setting.saturation.value = saturationSlider.value = 35.4568f;
        }
        
    }

    public void ColorUpdate()
    {
        setting.postExposure.value = brightnessSlider.value;
        setting.contrast.value = contrastSlider.value;
        setting.saturation.value = saturationSlider.value;
    }


    public void OnSave()
    {
        PlayerPrefs.SetFloat("Brightness", setting.postExposure.value);
        PlayerPrefs.SetFloat("Saturation", setting.saturation.value);
        PlayerPrefs.SetFloat("Contrast", setting.contrast.value);
    }
}
