using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject prefab;

    public float minX;
    public float maxX;

    public Sprite[] sprites;

    public float startTime;
    private float time;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(time <= 0) {
            spawnObject();
            time = startTime;
        }
        else {
            time -= Time.deltaTime;
        }
    }

    private void spawnObject() {
        GameObject newPrefab = Instantiate(prefab);
        newPrefab.transform.position = new Vector2(
            Random.Range(minX, maxX),
            transform.position.y
        );

        Sprite randomSprite = sprites[Random.Range(0, sprites.Length)];
        newPrefab.GetComponent<SpriteRenderer>().sprite = randomSprite;
    }
}
