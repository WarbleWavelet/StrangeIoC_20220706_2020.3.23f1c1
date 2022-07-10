/****************************************************
    文件：PoolMgr.cs
	作者：lenovo
    邮箱: 
    日期：2022/7/9 13:58:9
	功能：
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
 
namespace Framework
{
    public class PoolMgr : MonoBehaviour
    {
        #region 字段

        #region 单例
        private static PoolMgr _instance;



        public static PoolMgr Instance
        {
            get
            {
                if (_instance == null)
                { 
                    _instance= new PoolMgr();
                }
                return _instance;
            }

            set
            {
                _instance = value;
            }
        }

        internal void InitMgr()
        {
            Instance = this;
        }

        #endregion
        #endregion

        #region 生命
        /// <summary>
        /// 防止初始化卡，放在StrangeIOC的StartCommand
        /// </summary>
        public PoolMgr()
        {

        }



        void Start()
        {

        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                AudioSvc.Instance.PlayUIAudio(Framework.Constants.UIClickBtn);
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                LoadGameObject("Bullet");
            }
        }
        #endregion 

        #region 系统

        #endregion 

        #region 辅助
        public GameObject LoadGameObject(string poolName)
        {
            return ResSvc.Instance.LoadGameObjectByPool(poolName);
        }
        #endregion
    }
}