using UnityEngine;
using Object = UnityEngine.Object;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "LoadSceneEvent", menuName = "GameEvents/LoadSceneEvent", order = 0)]
public class LoadSceneEvent : ScriptableObject
{
    public void LoadScene(Object obj)
    {
        SceneManager.LoadScene(obj.name);
    }
}
