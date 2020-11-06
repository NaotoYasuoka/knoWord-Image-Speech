using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using HtmlAgilityPack;

public class WordToURL : MonoBehaviour
{

    public IEnumerator getHTML(string key_word)
    {
        Debug.Log("開始");
        // リクエストのURL文を作成
        string URL = "https://www.google.co.jp/search?q=" + key_word + "&tbm=isch&ved=2ahUKEwibvOTL3ufsAhWmzIsBHRqnBdMQ2-cCegQIABAA&oq=" + key_word + "&gs_lcp=CgNpbWcQAzIECAAQHjIECAAQHjIECAAQHjIECAAQHjIECAAQHjIECAAQHjIECAAQHjIECAAQHjIECAAQHjIECAAQHjoECCMQJzoFCAAQsQM6AggAOgQIABAEOgcIIxDqAhAnOgcIABCxAxAEOggIABCxAxCDAToECAAQEzoGCAAQHhATUICQGFiJzRhgz88YaANwAHgAgAHLAYgB4Q6SAQYwLjEzLjGYAQCgAQGqAQtnd3Mtd2l6LWltZ7ABCsABAQ&sclient=img&ei=_gOiX5vFOqaZr7wPms6WmA0&bih=977&biw=1858&hl=ja";
        // リクエストを作成
        var www = UnityWebRequest.Get(URL);
        // リクエストを出して返答を待機
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            // エラーが起きた場合はエラー内容を表示
            Debug.LogError(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            //  または、結果をバイナリデータとして取得します
            byte[] results = www.downloadHandler.data;
            string HTML = www.downloadHandler.text;
            Debug.Log(HTML);
            getImageURL(HTML);
            Debug.Log("終了");
        }
    }

    public void getImageURL(string htmlText)
    {
        string key_word = "bag";
        string URL = "https://www.google.co.jp/search?q=" + key_word + "&tbm=isch&ved=2ahUKEwibvOTL3ufsAhWmzIsBHRqnBdMQ2-cCegQIABAA&oq=" + key_word + "&gs_lcp=CgNpbWcQAzIECAAQHjIECAAQHjIECAAQHjIECAAQHjIECAAQHjIECAAQHjIECAAQHjIECAAQHjIECAAQHjIECAAQHjoECCMQJzoFCAAQsQM6AggAOgQIABAEOgcIIxDqAhAnOgcIABCxAxAEOggIABCxAxCDAToECAAQEzoGCAAQHhATUICQGFiJzRhgz88YaANwAHgAgAHLAYgB4Q6SAQYwLjEzLjGYAQCgAQGqAQtnd3Mtd2l6LWltZ7ABCsABAQ&sclient=img&ei=_gOiX5vFOqaZr7wPms6WmA0&bih=977&biw=1858&hl=ja";
        System.Net.WebClient web = new System.Net.WebClient();
        string html = web.DownloadString(URL);
        Debug.Log(html);


        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        doc.LoadHtml(htmlText);


        HtmlNodeCollection nodes =
            doc.DocumentNode
            .SelectNodes("html//body//div[3]//table[1]//tr[1]//td[1]//div[1]//div[1]//div[1]//div[1]//table[1]//tr[1]//td[1]//a[1]//div[1]//img");

        //var htmlDoc = new HtmlAgilityPack.HtmlDocument();
        //htmlDoc.LoadHtml(htmlText);

        //foreach (HtmlNode node in nodes)
        //{
        //    string url = node.GetAttributeValue("src", "");
        //    Debug.Log("なんかな："+url);
        //}

        string urls = nodes[0].GetAttributeValue("src", "");
        Debug.Log(urls);
        //string links = nodes.InnerHtml;
        //var articles =
        //htmlDoc.DocumentNode
        //.SelectNodes("/html/body/div[1]/table[1]/tr[1]/td[1]/div[1]/div[1]");
        //.SelectNodes(@"//div[@class='T1diZc KWE8qe']//c-wiz[@class='P3Xfjc SSPGKf BIdYQ']//div[@class='mJxzWe']//div[@class='OcgH4b']//div//div//div[@class='tmS4cc']//div[@class='gBPM8']//div[@id='islrg']//div[@class='islrc']//div[1]//a[@class='wXeWr islib nfEiy mM5pbd']//div[@class='bRMDJf islir']//img[1]");
        //Debug.Log(links);
    }
}