using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class player : MonoBehaviour {
    public AudioSource eat;
    public AudioSource winAudio;
    public AudioSource defeatAudio;
    public GameObject shootPos;
    bool ishoot = false;
    Animator animator;
    GameObject cameraMain;
    Vector3 distance;
    bool isGo = true;
    public Slider sliderPower;
    public GameObject DefeatW;
    public GameObject Winw;
    public Button returnD;
    public Button returnW;
    private int powerNum;
    private CharacterController cc;
    private bool isJump;
    private bool isMove;
    private Vector3 moveDirection;
    private CollisionFlags flags;
    public GameObject bear;
    public int levelC;
    int level = 1;
    void Start () {
        returnD.onClick.AddListener(ClickReturn);
        returnW.onClick.AddListener(ClickReturn);
        powerNum = PlayerPrefs.GetInt("powerNum");
        cameraMain = GameObject.Find("Main Camera");
        distance = cameraMain.transform.position - transform.position;
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        if (levelC == 3)
        {
            sliderPower.value = sliderPower.maxValue;
        }
    }

    void LateUpdate()
    {
        if (isGo == true)
        {
            cameraMain.transform.position = Vector3.Lerp(cameraMain.transform.position, transform.position + distance, Time.deltaTime * 5);
        }

    }

    void Update () {
        if (levelC == 3)
        {
            ishoot = true;
        }
        else
        {
            ishoot = false;
        }
        if (sliderPower.value == sliderPower.maxValue && PlayerPrefs.GetInt("is1") + PlayerPrefs.GetInt("is2") == 2 && levelC == 2)
        {
            bear.SetActive(true);
        }
        if (levelC != 3)
        {
            sliderPower.value = powerNum;
        }
        
        switch (levelC)
        {
            case 1:
                if (transform.position.x >= 795 && transform.position.x <= 814f)
                {
                    isGo = true;
                }
                else
                {
                    isGo = false;
                }
                break;
            case 2:
                if (transform.position.x >= 795 && transform.position.x <= 836.5f)
                {
                    isGo = true;
                }
                else
                {
                    isGo = false;
                }
                break;
            case 3:
                if (transform.position.x >= 795 && transform.position.x <= 813.2f)
                {
                    isGo = true;
                }
                else
                {
                    isGo = false;
                }
                break;
            default:
                break;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = new Quaternion(0, -0.7f, 0, 0.7f);
            animator.SetBool("Walk", true);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = new Quaternion(0, 0.7f, 0, 0.7f);
            animator.SetBool("Walk", true);
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("Walk", false);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            if (ishoot == true)
            {
                animator.SetTrigger("Melee Left Attack 01");
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            animator.SetTrigger("Jump");
            isJump = true;
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection.y = 15;
        }
        if (isJump)
        {
            //模拟物理,开始下降
            moveDirection.y -= 22 * Time.deltaTime;
            flags = cc.Move(moveDirection * Time.deltaTime);

            //人物碰撞到下面了
            if (flags == CollisionFlags.Below)
            {
                isJump = false;
            }
        }
    }

    void StopJump()
    {
        animator.SetBool("isjump", false);
    }
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "gem")
        {
            eat.Play();
            Destroy(collider.gameObject);
            // TODO 能量条，分数
            powerNum += 10;
            PlayerPrefs.SetInt("powerNum", powerNum);
        }

        if (collider.tag == "bigGem" && levelC == 1)
        {
            //通关，回主菜单
            eat.Play();
            winAudio.Play();
            Winw.transform.DOScale(1, 0.3f);
            PlayerPrefs.SetInt("is1", 1);
        }

        if (collider.tag == "bigGem" && levelC == 2)
        {
            //通关，回主菜单
            eat.Play();
            PlayerPrefs.SetInt("is2", 1);
            Destroy(collider.gameObject);
        }

        if (collider.tag == "bigGem" && levelC == 3)
        {
            //eat.Play();
            PlayerPrefs.SetInt("is3", 1);
            winAudio.Play();
            Winw.transform.DOScale(1, 0.3f);
        }

        if (collider.tag == "Finish")
        {
            //失败回主菜单
            DefeatW.transform.DOScale(1, 0.3f);
            defeatAudio.Play();
        }
        if (collider.tag == "bear")
        {
            SceneManager.LoadScene("Level3");
        }
    }

    void ClickReturn()
    {
        SceneManager.LoadScene("ChooseScene");
    }

    void AttackC()
    {
        GameObject go = Instantiate(Resources.Load("Diamond"),shootPos.transform.position,Quaternion.identity)as GameObject;
    }
}
