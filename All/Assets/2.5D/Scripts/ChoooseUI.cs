using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ChoooseUI : MonoBehaviour {
    public GameObject leftBtn;
    public GameObject rightBtn;
    public Transform Custoum;
    public Transform first;
    public Transform end;
    public Button quitBtn;

    public Button firstLevel;
    public Button secondLevel;

    public Image twinkle1;
    public Image twinkle2;
    public Image twinkle3;
    public Sprite twinkleYellow;
    public Image level1Image;
    public Image level2Image;
    public Sprite level1ColorSprite;
    public Sprite level2ColorSprite;
	void Start () {
        if (PlayerPrefs.GetInt("is1") == 1)
        {
            twinkle1.sprite = twinkleYellow;
            level1Image.sprite = level1ColorSprite;
        }
        if (PlayerPrefs.GetInt("is2") == 1)
        {
            twinkle2.sprite = twinkleYellow;
            level2Image.sprite = level2ColorSprite;
        }
        if (PlayerPrefs.GetInt("is3") == 1)
        {
            twinkle3.sprite = twinkleYellow;
        }
        firstLevel.onClick.AddListener(ClickLevel1);
        secondLevel.onClick.AddListener(ClickLevel2);
        quitBtn.onClick.AddListener(ClickQuitBtn);
        leftBtn.GetComponent<Button>().onClick.AddListener(ClickLeft);
        rightBtn.GetComponent<Button>().onClick.AddListener(ClickRight);
    }
	
	void Update () {
		
	}

    void ClickLeft()
    {
        if (first.transform.position.x != 960)
        {
            leftBtn.GetComponent<Image>().raycastTarget = false;
            Custoum.DOLocalMove(new Vector3(Custoum.localPosition.x + 495, Custoum.localPosition.y, Custoum.localPosition.z), 0.3f).onComplete = delegate () {
                leftBtn.GetComponent<Image>().raycastTarget = true;
            };
        }
    }

    void ClickRight()
    {
        if (end.transform.position.x != 965)
        {
            rightBtn.GetComponent<Image>().raycastTarget = false;
            Custoum.DOLocalMove(new Vector3(Custoum.localPosition.x - 495, Custoum.localPosition.y, Custoum.localPosition.z), 0.3f).onComplete = delegate () {
                rightBtn.GetComponent<Image>().raycastTarget = true;
            };
        }
    }

    void ClickLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    void ClickLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    void ClickQuitBtn()
    {
        SceneManager.LoadScene("start");
    }
}
