/****************************************************
    文件：ScoreService.cs
	作者：lenovo
    邮箱: 
    日期：2022/7/7 10:29:58
	功能：
*****************************************************/

using strange.extensions.dispatcher.eventdispatcher.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public  class ScoreSvc : IScoreSvc
{
    [Inject]
    public IEventDispatcher Dispatcher { get ; set ; }

    public  void ReqScore(string url)
    {
        string msg = "";
        msg += "url_" + url;
        msg += " ReqScore_?";
       Debug.Log( msg );
        //
        OnReceiveScore();//强行调用模拟

    }


    public void OnReceiveScore()
    {
        Debug.Log("OnReceiveScore");
        int score= Random.Range(0, 100);
        Dispatcher.Dispatch(Demo01.CmdEvent.ReqScore, score);
    }



    public void UpateScore(string url, int score)
    {
        Debug.Log("url " + url + " Update Score:"+ score);
    }

}
