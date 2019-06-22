using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWall : MonoBehaviour
{

    public List<Sprite> walls = new List<Sprite>();

    // Start is called before the first frame update
    void Start()
    {
        int wallNumber = Random.Range(0, 5);
        SpriteRenderer spriteRen = gameObject.GetComponent<SpriteRenderer>();
        spriteRen.sprite = walls[wallNumber];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
