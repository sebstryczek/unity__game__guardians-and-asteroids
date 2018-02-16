using UnityEngine;

namespace DebugExt
{
    public class DebugExtController : MonoBehaviour
    {
        [SerializeField] private GameObject eventSystem;
        [SerializeField] private DebugExt.UIConsole uiConsole;
        [SerializeField] private bool useLogFile = true;
        [SerializeField] private bool useLogUIConsole = true;
        private string logFilePath = "";

        private void Awake()
        {
            this.logFilePath = this.PrepareLogFile();
        }

        private void Start()
        {
            if (GameObject.Find("EventSystem") == null)
            {
                Instantiate(eventSystem);
            }

            if (this.useLogUIConsole)
            {
                this.uiConsole.Show();
            }
            else
            {
                this.uiConsole.Hide();
            }
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.F1))
            {
                if (this.uiConsole.isVisible)
                {
                    this.uiConsole.Hide();
                }
                else
                {
                    this.uiConsole.Show();
                }
            }
        }

        public void Log(string msg)
        {
            this.LogFile(msg);
            this.LogUIConsole(msg);
        }

        void OnEnable()
        {
            Application.logMessageReceived += HandleLog;
        }

        void OnDisable()
        {
            Application.logMessageReceived -= HandleLog;
        }

        void HandleLog(string message, string stackTrace, LogType type)
        {
            this.Log(message);
        }

        private string PrepareLogFile()
        {
            string path = Application.dataPath;
            if (Application.isEditor) path += "/../";
            System.IO.DirectoryInfo dirRoot = new System.IO.DirectoryInfo(path);
            System.IO.DirectoryInfo dirLogs = dirRoot.CreateSubdirectory("Logs");
            System.IO.DirectoryInfo dirToday = dirLogs.CreateSubdirectory(System.DateTime.Now.ToString("yyyy-MM-dd"));
            string filePath = dirToday.ToString() + "/" + System.DateTime.Now.ToString("yyyy-MM-dd__HH-mm-ss") + ".txt";
            if (!System.IO.File.Exists(filePath)) System.IO.File.Create(filePath).Close();
            return filePath;
        }

        public void LogFile(string msg)
        {
            if (this.useLogFile)
            {
                System.IO.File.AppendAllText(this.logFilePath, this.GetFormatedDateTime(System.DateTime.Now));
                System.IO.File.AppendAllText(this.logFilePath, "\n");
                System.IO.File.AppendAllText(this.logFilePath, msg);
                System.IO.File.AppendAllText(this.logFilePath, "\n");
                System.IO.File.AppendAllText(this.logFilePath, "\n");
            }
        }

        public void LogUIConsole(string msg)
        {
            if (this.useLogUIConsole)
            {
                this.uiConsole.Log(msg);
            }
        }

        public string GetFormatedDateTime(System.DateTime dateTime)
        {
            return string.Format("[ {0} ]", dateTime.ToString("dd-MM-yyyy HH:mm:ss:fff"));
        }
    }
}
