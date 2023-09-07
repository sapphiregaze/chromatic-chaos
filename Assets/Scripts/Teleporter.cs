using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public List<Transform> teleporters;

    void Start()
	{
		teleporters = GameObject.FindGameObjectsWithTag("Teleport").Select(go => go.transform).ToList();
	}

    // Update is called once per frame
    void Update()
    {
        float positionDifference = Vector2.Distance(teleporters[1].position, transform.position);
        if (positionDifference < 1)
        {
            transform.position = teleporters[0].position;
            
            GetComponent<Rigidbody2D>().Sleep();
            GetComponent<Rigidbody2D>().SetRotation(0f);
            GetComponent<Rigidbody2D>().WakeUp();

            // Play error sound
        }
    }
}
