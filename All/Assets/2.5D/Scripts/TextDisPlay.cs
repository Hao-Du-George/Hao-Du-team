using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class TextDisPlay : MonoBehaviour {
    char[] cc;
    bool isGoing;
    public PlayMakerFSM PlayMaker;
    public player player;
    public GameObject bird;
    public GameObject text;
    public GameObject endPos;
    bool isFly = false;
    public Button quitBtn;
    private void Start()
    {
        quitBtn.onClick.AddListener(ClickQuit);
        PlayMaker.enabled = false;
        player.enabled = false;
        isGoing = true;
        text1 = GameObject.Find("TextDisplay").GetComponent<Text>();//找到用于显示的Text组件
    }

    void Update()
    {
        if (isFly == true)
        {
            bird.transform.position = Vector3.MoveTowards(bird.transform.position, endPos.transform.position, 3 * Time.deltaTime);
        }
        if (bird.transform.position == endPos.transform.position)
        {
            isFly = false;
            //Destroy(bird);
        }
        //循环播放文字
        if (isGoing)
        {
            isGoing = false;
            StartOne();
        }
    }

    private Text text1;//故事面板文字栏
    private string textTemp;//故事面板具体文字
    private void StartOne()
    {
        text1.text = "";
        textTemp = "miko，你看，这就是曾经拥有各种风光的地球。如今……哎，努力前行吧，收集碎片，看看曾经的地球多么美丽";
        cc = textTemp.ToCharArray();//将string类型里的每一个字转化成char集合
        StartCoroutine(TextOne());
    }

    IEnumerator TextOne()
    {
        bool isGo = true;
        while (isGo)
        {
            for (int i = 0; i < cc.Length; i++)
            {
                yield return new WaitForSeconds(0.07f);//每0.07秒产生一个文字
                text1.text += cc[i];
                if (i == cc.Length - 1)
                {
                    isGo = false;
                    PlayMaker.enabled = true;
                    player.enabled = true;
                    yield return new WaitForSeconds(1.5f);
                    Destroy(text);
                    isFly = true;
                }
            }
        }
    }

    void ClickQuit()
    {
        SceneManager.LoadScene("ChooseScene");
    }
}
