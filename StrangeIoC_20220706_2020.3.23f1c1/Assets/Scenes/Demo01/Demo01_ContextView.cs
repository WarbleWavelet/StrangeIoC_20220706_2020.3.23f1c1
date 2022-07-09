/****************************************************
    文件：NewBehaviourScript.cs
	作者：lenovo
    邮箱: 
    日期：2022/7/6 21:57:50
	功能：相当于GameRoot
*****************************************************/
using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
 
namespace Demo01
{
    public class Demo01_ContextView : ContextView
    {
        //启动MVCSContext
        #region 字段


        #endregion

        #region 生命
        public void Awake()
        {
            this.context = new Demo01_MVCSContext(this);
        }
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