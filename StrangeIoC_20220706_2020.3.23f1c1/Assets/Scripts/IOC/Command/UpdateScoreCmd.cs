/****************************************************
    文件：UpdateScoreCmd.cs
	作者：lenovo
    邮箱: 
    日期：2022/7/8 13:59:53
	功能：
*****************************************************/

using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
 
namespace Demo01
{



    public class UpdateScoreCmd :EventCommand//用到Disphter
    {  
        [Inject]
        public ScoreModel ScoreModel { get; set; }
        [Inject]
        public IScoreSvc ScoreSvc { get; set; }
        public override void Execute()
        {
            Debug.Log("Execute");
            //Retain();//异步时间长，可能被销毁，需要保存
            ScoreModel.Score++;
            ScoreSvc.UpateScore(Constants.IPAddress,ScoreModel.Score);
            dispatcher.Dispatch(MediatorEvent.ScoreChange, ScoreModel.Score);//Mediator监听了ScoreChange
        }
    }
}