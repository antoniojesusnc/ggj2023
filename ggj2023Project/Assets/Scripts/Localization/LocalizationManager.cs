using UnityEngine;

public class LocalizationManager : Singleton<LocalizationManager>
{
    [SerializeField]
    private LocalizationConfiguration _localizationConfig;

    public string GetTittleText(LocalizationTypes localizationType)
    {
        return _localizationConfig.GetTittleKeyText(localizationType);
    }
    
    public string GetText(LocalizationTypes localizationType)
    {
        return _localizationConfig.GetKeyText(localizationType);
    }

    public void SetLanguage(Languages language)
    {
        _localizationConfig.LoadLanguage(language);
    }
}
