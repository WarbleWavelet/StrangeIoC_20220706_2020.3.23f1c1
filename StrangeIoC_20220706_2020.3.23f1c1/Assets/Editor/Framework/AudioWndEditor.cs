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

namespace Framework
{
    public class AudioWndEditor : EditorWindow
    {
        #region 字段
        public  string audioName;
        public  string audioPath;
        /// <summary>内存生命挂载跟随窗口</summary>
        Dictionary<string, string> audioDic = new Dictionary<string, string>();

        #endregion

        #region 生命
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
                    if ( audioDic.ContainsKey(audioName) )
                    {
                        Debug.LogWarning("文件\"" + audioName + "\"已存在");
                    }
                    else
                    {
                        audioDic.Add(audioName, audioPath);
                        Debug.Log("文件\"" + audioName + "\"添加成功");


                    }
                }
            }
            if (GUILayout.Button("ResAudio"))
            {
                audioPath = "ResAudio/"+audioName;
            }
            if (GUILayout.Button("重置输入"))
            {

                audioName = "";
                audioPath = "";
            }
            if (GUILayout.Button("清空音效"))
            {

                audioDic.Clear();
                Debug.Log("文件\"" + audioName + "\"清空成功");
            }

            if (GUILayout.Button("显示音效列表"))
            {

                ShowList();
            }


        }

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
                    return;//重新绘制
                }
 
                GUILayout.EndHorizontal();

            }
        }

        private void A()
        {
            AudioClip clip = LoadAudio(audioPath, true);
            if (clip == null)
            {
                Debug.LogWarning("路径\"" + audioPath + "\"不存在");
                audioPath = "";
            }
            else
            {
                if (ContainKey(ResType.Audio, audioPath))
                {
                    Debug.LogWarning("文件\"" + audioName + "\"已存在");
                    AudioSvc.Instance.PlayBgMusic("uiClickBtn");
                }
                else
                {
                    LoadAudio(audioPath, true);
                    Debug.LogWarning("文件\"" + audioName + "\"添加成功");
                    audioName = "";
                    audioPath = "";

                }
            }
        }

        #endregion 

        #region 系统

        #endregion 

        #region 辅助
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

        #region Audio


        Dictionary<string ,AudioClip> audioDic1=new Dictionary<string ,AudioClip>();    
        /// <summary>
        /// 加载声音
        /// </summary>
        /// <param name="path"></param>
        /// <param name="cache">缓存不？</param>
        /// <returns></returns>

        public AudioClip LoadAudio(string path, bool cache = false)
        {
            AudioClip au = null;
            if (audioDic1.TryGetValue(path, out au) == false)
            {
                au = Resources.Load<AudioClip>(path);
                if (cache)
                {
                    audioDic1.Add(path, au);
                }
            }

            return au;
        }

        public bool ContainKey(ResType type, string key)
        {
            bool isContain = false;
            switch (type)
            {
                case ResType.Audio:
                    {
                        isContain = audioDic.ContainsKey(key);
                    }
                    break;
                default:
                    {

                    }
                    break;
            }
            return isContain;
        }

        #endregion

    }

   
}