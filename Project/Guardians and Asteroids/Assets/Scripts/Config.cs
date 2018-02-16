using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : Singleton<Config>
{
    private enum Environment
    {
        DEVELOPMENT,
        PRODUCTION
    }

    [SerializeField] private Environment environment = Environment.DEVELOPMENT;

    public bool IsDevelopment {
        get {
            return this.environment == Environment.DEVELOPMENT;
        }
    }
}
