using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Main : MonoBehaviour
{
    [SerializeField]
    private Config config;

    protected virtual void Awake()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        Debug.Log("Current scene: " + sceneName);

        Type type = this.GetType();
        string className = type.FullName;
        Debug.Log("Current class: " + className);

        if (this.config == null)
        {
            throw new MissingReferenceException("Config not found!");
        }

        Debug.Log("Current environment: " + config.GetEnvironmentName());
    }
}
