using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class CheckSort : MonoBehaviour
{
    public string assignedColor;
    public List<GameObject> allBoxes;
    public List<string> colorNames;
    public bool mousedOver = false;
    public AudioClip victorySound;
    public AudioClip failSound;
    public AudioSource audSource;
    public bool hasBwomped = false;

    // Update is called once per frame
    void Update()
    {
        allBoxes = GameObject.FindGameObjectsWithTag("Box").ToList();

        Debug.Log(allBoxes.Count);

        if (allBoxes.Count == 0)
        {
            SceneManager.LoadScene("win");
        }

        foreach(GameObject box in allBoxes)
        {
            string spriteName = box.GetComponent<SpriteRenderer>().sprite.name;
            if (spriteName == assignedColor && box.transform.position == transform.position)
            {
                audSource.PlayOneShot(victorySound);
                Destroy(box);
                hasBwomped = false;
            }
            else if (spriteName != assignedColor && box.transform.position == transform.position && !hasBwomped)
            {
                audSource.PlayOneShot(failSound);
                hasBwomped = true;
            }
        }
    }
}