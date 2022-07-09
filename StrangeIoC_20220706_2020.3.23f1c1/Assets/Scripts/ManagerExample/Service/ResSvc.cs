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
            InitAudioCfg(PathDefine.Res_SavePath_Audio);
            InitGameObjectPoolCfg(PathDefine.Res_GameObjectPoolCfg);
            Debug.Log("ResSvc Init...");
        }



        #region Audio
        private Dictionary<string, AudioClip> audioDic = new Dictionary<string, AudioClip>();
        private void InitAudioCfg(string path)
        {
           
            TextAsset ta= Resources.Load<TextAsset>(path); //不加后缀
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
            //int a = 1;//打断点
        }

       
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
        #endregion


        #region GameObjectPool
        private Dictionary<string, GameObjectPool> gameObjectPoolDic = new Dictionary<string, GameObjectPool>();
       // GameObjectPoolLst gameObjectPoolLst=new GameObjectPoolLst();

        private void InitGameObjectPoolCfg(string path)
        {

            GameObjectPoolLst lst = Resources.Load<GameObjectPoolLst>(path);
            foreach (GameObjectPool pool in lst.poolLst)
            {
                gameObjectPoolDic.Add(pool.GetName(),pool);
            }
        }

        /// <summary>
        /// Pool中Go一个
        /// </summary>
        /// <param name="poolName"></param>
        /// <returns></returns>
       public GameObject LoadGameObjectByPool(string poolName)
        {
            GameObjectPool pool = null;
            if (gameObjectPoolDic.TryGetValue(poolName, out pool))
            {
                return pool.GetInstance();                
            }
            return null;
        }
        #endregion

    }
}
