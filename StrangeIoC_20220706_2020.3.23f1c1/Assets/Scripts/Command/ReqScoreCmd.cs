/****************************************************
    文件：ReqScoreCmd.cs
	作者：lenovo
    邮箱: 
    日期：2022/7/7 12:38:34
	功能：请求分数（）
*****************************************************/

using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Demo01
{ 
public class ReqScoreCmd : EventCommand//多了全局的Disphter和IEvent
{
    [Inject]
    public IScoreSvc ScoreSvc { get; set; }
    [Inject]
    public ScoreModel ScoreModel { get; set; }//保存

    public override void Execute()
    {
         Debug.Log("Execute");
        Retain();//异步时间长，可能被销毁，需要保存
        ScoreSvc.Dispatcher.AddListener( CmdEvent.ReqScore, OnComplete );
        ScoreSvc.ReqScore("网络地址");
    }



        #region 辅助
        /// <summary>
        /// Execute结束后
        /// </summary>

       private void OnComplete(IEvent evt)
        {
            Debug.Log("OnComplete_" + evt.data);

            //
            //
            this.ScoreModel.Score = (int)evt.data;
            dispatcher.Dispatch(MediatorEvent.ScoreChange, evt.data);
            // 
            this.ScoreSvc.Dispatcher.RemoveListener(CmdEvent.ReqScore, OnComplete);


            //
            Release();
        }
        #endregion



    }

}
