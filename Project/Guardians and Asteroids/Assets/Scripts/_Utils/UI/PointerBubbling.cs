using UnityEngine;
using UnityEngine.EventSystems;

public class PointerBubbling : MonoBehaviour, IPointerDownHandler
{
  public void OnPointerDown(PointerEventData eventData)
  {
    ExecuteEvents.ExecuteHierarchy(transform.parent.gameObject, eventData, ExecuteEvents.pointerDownHandler);
  }

}
