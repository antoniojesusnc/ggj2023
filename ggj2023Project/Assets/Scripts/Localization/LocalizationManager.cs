using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : Singleton<LocalizationManager>
{
    [SerializeField]
    private LocalizationConfiguration _localizationConfig;

    public string GetTittleText(LocalizationTypes localizationType)
    {
        return _localizationConfig.GetTittleKeyText(localizationType, GeneralSetting.Instance.Language);
    }
    
    public string GetText(LocalizationTypes localizationType)
    {
        return _localizationConfig.GetKeyText(localizationType, GeneralSetting.Instance.Language);
    }
}
