using UnityEngine;

[CreateAssetMenu(fileName = "Config", menuName = "ScriptableObjects/Config", order = 0)]
public class Config : ScriptableObject
{
    private enum Environment
    {
        DEVELOPMENT,
        PRODUCTION
    }

    [SerializeField] private Environment environment = Environment.DEVELOPMENT;

    public string GetEnvironmentName()
    {
        return this.environment.ToString();
    }
    public bool IsDevelopment
    {
        get
        {
            return this.environment == Environment.DEVELOPMENT;
        }
    }
}
