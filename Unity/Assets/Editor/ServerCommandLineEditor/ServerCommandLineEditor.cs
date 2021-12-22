﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace ET
{
    public class ServerCommandLineEditor: EditorWindow
    {

        [MenuItem("Tools/打开服务器选项")]
        private static void ShowWindow()
        {
            GetWindow(typeof (ServerCommandLineEditor));
        }
        
        public void OnGUI()
        {
            GUILayout.BeginVertical();

            if (GUILayout.Button("启动MongoDB数据库"))
            {
                ProcessHelper.Run("mongod", @"--dbpath=db", "../Tools/mongodb/bin/");
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