using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "StateEnvironment", menuName = "ScriptableObject/StateEnvironment", order = 0)]
public class StateEnvironment : StateFragment
{
    private enum Environment
    {
        DEVELOPMENT,
        PRODUCTION
    }

    [SerializeField] private Environment environment = Environment.DEVELOPMENT;

    public override void Init()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        Debug.Log("Current scene: " + sceneName);
        string environmentName = this.GetEnvironmentName();
        Debug.Log("Current environment: " + environmentName);
    }

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
