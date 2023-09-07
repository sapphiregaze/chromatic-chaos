using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SnapBehavior : MonoBehaviour
{
    public Vector2 targetPosition;
	public float minSnapDistance = 1f;
	public List<Transform> slots;
	
	void Start()
	{
		slots = GameObject.FindGameObjectsWithTag("Position").Select(go => go.transform).ToList();
	}

    // Update is called once per frame
    void Update()
    {
		float smallestDistance = minSnapDistance;
		
		foreach (Transform slot in slots)
		{
			float positionDifference = Vector2.Distance(slot.position, transform.position);
			if (transform.position.y > slot.position.y && positionDifference < smallestDistance)
			{
				transform.position = slot.position;
				smallestDistance = Vector2.Distance(slot.position, transform.position);
                GetComponent<Rigidbody2D>().Sleep();
                GetComponent<Rigidbody2D>().SetRotation(0f);

				// Check if in sorted slot, fall if not
				string spriteName = GetComponent<SpriteRenderer>().sprite.name;
				if (slot.GetComponent<CheckSort>().assignedColor != spriteName)
				{
					GetComponent<Rigidbody2D>().WakeUp();
				}
			}
		}
    }
}