using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralSetting : Singleton<GeneralSetting>
{
    public Languages Language { get; private set; } = Languages.Es;

    public void SetLanguage(Languages languages)
    {
        Language = languages;
    }
}
