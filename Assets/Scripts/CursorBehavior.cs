using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehavior : MonoBehaviour
{
    public Texture2D grabby;
    public Texture2D closeby;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 CursorOffset = new Vector2(grabby.width/2, grabby.height/2);
        Cursor.SetCursor(grabby, CursorOffset, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Vector2 CursorHeld = new Vector2(closeby.width/2, closeby.height/2);
            Cursor.SetCursor(closeby, CursorHeld, CursorMode.Auto);
        } else if (Input.GetMouseButtonUp(0)) {
            Vector2 CursorOffset = new Vector2(grabby.width/2, grabby.height/2);
            Cursor.SetCursor(grabby, CursorOffset, CursorMode.Auto);
        }
    }
}
