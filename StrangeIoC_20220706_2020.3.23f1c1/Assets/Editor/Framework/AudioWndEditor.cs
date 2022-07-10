/****************************************************
    文件：AudioWndEditor.cs
	作者：lenovo
    邮箱: 
    日期：2022/7/8 15:41:14
	功能：
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Random = UnityEngine.Random;
using System;
using System.Text;
using System.IO;
using UnityEngine.UI;

namespace Extense
{
    [InitializeOnLoad]
    public class AudioWndEditor : EditorWindow
    {
        #region 字段
        public  string audioName;
        public  string audioPath;
        /// <summary>内存生命挂载跟随窗口</summary>
        Dictionary<string, string> audioDic = new Dictionary<string, string>();
        //
        /// <summary>time s刷新面板，防止从VS修改回来过后清空</summary>
        public float timer = 0f;
        public float time = 2f;


     
        #endregion

        #region 生命
        private void Awake()
        {
            // Test_Application_Path();
            LoadList();
            timer = 0f;
            time = 2f;

        }
        
        private void OnInspectorUpdate()//1s跑10次
        {
            
            timer += 0.1f;
            if (timer > time)
            {
                LoadList();
                timer = 0f;
            }
        }

        [MenuItem("Manager/AudioMgr")]
        static void CreateAudioWnd()
        { 
            Rect rect=new Rect(0,0,500,500);//会记录上次位置
            AudioWndEditor wnd =GetWindow<AudioWndEditor>();
            wnd.Show();
        }

        private void OnGUI()
        {

            ShowList();
            audioName = EditorGUILayout.TextField("文件名", audioName);
            audioPath = EditorGUILayout.TextField("路径", audioPath);
            if (GUILayout.Button("添加音效"))
            {
                ShowList();
                //
                AudioClip clip = Resources.Load<AudioClip>(audioPath);
                if (clip == null)
                {
                    Debug.LogWarning("路径\"" + audioPath + "\"不存在");
                    audioPath = "";
                }
                else
                {
                    if (audioDic.ContainsKey(audioName))
                    {
                        Debug.LogWarning("文件\"" + audioName + "\"已存在");
                    }
                    else
                    {
                        audioDic.Add(audioName, audioPath);
                        SaveList();
                        Debug.Log("文件\"" + audioName + "\"添加成功");
                    }
                }
            }
            if (GUILayout.Button("ResAudio"))
            {
                audioPath = "ResAudio/" + audioName;
            }
            if (GUILayout.Button("重置输入"))
            {

                audioName = "";
                audioPath = "";
            }
            if (GUILayout.Button("清空音效"))
            {
                audioDic.Clear();
                SaveList();
                Debug.Log("文件\"" + audioName + "\"清空成功");
            }

            if (GUILayout.Button("显示音效列表"))
            {

                ShowList();
            }
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("保存列表"))
            {

                SaveList();
                Debug.Log("文件\"" + Constants.SavePath_Framework + "\"保存成功");
            }
            if (GUILayout.Button("加载列表"))
            {

                LoadList();
                Debug.Log("文件\"" + Constants.SavePath_Framework + "\"加载成功");
            }
            GUILayout.EndHorizontal();

        }
        
        #endregion



        #region 辅助
        /// <summary>
        /// 数据显示在面板上
        /// </summary>
        private void ShowList()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("文件名");
            GUILayout.Label("路径");
            GUILayout.Label("删除");
            GUILayout.EndHorizontal();


            foreach (string key in audioDic.Keys)
            {
                string value;
                audioDic.TryGetValue(key, out value);
                //
                GUILayout.BeginHorizontal();
                GUILayout.Label(key);
                GUILayout.Label(value);
                if (GUILayout.Button("删除"))
                {
                    audioDic.Remove(key);
                    SaveList();
                    return;//重新绘制
                }

                GUILayout.EndHorizontal();
                
            }
        }

        /// <summary>
        /// 数据保存到本地
        /// </summary>
        void SaveList()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string key in audioDic.Keys)
            {
                string value;
                audioDic.TryGetValue(key, out value);
                //
                sb.Append(key + "," + value + "\n");

            }

            File.WriteAllText(Constants.SavePath_Framework, sb.ToString());//覆盖
            File.WriteAllText(Constants.SavePath_Resources, sb.ToString());//覆盖
            //File.AppendAllText(Constants.SavePath, sb.ToString());//追加

            AssetDatabase.Refresh();//刷新文件夹
        }


        /// <summary>
        /// 加载本地数据到面板
        /// </summary>
        void LoadList()
        {
            if (File.Exists(Constants.SavePath_Framework) == false)
            { 
                return;
            }
            //
            audioDic.Clear();
            string[] lines = File.ReadAllLines(Constants.SavePath_Framework);
            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }
                else
                { 
                   string[] pairs = line.Split(',');
                    audioDic.Add(pairs[0], pairs[1]);   
                }
            }
        }


        void Test_Application_Path()
        {
            //Debug.Log(Application.consoleLogPath);
            //Debug.Log(Application.temporaryCachePath);
            //Debug.Log(Application.persistentDataPath); 
            ////
            //Debug.Log(Application.dataPath);
            //Debug.Log(Application.streamingAssetsPath);
        }


        /// <summary>
        /// 大小不可以拖拽
        /// </summary>
        private void CreateType01()
        {
            Rect rect = new Rect(0, 0, 500, 500);
            AudioWndEditor wnd= GetWindowWithRect( typeof(AudioWndEditor),rect) as AudioWndEditor;
        }

        void OnGUI01()
        { 
            GUILayout.TextField("默认输入文字");        
        }
        #endregion

        #region 系统

        #endregion
    }

   
}