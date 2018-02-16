using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsManager : Manager<LevelsManager>
{
    public enum SceneType
    {
        MAIN,
        TMP
    }

    private Dictionary<SceneType, string> scenes;

    protected override void Initializer()
    {
        this.scenes = new Dictionary<SceneType, string>()
        {
            { SceneType.MAIN, "0-Main" },
            { SceneType.TMP, "1-TMP" },
        };
    }

    protected override void Updater() { }

    public void LoadLevel(SceneType sceneType)
    {
        SceneManager.LoadScene(this.scenes[sceneType]);
    }
}
