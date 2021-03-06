using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
    // 生成障碍物点列表
    public List<Transform> bornPosList = new List<Transform>();
    // 道路列表
    public List<Transform> roadList = new List<Transform>();
    // 抵达点列表
    public List<Transform> arrivePosList = new List<Transform>();
    // 障碍物列表
    public List<GameObject> objPrefabList = new List<GameObject>();
    // 目前的障碍物
    public List<Transform> goldList = new List<Transform>();
    // 道具
    public List<Transform> xinList = new List<Transform>();

    Dictionary<string, List<GameObject>> objDict = new Dictionary<string, List<GameObject>>();
    public int roadDistance;
    public bool isEnd = false;
	// Use this for initialization
	void Start () {
        foreach(Transform road in roadList)
        {
            List<GameObject> objList = new List<GameObject>();
            objDict.Add(road.name, objList);
        }
        initRoad(0);
        initRoad(1);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    // 切出新的道路
    public void changeRoad(Transform arrivePos)
    {
        int index = arrivePosList.IndexOf(arrivePos);
        if(index >= 0)
        {
            int lastIndex = index - 1;
            if (lastIndex < 0)
                lastIndex = roadList.Count - 1;
            // 移动道路
            roadList[index].position = roadList[lastIndex].position + new Vector3(roadDistance, 0, 0);

            initRoad(index);
        }
        else
        {
            Debug.LogError("arrivePos index is error");
            return;
        }
    }

    void initRoad(int index)
    {
        
        string roadName = roadList[index].name;
        // 清空已有障碍物
        foreach(GameObject obj in objDict[roadName])
        {
            Destroy(obj);
        }
        objDict[roadName].Clear();

        // 添加障碍物
        foreach(Transform pos in bornPosList[index])
        {
            GameObject prefab = objPrefabList[Random.Range(0, objPrefabList.Count)];
            Vector3 eulerAngle = new Vector3(0, Random.Range(0, 360), 0);
            GameObject obj = Instantiate(prefab, pos.position, Quaternion.EulerAngles(eulerAngle)) as GameObject;
            obj.tag = "Obstacle";
            objDict[roadName].Add(obj);
        }

        //添加金币
        foreach (Transform goldPos in goldList[index])
        {
            GameObject gold = Instantiate(Resources.Load("gold"),goldPos.position,Quaternion.identity) as GameObject;
        }

        foreach (Transform xinPos in xinList[index])
        {
            GameObject xin = Instantiate(Resources.Load("Xin"), xinPos.position, Quaternion.identity) as GameObject;
        }
    }
}
