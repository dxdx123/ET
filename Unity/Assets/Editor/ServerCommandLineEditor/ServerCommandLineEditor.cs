using UnityEditor;
using UnityEngine;

namespace ET
{
    public class ServerCommandLineEditor: EditorWindow
    {

        [MenuItem("Tools/打开服务器选项 _F4")]
        private static void ShowWindow()
        {
            GetWindow(typeof (ServerCommandLineEditor));
        }
        
        public void OnGUI()
        {
            GUILayout.BeginVertical();

            if (GUILayout.Button("启动MongoDB数据库"))
            {
                ProcessHelper.Run("mongod", @"--dbpath=db", "../Tools/MongoDB/bin/");
            }
            
            if (GUILayout.Button("导出Excel配置表"))
            {
                string arguments = $"--AppType=ExcelExporter";
                ProcessHelper.Run("dotnet Tools.dll ", arguments, "../../Bin/");
            }
            
            if (GUILayout.Button("生成Proto2CS"))
            {
                string arguments = $"--AppType=Proto2CS";
                ProcessHelper.Run("dotnet Tools.dll ", arguments, "../../Bin/");
            }
            
            if (GUILayout.Button("启动守护进程(Watcher)"))
            {
                string arguments = $"--AppType=Watcher --Process=1 --Console=1";
                ProcessHelper.Run("Server.exe", arguments, "../Bin/");
            }
            
            if (GUILayout.Button("启动机器人"))
            {
                string arguments = $"--AppType=Robot --Console=1";
                ProcessHelper.Run("Robot.exe", arguments, "../Bin/");
            }
            
            if (GUILayout.Button("启动服务器"))
            {
                string arguments = $"--AppType=Server --Console=1";
                ProcessHelper.Run("Server.exe", arguments, "../Bin/");
            }

            if (GUILayout.Button("刷新资源"))
            {
                AssetDatabase.Refresh();
            }
            
            //GUIUtility.ExitGUI();
            GUILayout.EndVertical();
        }
    }
}