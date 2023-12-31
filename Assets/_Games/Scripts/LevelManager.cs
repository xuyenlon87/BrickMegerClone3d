using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int currentMap = 0;
    private static LevelManager instance;
    public static LevelManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<LevelManager>();
            }
            return instance;
        }
    }
    [SerializeField] List<TextAsset> testMap = new List<TextAsset>();
    [SerializeField] GameObject brickPrefabGreen;
    [SerializeField] GameObject brickPrefabBlack;
    [SerializeField] GameObject brickPrefabRed;
    [SerializeField] GameObject brickPrefab;
    [SerializeField] GameObject player;

    public List<GameObject> listBrickDelete = new List<GameObject>();
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DrawMap()
    {
        if(listBrickDelete != null)
        {
            foreach (var i in listBrickDelete)
            {
                Destroy(i);
            }
            listBrickDelete.Clear();
        }
        if (currentMap >= 0 && currentMap < testMap.Count)
        {
            string data = testMap[currentMap].text;
            Debug.Log(currentMap);
            string[] dataArray = data.Split("\r\n");
            int row = dataArray.Length;
            int col = dataArray[0].Split(",").Length;
            int[,] map = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                if (dataArray.Length > 0)
                {
                    string[] dataArray2 = dataArray[i].Split(",");
                    for (int j = 0; j < dataArray2.Length; j++)
                    {
                        map[i, j] = int.Parse(dataArray2[j]);
                        if (map[i, j] == 2)
                        {
                            GameObject brick = Instantiate(brickPrefabGreen, new Vector3(j, 0, -i), Quaternion.identity);
                            listBrickDelete.Add(brick);
                        }
                        else if (map[i, j] == 1)
                        {
                            GameObject brickStart = Instantiate(brickPrefabBlack, new Vector3(j, 0, -i), Quaternion.identity);
                            listBrickDelete.Add(brickStart);
                            player.transform.position = brickStart.transform.position + Vector3.up;
                        }
                        else if (map[i, j] == 3)
                        {
                            GameObject brick = Instantiate(brickPrefabRed, new Vector3(j, 0, -i), Quaternion.identity);
                            listBrickDelete.Add(brick);
                        }
                        else if (map[i, j] == 0)
                        {
                            GameObject brick = Instantiate(brickPrefab, new Vector3(j, 0, -i), Quaternion.identity);
                            listBrickDelete.Add(brick);
                        }
                    }
                }
            }
        }
    }
}
