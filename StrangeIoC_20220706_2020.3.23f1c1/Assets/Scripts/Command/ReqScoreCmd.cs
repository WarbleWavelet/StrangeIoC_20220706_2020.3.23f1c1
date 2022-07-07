/****************************************************
    文件：ReqScoreCmd.cs
	作者：lenovo
    邮箱: 
    日期：2022/7/7 12:38:34
	功能：请求分数
*****************************************************/

using strange.extensions.command.api;
using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class ReqScoreCmd : Command
{
    [Inject]
    public IScoreService ScoreSvc { get; set; }


    public override void Execute()
    {
        ScoreSvc.ReqScore("网络地址");
    }


}
