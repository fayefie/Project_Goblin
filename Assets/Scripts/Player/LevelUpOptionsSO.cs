using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/LevelUpOptionsSO")]
public abstract class LevelUpOptionsSO : ScriptableObject
{
    [Header("Upgrade Information")]
    public string upgradeName;
    [TextArea] public string upgradeDescription;

    public abstract void Apply(GameObject player);
}
