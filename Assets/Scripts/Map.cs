using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public Transform player;

    public int sizeX = 8;
    public int sizeY = 8;

    private int resolution = 1; //1 rn bc im lazy
    private Texture2D mapTexture;

    Tile[][] tiles;

    void Start()
    {
        mapTexture = new Texture2D(sizeX * resolution, sizeY * resolution);
        generateGrassMap();
        GetComponent<MeshRenderer>().material.mainTexture = mapTexture;
    }


    void Update()
    {
        
    }

    public Vector3 offset() { return new Vector3(-(sizeX / 2) + .5f, 0, -(sizeY / 2) + .5f); }

    void generateGrassMap() { generateMapOfOneTileType<Grass>(); }

    void generateMapOfOneTileType<t>() where t : MonoBehaviour
    {
        transform.localScale = new Vector3(sizeX, .1f, sizeY);
        tiles = new Tile[sizeX][];
        for (int i = 0; i < sizeX; i++)
        {
            tiles[i] = new Tile[sizeY];
            for (int j = 0; j < sizeY; j++)
            {
                GameObject obj = new GameObject("[" + i + "," + j + "]");
                obj.transform.parent = transform;
                obj.AddComponent<t>();
                if (obj.GetComponent<Tile>() != null)
                {
                    Tile tile = obj.GetComponent<Tile>();
                    tile.map = this;
                    tile.loc = new Vector3(i, .1f, j);
                    obj.transform.position = new Vector3(i, 0, j) ;
                    obj.transform.position += offset();
                    mapTexture.SetPixel(i * resolution, j * resolution, tile.getColor());
                }
                else Debug.Log("Waht the fuc");
            }
        }
        mapTexture.Apply();
    }

}
