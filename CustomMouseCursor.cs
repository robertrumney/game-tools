using UnityEngine;

public class CustomMouseCursor : MonoBehaviour
{
    // Declare public variables
    public Texture2D cursorTexture;
    public Texture2D selectTexture;

    public CursorMode cursorMode = CursorMode.Auto; // cursor mode
    public Vector2 hotSpot = Vector2.zero; // cursor hot spot

    // Declare static instance variable
    public static CustomMouseCursor instance;

    // Declare private variables
    private bool pointing = false;
    private bool secondaryPointing = false;

    // Awake function is called when the script instance is being loaded
    private void Awake()
    {
        // Set the static instance variable
        instance = this;
    }

    // Start function is called on the frame when a script is enabled just before any of the Update methods are called the first time
    private void Start()
    {
        // Set the default cursor texture and set pointing to false
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        pointing = false;
    }

    // MouseEnter function is called when the mouse pointer enters a GUIElement or Collider
    public void MouseEnter()
    {
        // Set the cursor texture to selectTexture and set pointing to true
        Cursor.SetCursor(selectTexture, hotSpot, cursorMode);
        pointing = true;
    }

    // SecondaryMouseExit function is called when the mouse pointer exits a secondary clickable object
    public void SecondaryMouseExit()
    {
        // If the mouse is not pointing at any clickable object, set the cursor texture to default cursor texture
        if (!pointing)
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    // MouseExit function is called when the mouse pointer exits a GUIElement or Collider
    public void MouseExit()
    {
        // Call the Start function to set the cursor texture to default cursor texture and set pointing to false
        Start();
    }
}
