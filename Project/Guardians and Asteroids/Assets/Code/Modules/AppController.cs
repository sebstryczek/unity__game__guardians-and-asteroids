using UnityEngine;
using UnityEngine.Events;

public class AppController : MonoBehaviour
{
    [SerializeField] private UnityEvent onLevelStart;
    
    private void Awake()
    {
        this.onLevelStart.Invoke();
    }

    public void Play()
    {
        Time.timeScale = 1;
    }
    
    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
