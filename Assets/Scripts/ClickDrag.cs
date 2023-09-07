using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDrag : MonoBehaviour
{
	private float startPosX;
	private float startPosY;
	private bool isBeingHeld = false;
	private Vector2 mousePos;
	
    // Update is called once per frame
    void Update()
    {
        if(isBeingHeld == true)
		{
			UpdateMousePos();
			
			this.gameObject.transform.localPosition = new Vector2(mousePos.x - startPosX, mousePos.y - startPosY);
			// Add snap function if need to drop box into certain position?
		}
    }
	
	private void UpdateMousePos()
	{
		mousePos = Input.mousePosition;
		mousePos = Camera.main.ScreenToWorldPoint(mousePos);
	}
	
	private void OnMouseDown()
	{
		if(Input.GetMouseButtonDown(0)){
			isBeingHeld = true;
			
			UpdateMousePos();
			
			startPosX = mousePos.x - this.transform.localPosition.x;
			startPosY = mousePos.y - this.transform.localPosition.y;
			GetComponent<Rigidbody2D>().WakeUp();
		}
	}
	
	private void OnMouseUp()
	{
		isBeingHeld = false;
		GetComponent<Rigidbody2D>().Sleep();
		GetComponent<Rigidbody2D>().WakeUp();
	}
}
