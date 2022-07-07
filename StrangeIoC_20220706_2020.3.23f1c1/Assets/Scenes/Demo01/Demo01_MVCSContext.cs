/****************************************************
    文件：NewBehaviourScript.cs
	作者：lenovo
    邮箱: 
    日期：2022/7/6 21:57:50
	功能：被ContextView调用
*****************************************************/

using strange.extensions.context.api;
using strange.extensions.context.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
 
namespace Demo01
{
    public class Demo01_MVCSContext : MVCSContext
    {
        #region 系统
        public Demo01_MVCSContext(MonoBehaviour view) : base(view)
        {
         
        }

        /// <summary>
        /// 绑定映射
        /// </summary>
        protected override void mapBindings()
        {

            BindModel();
            BindService();
            BindCommand();
            BindMediator();

            //枚举、字符串
            

            
        }
        #endregion


        private void BindModel()
        {
            injectionBinder.Bind<ScoreModel>().To<ScoreModel>().ToSingleton();//自身实例化
        }
        private void BindService()
        {
            injectionBinder.Bind<IScoreSvc>().To<ScoreSvc>().ToSingleton();//一个，单例
        }
        private void BindCommand()
        {
            commandBinder.Bind(ContextEvent.START).To<StartCmd>().Once();
            commandBinder.Bind(CmdEvent.ReqScore).To<ReqScoreCmd>().Once();
        }
        private void BindMediator()
        {
            mediationBinder.Bind<CubeView>().To<CubeMediator>();
        }

    }
}