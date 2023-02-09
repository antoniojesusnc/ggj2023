using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine;

[CreateAssetMenu(fileName = "LocalizationConfiguration", menuName = "ScriptableObjects/LocalizationConfiguration", order = 1)]
public class LocalizationConfiguration : ScriptableObject
{
    private string LOCALIZATION_FOLDER = "Assets/GameConfig/Localization/";
    private string LOCALIZATION_FILE = "localizationData.json";
    
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

    [ContextMenu("ExportLocalization")]
    public void ExportLocalization()
    {
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(_localizationConfig, typeof(List<LocalizationConfigurationInfo>), Formatting.Indented, new JsonSerializerSettings());
        File.WriteAllText(LOCALIZATION_FOLDER+LOCALIZATION_FILE, json);
    }
    
    [ContextMenu("ImportLocalization")]
    public void ImportLocalization()
    {
        var fileRaw = File.ReadAllText(LOCALIZATION_FOLDER+LOCALIZATION_FILE);
        var newData = JsonConvert.DeserializeObject<List<LocalizationConfigurationInfo>>(fileRaw);
        if (newData?.Count > 0)
        {
            _localizationConfig = newData.ToList();
        }
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
