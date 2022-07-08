/****************************************************
    文件：ResSvc.cs
	作者：lenovo
    邮箱: 
    日期：2022/7/8 16:27:0
	功能：资源服务
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum ResType
{ 
Audio,
}
public class ResSvc : EditorWindow
{
    public static ResSvc Instance;

    /// <summary>
    /// 初始化服务
    /// </summary>
    public void InitSvc()
    {
        Instance = this;

        
        //

        //
        Debug.Log("ResSvc Init");
    }









    #region Audio
    Dictionary<string, AudioClip> audioDic = new Dictionary<string, AudioClip>();
    /// <summary>
    /// 加载声音
    /// </summary>
    /// <param name="path"></param>
    /// <param name="cache">缓存不？</param>
    /// <returns></returns>

    public AudioClip LoadAudio(string path, bool cache = false)
    {
        AudioClip au = null;
        if (audioDic.TryGetValue(  path, out au) == false)
        {
            au = Resources.Load<AudioClip>(path);
            if (cache)
            {
                audioDic.Add(path, au);
            }
        }

        return au;
    }

    public bool ContainKey(ResType type,string key)
    {
        bool isContain = false;
        switch (type)
        {
            case ResType.Audio :
                {
                   isContain= audioDic.ContainsKey(key);
                }
                break;
            default:
                {

                }
                break;
        }
        return isContain;
    }

    #endregion


    #region Sprite
    Dictionary<string, Sprite> spDict = new Dictionary<string, Sprite>();
    /// <summary>
    /// 加载图片
    /// </summary>
    /// <param name="path"></param>
    /// <param name="cache">缓存不？</param>
    /// <returns></returns>

    public Sprite LoadSprite(string path, bool cache = false)
    {
        Sprite sp = null;
        if (spDict.TryGetValue(path, out sp) == false)
        {
           sp = Resources.Load<Sprite>(path);
            if (cache)
            {
                spDict.Add(path, sp);
            }
        }

        return sp;
    }
    #endregion








    #region Common
    /// <summary>
    /// 字符串数组转Vector3
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    Vector3 XmlElement_ToVector3(XmlElement e)
    {
        string[] valArr = e.InnerText.Split(',');
        return new Vector3(float.Parse(valArr[0]), float.Parse(valArr[1]), float.Parse(valArr[2]));
    }


    List<string> String_SplitToStringLst(string text, char split)
    {
        string[] arr = text.Split(split);
        List<string> lst = new List<string>();
        //
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == "")
            {
                continue;
            }
            lst.Add(arr[i]);
        }
        return lst;
    }


    /// <summary>
    /// 将字符串根据分隔符转为数组
    /// </summary>
    /// <param name="text"></param>
    /// <param name="split"></param>
    /// <returns></returns>
    List<int> String_ToIntList(string text, char split)
    {
        string[] arr = text.Split(split);
        List<int> lst = new List<int>();
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == "")
            {
                continue;

            }
            lst.Add( int.Parse(arr[i]) );
        }

        return lst;
    }
    #endregion
}

#region 强化
public enum PosType
{
    Head,
    Body,
    Waist,
    Hands,
    Leg,
    Feet
}

public enum PropType
{
    Hurt,
    Hp,
    Def,
}
#endregion
