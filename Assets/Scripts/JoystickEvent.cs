using UnityEngine;
using System.Collections;

/// <summary>
/// Joystick event
/// </summary>
public class JoystickEvent : MonoBehaviour {
    CharacterController controller;
    private Animation animation;
	void OnEnable(){
		EasyJoystick.On_JoystickMove += On_JoystickMove;
        EasyJoystick.On_JoystickMoveEnd += On_JoystickMoveEnd;
        controller = GetComponent<CharacterController>();
        animation = GetComponent<Animation>();
	}
	
	void OnDisable(){
		EasyJoystick.On_JoystickMove -= On_JoystickMove	;
		EasyJoystick.On_JoystickMoveEnd -= On_JoystickMoveEnd;
	}
		
	void OnDestroy(){
		EasyJoystick.On_JoystickMove -= On_JoystickMove;	
		EasyJoystick.On_JoystickMoveEnd -= On_JoystickMoveEnd;
	}
	
	
	void On_JoystickMoveEnd(MovingJoystick move){
		if (move.joystickName == "Move_Turn_Joystick"){
			animation.CrossFade("idle");
		}
	}
	void On_JoystickMove( MovingJoystick move){
		
		
		if (move.joystickName == "Move_Turn_Joystick"){
			
			//
			if ((move.joystickAxis.y)>0 && (move.joystickAxis.y)<0.5){
                PlayAnimation("walk");
				//animation.CrossFade("walk");
                //transform.Translate(0f, 0.0f, 0.02f * move.joystickAxis.y);
                //GetComponent<Rigidbody>().AddForce(0f, 0f, 1f);
                //controller.Move(new Vector3(0f, 0f, 1f * Time.deltaTime));

			}	
			else if ((move.joystickAxis.y)>=0.5){
                //animation.CrossFade("run");
                PlayAnimation("run");	
                //transform.Translate(0f, 0.0f, 0.05f * move.joystickAxis.y);
                //GetComponent<Rigidbody>().AddForce(0f, 0f, 5f);
                //controller.Move(new Vector3(0f, 0f, 3 * Time.deltaTime));
			}
            else if (move.joystickAxis.y < 0f)
                PlayAnimation("walk", true);
            else
            {
                PlayAnimation("idle");;
            }
		}
	}

    void PlayAnimation(string clip, bool reverse = false)
    {
        animation[clip].speed = reverse ? -1 : 1;
        //animation[clip].time = animation[clip].length;
        animation.CrossFade(clip);
    }

}
