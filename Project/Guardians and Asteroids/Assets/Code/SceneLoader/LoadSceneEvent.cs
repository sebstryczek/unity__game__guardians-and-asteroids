using UnityEngine;
using Object = UnityEngine.Object;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "LoadSceneEvent", menuName = "ScriptableObject/LoadSceneEvent", order = 0)]
public class LoadSceneEvent : ScriptableObject
{
    [SerializeField]
    private SceneField scene;

    public void Load()
    {
        SceneManager.LoadScene(scene.SceneName);
    }
}
