/****************************************************
    文件：IScoreService.cs
	作者：lenovo
    邮箱: 
    日期：2022/7/7 10:25:10
	功能：向服务器存取数据
*****************************************************/



using strange.extensions.dispatcher.eventdispatcher.api;

public interface IScoreSvc 
{

    /// <summary>
    /// 向服务器求分数
    /// </summary>
    /// <param name="url"></param>
    void ReqScore(string url);


    /// <summary>
    /// 收到服务器的分数,command调用不用返回值
    /// </summary>
    /// <returns></returns>
    void OnReceiveScore();


    /// <summary>
    /// 更新分数到服务器端
    /// </summary>
    /// <param name="url"></param>
    /// <param name="score"></param>
    void UpateScore(string url,int score);

     IEventDispatcher Dispatcher { get; set; }
}
