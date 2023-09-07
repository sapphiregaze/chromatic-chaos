using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBoxes : MonoBehaviour
{
    public int NUM_BOXES = 7;
    public GameObject boxPrototype;
    public Sprite[] sprites;

    void Start()
    {
        RandomizeSpriteOrder();
        StartCoroutine(spawnBoxes());
         
    }

    IEnumerator spawnBoxes()
    {
        for(int i = 0; i < NUM_BOXES; i++)
        {
            var box = Instantiate(boxPrototype);
            box.GetComponent<SpriteRenderer>().sprite = sprites[i % sprites.Length];
            box.transform.position = this.gameObject.transform.position;
            yield return new WaitForSeconds(1f);
        }
    }

    void RandomizeSpriteOrder()
    {
        for(int i = 0; i < sprites.Length; i++) {
            int randomIndex = Random.Range(i, sprites.Length);
            Sprite temp = sprites[i];
            sprites[i] = sprites[randomIndex];
            sprites[randomIndex] = temp;
        }
    }
}