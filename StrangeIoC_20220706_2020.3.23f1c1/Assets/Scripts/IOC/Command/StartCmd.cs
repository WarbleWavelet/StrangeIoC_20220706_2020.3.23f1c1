/****************************************************
    文件：Command.cs
	作者：lenovo
    邮箱: 
    日期：2022/7/6 22:34:44
	功能：控制脚本
*****************************************************/

using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
 
namespace Demo01
{
    public class StartCmd : Command
    {
        /// <summary>
        /// 被调用时执行
        /// </summary>
        public override void Execute()
        {
            Debug.Log("Execute");
        }
    }
}