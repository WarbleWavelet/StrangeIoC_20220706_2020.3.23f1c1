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
 
namespace Framework
{
    public class AudioWndEditor : EditorWindow
    {
        #region 字段
        public  string audioName;
        public  string audioPath;   
        Dictionary<string, AudioClip> audioDic = new Dictionary<string, AudioClip>();

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
            audioName = EditorGUILayout.TextField("文件名", audioName);
            audioPath = EditorGUILayout.TextField("路径", audioPath);
            if (GUILayout.Button("添加音效"))
            { 
            
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
                        audioDic.Add(audioName, clip);
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

        /// <summary>
        /// 加载声音
        /// </summary>
        /// <param name="path"></param>
        /// <param name="cache">缓存不？</param>
        /// <returns></returns>

        public AudioClip LoadAudio(string path, bool cache = false)
        {
            AudioClip au = null;
            if (audioDic.TryGetValue(path, out au) == false)
            {
                au = Resources.Load<AudioClip>(path);
                if (cache)
                {
                    audioDic.Add(path, au);
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