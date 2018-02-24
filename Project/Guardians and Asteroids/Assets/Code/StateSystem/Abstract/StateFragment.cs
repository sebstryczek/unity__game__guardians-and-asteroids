using System.Collections.Generic;
using UnityEngine;

public abstract class StateFragment : ScriptableObject
{
    protected bool IsInit { get; private set; }
    public virtual void Init()
    {
        if (this.IsInit)
        {
            return;
        }
        
        this.IsInit = true;
    }
}
