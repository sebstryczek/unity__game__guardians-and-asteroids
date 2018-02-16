using UnityEngine;

public abstract class Manager<T> : Singleton<T> where T : MonoBehaviour
{
    protected bool isInit = false;

    public void Init()
    {
        if (this.isInit) return;
        if (Config.Instance.IsDevelopment) Debug.Log(this.GetType() + ".Init()");
        this.Initializer();
        this.isInit = true;
    }

    protected abstract void Initializer();

    protected void Update()
    {
        if (this.isInit) return;
        this.Updater();
    }

    protected abstract void Updater();
}
