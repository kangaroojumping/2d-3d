using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    protected Color color = Color.green; //to be replaced with textures
    public Color getColor() { return color; }
    protected Texture2D texture; //unused rn bc im lazy
    public BoxCollider boxCollider;
    public Map map;
    public Vector3 loc;


    public virtual void Start()
    {
        Destroy(GetComponent<Collider>());
        boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.size = new Vector3(1, 1, 1);
        //boxCollider.transform.localPosition = transform.localPosition; 
        //boxCollider.center = Vector3.zero;
    }


    void Update()
    {
        
    }

    public void click()
    {
        //Debug.Log("Clicked " + gameObject.name);
        map.player.transform.position = loc + map.offset();
    }
}
