/****************************************************
    文件：GameObjectPool.cs
	作者：lenovo
    邮箱: 
    日期：2022/7/9 12:55:23
	功能：存储所有Pool
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
 
namespace Framework
{


    public class GameObjectPoolLst:ScriptableObject
    {
        #region 字段

        //
       public List<GameObjectPool> poolLst;
        #endregion

    }
}