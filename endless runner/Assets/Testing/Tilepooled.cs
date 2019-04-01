using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilepooled : MonoBehaviour
{
    public List<GameObject> Tiles = new List<GameObject>();
    public List<Transform> TileSpawnPoints = new List<Transform>();
    public GameObject[] TilePrefab;
    public int tilecount = 10;
    int tilepoints;
    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        createtile(TilePrefab[0]);
        tilepoints = TileSpawnPoints.Count;
        coroutine = PlaceEnemy(2.0f);
       // StartCoroutine(coroutine);
        InvokeRepeating("placetile", 0.1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator PlaceEnemy(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            int nPos = Random.Range(0, tilepoints);
            Debug.Log("No of calls");
            tileat(nPos);
        }
    }

    void createtile(GameObject Tile)
    {
        for(int i =0;i<tilecount;i++)
        {
            GameObject tc = Instantiate(Tile, gameObject.transform.position, Quaternion.identity);
            tc.SetActive(false);
            Tiles.Add(tc);
        }
    }

   public void placetile()
    {
        int pos = Random.Range(0, tilepoints);
        tileat(pos);
    }

    public void tileat(int point)
    {
        int fromtile = (Tiles.Count - 1);
        var Gameobj = Tiles[fromtile];
        Tiles.RemoveAt(fromtile);
        Gameobj.transform.position = new Vector3(TileSpawnPoints[point].position.x, TileSpawnPoints[point].position.y, TileSpawnPoints[point].position.z);
        Gameobj.SetActive(true);
    }

    public void AddEnemies(GameObject Tile)
    {
        Tiles.Add(Tile);
    }
}
