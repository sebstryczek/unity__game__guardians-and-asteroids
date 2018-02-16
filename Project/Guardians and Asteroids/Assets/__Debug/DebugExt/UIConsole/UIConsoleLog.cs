using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DebugExt
{
  public class UIConsoleLog : MonoBehaviour
  {
    [SerializeField] private Image background;
    [SerializeField] private Text date;
    [SerializeField] private Text message;
    [SerializeField] private Text count;

    private void Awake()
    {
      this.background = this.GetComponent<Image>();
    }

    private List<UIConsoleLog> duplicates;
    public List<UIConsoleLog> Duplicates
    {
      get
      {
        if (this.duplicates == null) this.duplicates = new List<UIConsoleLog>();
        return this.duplicates;
      }
    }

    public void SetParent(Transform t) { this.gameObject.transform.SetParent(t); }
    public void SetVisibility(bool state) { this.gameObject.SetActive(state); }

    public float GetBackgroundAlpha() { return (float) this.background.color.a; }
    public void SetBackgroundAlpha(float a)
    {
      Color prevColor = this.background.color;
      prevColor.a = a;
      this.background.color = prevColor;
    }

    public string GetDateText() { return this.date.text; }
    public void SetDateText(string s) { this.date.text = s; }

    public string GetMessageText() { return this.message.text; }
    public void SetMessageText(string s) { this.message.text = s; }

    public void SetCountVisibility(bool state) { this.count.gameObject.SetActive(state); }
    public void SetCountText(string s) { this.count.text = s; }

  }
}
