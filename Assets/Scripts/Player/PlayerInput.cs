using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }
    public bool JumpPressed { get; private set; }
    public float MouseX { get; private set; }
    
    void Update() 
    {
        //Read keyboard WASD/Arrow keys
        MoveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        
        //Read jump key
        JumpPressed = Input.GetButtonDown("Jump");
        
        //Read mouse movement 
        MouseX = Input.GetAxis("Mouse X");
        
        Debug.Log($"Horizontal: {Input.GetAxis("Horizontal")}, Vertical: {Input.GetAxis("Vertical")}");

        Debug.Log("PlayerInput Update running");
    }
    
    //Reset single-frame inputs
    void LateUpdate()
    {
        JumpPressed = false;
    }
}
