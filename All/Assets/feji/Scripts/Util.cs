using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Util : MonoBehaviour
{
    public GameObject asteriodExplosion;
    public GameObject enemyExplosion;
    public GameObject playerExplosion;
    public GameObject asteroid;
    public GameObject enemy;
    public GameObject background;
    public GameObject player;
    public bool isPlaying;
    public int score;

    private GameObject restartCluster;
    private Button restartButton;

    private void RestartGame()
    {
        Debug.Log("Restart Game");
        DestroyObjects(FindObjectsOfType<EnemyShipController>());
        DestroyObjects(FindObjectsOfType<EnemyShotController>());
        DestroyObjects(FindObjectsOfType<RandomRotator>());
        DestroyObjects(FindObjectsOfType<Mover>());
        restartCluster.SetActive(false);
        Instantiate(player);
        score = 0;
        isPlaying = true;
    }

    private void Start()
    {
        isPlaying = true;
        restartButton = GameObject.Find("UI/Restart Cluster/Restart Button").GetComponent<Button>();
        restartCluster = GameObject.Find("UI/Restart Cluster");
        restartCluster.SetActive(false);
        restartButton.onClick.AddListener(RestartGame);
    }

    private void Update()
    {
        GameObject.Find("UI/Score Text").GetComponent<Text>().text = "Score: " + score;
    }

    public void GameOver()
    {
        Invoke("ShowGameOver", 1.0f);
        isPlaying = false;
    }

    private void ShowGameOver()
    {
        Debug.Log("ShowGameOver");
        restartCluster.SetActive(true);
    }

    public static Util GetUtil()
    {
        return FindObjectOfType<Util>();
    }

    private static void DestroyObjects(Object[] objects)
    {
        foreach (MonoBehaviour monoBehaviour in objects)
        {
            Destroy(monoBehaviour.gameObject);
        }
    }
}
