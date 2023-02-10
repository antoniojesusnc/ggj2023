using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine;

[CreateAssetMenu(fileName = "LocalizationConfiguration", menuName = "ScriptableObjects/LocalizationConfiguration", order = 1)]
public class LocalizationConfiguration : ScriptableObject
{
    private string LOCALIZATION_FOLDER = "Assets/GameConfig/Localization/Resources/";
    private string LOCALIZATION_FILE = "localizationData{0}";
    private string EXTENSION = ".json";
    
    [SerializeField]
    private List<LocalizationConfigurationInfo> _localizationConfig;

    public string GetTittleKeyText(LocalizationTypes localizationKey)
    {
        var localizationConfigurationInfo = _localizationConfig.Find(language => language.LocalizationTypes == localizationKey);
        return localizationConfigurationInfo.Title;
    }
    
    public string GetKeyText(LocalizationTypes localizationKey)
    {
        var localizationConfigurationInfo = _localizationConfig.Find(language => language.LocalizationTypes == localizationKey);
        return localizationConfigurationInfo.Description;
    }

    [ContextMenu("ExportLocalization")]
    public void ExportLocalization()
    {
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(_localizationConfig, typeof(List<LocalizationConfigurationInfo>), Formatting.Indented, new JsonSerializerSettings());
        File.WriteAllText(LOCALIZATION_FOLDER+string.Format(LOCALIZATION_FILE, Languages.Es)+EXTENSION, json);
    }

    [ContextMenu("ImportLocalization ES")]
    public void ImportLocalizationEs()
    {
        LoadLanguage(Languages.Es);
    }
    [ContextMenu("ImportLocalization EN")]
    public void ImportLocalizationEn()
    {
        LoadLanguage(Languages.En);
    }
    
    public void LoadLanguage(Languages language)
    {
        var textAsset = Resources.Load<TextAsset>(string.Format(LOCALIZATION_FILE, language));
        var newData = JsonConvert.DeserializeObject<List<LocalizationConfigurationInfo>>(textAsset.text);
        if (newData?.Count > 0)
        {
            _localizationConfig = newData.ToList();
        }
    }
}

[System.Serializable]
public class LocalizationConfigurationInfo
{
    [field: SerializeField][JsonProperty][JsonConverter(typeof(StringEnumConverter))]
    public LocalizationTypes LocalizationTypes { get; private set; }
    
    [field: SerializeField][JsonProperty]
    public string Title { get; private set; }
    
    [field: SerializeField][JsonProperty]
    public string Description { get; private set; }
}
    
public enum Languages
{
    None,
    En,
    Es,
}
