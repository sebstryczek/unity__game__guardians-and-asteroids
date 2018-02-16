using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DebugExt
{
    public class UIConsole : MonoBehaviour, IPointerDownHandler
    {
        [Header("Prefabs")]
        [SerializeField] private DebugExt.UIConsoleLog uiConsoleLog;
        private List<DebugExt.UIConsoleLog> logItems = new List<DebugExt.UIConsoleLog>();

        private DebugExtController debugExtController;
        public bool isVisible { get { return this.gameObject.activeSelf; } }
        private ScrollRect scrollRect;
        private RectTransform content;
        [SerializeField] private bool collapse = true;
        private bool touched = false;

        private void Awake()
        {
            this.scrollRect = this.GetComponentInChildren<ScrollRect>();
            this.content = this.scrollRect.content;
            this.debugExtController = this.GetComponentInParent<DebugExtController>();
        }

        public void Clear()
        {
            this.logItems.Clear();
            foreach (Transform child in this.content)
            {
                GameObject.Destroy(child.gameObject);
            }
            this.touched = false;
        }

        public void ToggleCollapse()
        {
            this.collapse = !this.collapse;
            this.ApplyVisibility();
            this.ApplyColors();
        }

        public void Minimize()
        {
            this.scrollRect.gameObject.SetActive(!this.scrollRect.gameObject.activeSelf);
        }

        public void Show()
        {
            this.gameObject.SetActive(true);
        }

        public void Hide()
        {
            this.gameObject.SetActive(false);
        }

        public void Log(string msg)
        {
            UIConsoleLog item = GameObject.Instantiate(this.uiConsoleLog);
            item.SetParent(this.content);
            item.SetDateText(this.debugExtController.GetFormatedDateTime(System.DateTime.Now));
            item.SetMessageText(msg);

            DebugExt.UIConsoleLog prevItem = this.logItems.LastOrDefault();

            bool isFirst = prevItem == null;
            if (isFirst)
            {
                this.logItems.Add(item);
            }
            else
            {
                string prevItemMsg = prevItem.GetMessageText();
                if (msg == prevItemMsg)
                {
                    prevItem.Duplicates.Add(item);
                    prevItem.SetCountText(prevItem.Duplicates.Count.ToString());
                }
                else
                {
                    this.logItems.Add(item);
                }
            }

            this.ApplyVisibility();
            this.ApplyColors();
        }

        private void ApplyVisibility()
        {
            for (int i = 0; i < this.logItems.Count; i++)
            {
                DebugExt.UIConsoleLog item = this.logItems[i];
                item.SetCountVisibility(this.collapse && item.Duplicates.Count != 0);
                if (item.Duplicates.Count > 0)
                {
                    for (int j = 0; j < item.Duplicates.Count; j++)
                    {
                        DebugExt.UIConsoleLog duplicateItem = item.Duplicates[j];
                        duplicateItem.SetCountVisibility(this.collapse);
                        duplicateItem.SetVisibility(!this.collapse);
                    }
                }
            }
        }

        private void Update()
        {
            if (!this.touched)
            {
                this.scrollRect.verticalNormalizedPosition = 0;
            }

        }

        public void OnPointerDown(PointerEventData eventData)
        {
            this.touched = true;
        }

        private void ApplyColors()
        {
            for (int i = 0; i < this.logItems.Count; i++)
            {
                DebugExt.UIConsoleLog prevItem = i > 0 ? this.logItems[i - 1] : null;
                DebugExt.UIConsoleLog item = this.logItems[i];

                float prevAlpha = 1;

                if (prevItem != null)
                {
                    prevAlpha = prevItem.Duplicates.Count == 0 || this.collapse ? prevItem.GetBackgroundAlpha() : prevItem.Duplicates.LastOrDefault().GetBackgroundAlpha();
                }

                float alpha = prevAlpha == 1 ? 0.33f : 1;
                item.SetBackgroundAlpha(alpha);

                if (!this.collapse)
                {
                    for (int j = 0; j < item.Duplicates.Count; j++)
                    {
                        DebugExt.UIConsoleLog duplicateItem = item.Duplicates[j];
                        alpha = alpha == 1 ? 0.33f : 1;
                        duplicateItem.SetBackgroundAlpha(alpha);
                    }
                }
            }
        }
    }
}
