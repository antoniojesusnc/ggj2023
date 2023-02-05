using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LocalizationConfiguration", menuName = "ScriptableObjects/LocalizationConfiguration", order = 1)]
public class LocalizationConfiguration : ScriptableObject
{
    [SerializeField]
    private List<LocalizationConfigurationInfo> _localizationConfig;

    public string GetTittleKeyText(LocalizationTypes localizationKey, Languages language = Languages.Es)
    {
        var localizationConfigurationInfo = _localizationConfig.Find(language => language.LocalizationTypes == localizationKey);
        return localizationConfigurationInfo.GetTittleByLanguage(language);
    }
    
    public string GetKeyText(LocalizationTypes localizationKey, Languages language = Languages.Es)
    {
        var localizationConfigurationInfo = _localizationConfig.Find(language => language.LocalizationTypes == localizationKey);
        return localizationConfigurationInfo.GetDescriptionByLanguage(language);
    }
}

[System.Serializable]
public class LocalizationConfigurationInfo
{
    [field: SerializeField]
    public LocalizationTypes LocalizationTypes { get; private set; }
    
    [field: SerializeField]
    public List<LocalizationConfigurationInfoLanguage> Text { get; private set; }

    public string GetTittleByLanguage(Languages language)
    {
        return Text.Find(text => text.Language == language).Tittle;
    }
    
    public string GetDescriptionByLanguage(Languages language)
    {
        return Text.Find(text => text.Language == language).Description;
    }
}

[System.Serializable]
public class LocalizationConfigurationInfoLanguage
{
    [field: SerializeField]
    public Languages Language { get; private set; }

    [field: SerializeField]
    public string Tittle { get; private set; }
    
    [field: SerializeField]
    public string Description { get; private set; }
}
    
public enum Languages
{
    None,
    En,
    Es,
}
