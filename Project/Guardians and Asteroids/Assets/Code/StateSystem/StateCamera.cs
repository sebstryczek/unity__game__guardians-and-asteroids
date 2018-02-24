using UnityEngine;

[CreateAssetMenu(fileName = "StateCamera", menuName = "ScriptableObject/StateCamera", order = 0)]
public class StateCamera : StateFragment
{
    [SerializeField] private int CameraIndex;
    public Rect WorldRect { get; private set; }
    
    public override void Init()
    {
        if (Camera.allCamerasCount > this.CameraIndex)
        {
            Camera camera = Camera.allCameras[this.CameraIndex];
            this.WorldRect = this.GetWorldRect(camera);
        }
    }

    private Rect GetWorldRect(Camera camera)
    {
        Rect r = new Rect(0, 0, Screen.width, Screen.height);
        Vector3 minWorldPoint = camera.ScreenToWorldPoint(r.min);
        Vector3 maxWorldPoint = camera.ScreenToWorldPoint(r.max);
        return Rect.MinMaxRect(minWorldPoint.x, minWorldPoint.y, maxWorldPoint.x, maxWorldPoint.y);
    }
}
