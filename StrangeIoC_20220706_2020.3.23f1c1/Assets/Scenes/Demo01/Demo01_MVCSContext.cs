/****************************************************
    文件：NewBehaviourScript.cs
	作者：lenovo
    邮箱: 
    日期：2022/7/6 21:57:50
	功能：被ContextView调用
*****************************************************/

using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
 
namespace Demo01
{
    public class Demo01_MVCSContext : MVCSContext
    {
        public Demo01_MVCSContext(MonoBehaviour view) : base(view)
        {
         
        }

        /// <summary>
        /// 绑定映射
        /// </summary>
        protected override void mapBindings()
        {
            base.mapBindings(); 
        }
    }
}