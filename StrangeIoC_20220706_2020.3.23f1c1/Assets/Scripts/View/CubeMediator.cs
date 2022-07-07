/****************************************************
    文件：CubeMediator.cs
	作者：lenovo
    邮箱: 
    日期：2022/7/7 12:10:17
	功能：处理CubeView与外部数据的交互。由MVCSContext进行绑定
*****************************************************/

using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class CubeMediator : Mediator
{
    #region 字段
    /// <summary>由MVCSContext进行绑定</summary>
    [Inject]//注入
    public CubeView CubeView { get; set; }//Demo01_MVCSContext

    /// <summary>模块之间的交互</summary>
   [Inject(ContextKeys.CONTEXT_DISPATCHER)]//全局的
    public IEventDispatcher Dispatcher { get; set; }
    #endregion

    #region 生命


    /// <summary>
    /// 完成所有Inject后
    /// </summary>

    public override void OnRegister()
    {
        base.OnRegister();
        Debug.Log("OnRegister "+ CubeView);
        //
        Dispatcher.Dispatch(Demo01.Demo01_CommandEvent.ReqScoreCmd);
    }


    /// <summary>
    /// Fires on removal of view.
    /// </summary>
    public override void OnRemove()
    {
        Debug.Log("OnRemove" );
    }

    #endregion

    #region 系统

    #endregion

    #region 辅助

    #endregion
}
