using UnityEngine;

static public class MethodExtensionForMonoBehaviourTransform
{

  public static T GetOrAddComponent<T>(this GameObject go) where T : Component // derive from Component
  {
    T result = go.GetComponent<T>();

    if (result != null)
    {
      result = go.AddComponent<T>();
    }

    return result;
  }

  public static T GetOrAddComponent<T>(this Component comp) where T : Component // derive from Component
  {
    T result = comp.GetComponent<T>();

    if (result != null)
    {
      result = comp.gameObject.AddComponent<T>();
    }

    return result;
  }

}
