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
        //
        [NonSerialized]
        List<GameObject> goLst = new List<GameObject>();
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
        public string GetName()
        {
            return name;
        }

        public GameObject GetInstance()
        {
            //初始化
            if (goLst.Count < maxCnt)
            {
                goLst.Clear();
                for (int i = 0; i < maxCnt; i++)
                {
                    GameObject go = GameObject.Instantiate(prefab);
                    go.SetActive(false);
                    goLst.Add(go);
                }
            }
            //有
            foreach (GameObject go in goLst)
            {
                if (go.activeInHierarchy == false)
                {
                    go.SetActive(true);
                    return go;
                }
            }
            //没有清库存
            if (goLst.Count >= maxCnt)
            {
                GameObject.Destroy(goLst[0]);
                goLst.RemoveAt(0);
            }
            //加
            GameObject newGo = GameObject.Instantiate(prefab);
            goLst.Add(newGo);
            return newGo;
        }
        #endregion
    }
}