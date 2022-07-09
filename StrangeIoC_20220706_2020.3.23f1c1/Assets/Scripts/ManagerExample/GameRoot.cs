/****************************************************
    文件：GaeRoot.cs
	作者：lenovo
    邮箱: 
    日期：2022/7/9 10:55:25
	功能：
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
 
namespace Demo02
{
    public class GameRoot : MonoBehaviour
    {
        #region 字段
      public  AudioSvc audioSvc;
      public  ResSvc resSvc;
      public  PoolMgr poolMgr;
        public LocalizationMgr localizationMgr;
        #region 单例
        private static GameRoot _instance;

        public static GameRoot Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameRoot();
                }
                return _instance;
            }
        }
        #endregion

        #endregion

        #region 生命
        void Start()
      // public void Init()//交给StartCommand
        {
            audioSvc=GetComponent<AudioSvc>();
            resSvc=GetComponent<ResSvc>();
            poolMgr=GetComponent<PoolMgr>();
            localizationMgr=GetComponent<LocalizationMgr>();
            //
            resSvc.InitSvc();
            audioSvc.InitSvc();
            poolMgr.InitMgr();
            localizationMgr.Init();

        }
        
        void Update()
        {
            
        }
        #endregion 

        #region 系统

        #endregion 

        #region 辅助

        #endregion
    }
}