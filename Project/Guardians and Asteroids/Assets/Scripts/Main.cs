using UnityEngine;

public class Main : Singleton<Main>
{
    private void Awake()
    {
        GameManager.Instance.Init();
        LevelsManager.Instance.Init();
    }
}
