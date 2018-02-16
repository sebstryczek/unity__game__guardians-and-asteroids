using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Start()
    {
        LevelsManager.Instance.LoadLevel(LevelsManager.SceneType.TMP);
    }

    private void Update()
    {
        
    }
}
