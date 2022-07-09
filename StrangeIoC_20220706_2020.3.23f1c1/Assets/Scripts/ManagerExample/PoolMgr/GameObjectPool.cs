/****************************************************
    文件：GameObjectPool.cs
	作者：lenovo
    邮箱: 
    日期：2022/7/9 12:55:23
	功能：资源池
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
 
namespace Demo02
{


    [Serializable]
    public class GameObjectPool
    {
        #region 字段
        [SerializeField]
        private string name;
        [SerializeField]
        private GameObject prefab;
        [SerializeField]
        private int maxCnt;
        private int curCnt;
        //
        [NonSerialized]
        List<GameObject> goLst=new List<GameObject>();
        #endregion

        #region 生命
        void Start()
        {
            
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