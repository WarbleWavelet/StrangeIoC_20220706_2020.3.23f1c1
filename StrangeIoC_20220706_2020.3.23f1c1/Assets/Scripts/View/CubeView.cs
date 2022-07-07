/****************************************************
    文件：CubeView.cs
	作者：lenovo
    邮箱: 
    日期：2022/7/7 10:48:4
	功能：链接GameObject
*****************************************************/

using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


namespace Demo01
{ 
public class CubeView : View
{



    [SerializeField]
    Text txtScore;
    /// <summary>
    /// 初始化，Media中调用
    /// </summary>
    public void Init()
    {
        txtScore = transform.Find("Canvas/Text").GetComponent<Text>();
    }


    int score =0;
    public float timer = 0f;
    public float time = 1f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > time)
        {
            timer = 0f;
            //
            float x = Random.Range(-8f, 8f);
            float y = Random.Range(-4.5f, 4.5f);
            Vector3 v3 = new Vector3(x, y, 0f);
            x = v3.x;
            y = v3.y;
            if (x < -8f || x > 8f)
            {
                x = 0f;
            }

            if (y < -4.5f || y > 4.5f)
            {
                y = 0f;
            }
            transform.position = new Vector3(x, y, 0f);
        }
    }


    [Inject]//全局的
    public IEventDispatcher Dispatcher { get; set; }




    private void OnMouseDown()
    {

        //score++;
        //txtScore.text = score.ToString();
    }

    public void UpdateScore(int score)
    {
        score++;
        txtScore.text=score.ToString();
    }


}

}

