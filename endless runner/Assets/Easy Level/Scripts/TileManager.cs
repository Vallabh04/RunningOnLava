using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {
    public GameObject[] tileprefabs;
    public Transform playertransform;
    private float spawnZ = 0.0f;
    private float safezone = 50.0f;
    private float titlelength = 50;
    private int amtoftitonscr = 12;
    private int lastprefabindex = 0;
   
    private List<GameObject> activetiles;


	void Start () {
        activetiles = new List<GameObject>();
        playertransform = GameObject.FindGameObjectWithTag("Player").transform;
        for(int i =0;i<amtoftitonscr;i++)
        {
            if(i<2)
            {
                SpawnTiles(0);
            }
            else
            SpawnTiles();
            
        }
    }

	
	void Update () {
    if (playertransform.position.z - safezone > (spawnZ - amtoftitonscr * titlelength))
    {
        SpawnTiles();
          //  GameObject range = Instantiate(prefab, playertransform.transform.localPosition + new Vector3(0, 0, 15), Quaternion.identity) as GameObject;
            deletetile();
    }
    }
    private void SpawnTiles(int prefabindex = -1)
    {
        GameObject go;
        if (prefabindex == -1)
            go = Instantiate(tileprefabs[RandomIndexPrefab()]) as GameObject;
        else
            go = Instantiate(tileprefabs[prefabindex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += titlelength;
        activetiles.Add(go);
    }
    private void deletetile()
    {
        Destroy(activetiles[0]);
        activetiles.RemoveAt(0);
    }

    

    private int RandomIndexPrefab()
    {
        if (tileprefabs.Length <= 1)
            return 0;
        int randomindex = lastprefabindex;
        while (randomindex == lastprefabindex)
        {
            randomindex = Random.Range(0, tileprefabs.Length);

        }
        lastprefabindex = randomindex;
        return randomindex;
    }

}
