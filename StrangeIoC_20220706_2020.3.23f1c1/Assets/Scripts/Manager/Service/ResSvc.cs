/****************************************************
    文件：ResSvc.cs
	作者：Plane
    邮箱: 1785275942@qq.com
    日期：2018/12/3 5:31:29
	功能：资源加载服务
*****************************************************/

using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace Demo02
{
    public class ResSvc : MonoBehaviour
    {
        public static ResSvc Instance = null;

        public void InitSvc()
        {
            Instance = this;
            InitAudioCfg();
            Debug.Log("ResSvc Init...");
        }

        private void InitAudioCfg()
        {
           
            TextAsset ta= Resources.Load<TextAsset>("ResText/audiolist"); //不加后缀
            string[] lines= ta.text.Split('\n');
            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line))
                { 
                    continue;
                } 
                string[] kv= line.Split(',');
                string key= kv[0];
                string value= kv[1];
                LoadAudio(value,true);

            }
            int a = 1;//打断点
        }

        private Dictionary<string, AudioClip> audioDic = new Dictionary<string, AudioClip>();
        public AudioClip LoadAudio(string audioPath,  bool cache = false)
        {
            AudioClip clip = null;
            if (!audioDic.TryGetValue(audioPath, out clip))
            {
                clip = Resources.Load<AudioClip>(audioPath);
                if (cache)
                {
                    audioDic.Add(audioPath, clip);
                }
            }
            return clip;
        }
    }
}
