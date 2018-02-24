using System.Collections.Generic;
using UnityEngine;

public class State : Singleton<State>
{
    [SerializeField] private List<StateFragment> state = new List<StateFragment>();

    private void Awake()
    {
        this.state.ForEach( x => x.Init() );
    }

    public T Get<T>() where T : StateFragment
    {
        T result;
        try
        {
            result = this.state.Find( x => x.GetType() == typeof(T) ) as T;
        }
        catch (System.Exception)
        {
            string typeName = typeof(T).ToString();
            throw new UnityException(typeName + " not found!");
        }
        return result;
    }
}
