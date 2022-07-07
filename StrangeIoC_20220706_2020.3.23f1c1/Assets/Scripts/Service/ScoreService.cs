/****************************************************
    文件：ScoreService.cs
	作者：lenovo
    邮箱: 
    日期：2022/7/7 10:29:58
	功能：
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class ScoreService : IScoreService
{
    public void ReqScore(string url)
    {
       Debug.Log("url "+url + " Req Score:" );
    }


    public void OnReceiveScore()
    {
        int score= Random.Range(0, 100);
    }



    public void UpateScore(string url, int score)
    {
        Debug.Log("url " + url + " Update Score:"+ score);
    }

}
