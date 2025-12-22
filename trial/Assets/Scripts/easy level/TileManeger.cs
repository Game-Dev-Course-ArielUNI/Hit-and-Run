using UnityEngine;

public class TileManeger : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float Zspawn=0;
    public float tilelength = 30;
    public int numberoftiles=5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            if (i == 0)
                spawnTile(0);
            else if (i == 14)
                spawnTile(8);
            else
                spawnTile(Random.Range(0, tilePrefabs.Length - 1));
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spawnTile(int tileIndex)
    {
        Instantiate(tilePrefabs[tileIndex], transform.forward * Zspawn, transform.rotation);
        Zspawn += tilelength;
    }
}
