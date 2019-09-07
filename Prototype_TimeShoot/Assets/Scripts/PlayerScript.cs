using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public VariableJoystick joystick;
    public FixedButton JumpButton;
    public FixedTouchField touchfield;

    private void Update()
    {      
        var fps = GetComponent<RigidbodyFirstPersonController>();

        //set up joystick to control the player rigidbody
        fps.RunAxis.x = joystick.GetInputX();
        fps.RunAxis.y = joystick.GetInputY();

        fps.jump = JumpButton.Pressed;

        fps.mouseLook.LookAxis = touchfield.TouchDist;
    }

}
