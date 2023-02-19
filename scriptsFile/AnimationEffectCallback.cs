using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using General;

[System.Serializable]
public class EffectSetting
{
    public string name;
    public Transform createAt;
    public GameObject effect;
}

public class AnimationEffectCallback : MonoBehaviour
{
    public List<EffectSetting> effectSettings;
    CallbackRegistry callbackRegistry;
    // Start is called before the first frame update
    void Start()
    {
        callbackRegistry = GetComponent<CallbackRegistry>();
        callbackRegistry.AddCallback(new Callback(
            "MaceAttackR2",
            MaceAttackR2
        ));
    }

    EffectSetting GetSettingWithName(string name)
    {
        return effectSettings.Find(setting => setting.name == name);
    }

    void MaceAttackR2()
    {
        EffectSetting setting = GetSettingWithName("MaceAttackR2");
        if (setting != null)
        {
            GameObject obj = Instantiate(
                setting.effect, setting.createAt.position, setting.effect.transform.rotation);
        }
    }
}
