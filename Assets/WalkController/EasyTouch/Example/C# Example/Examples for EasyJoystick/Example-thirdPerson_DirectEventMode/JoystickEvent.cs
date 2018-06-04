using UnityEngine;
using System.Collections;

/// <summary>
/// Joystick event
/// </summary>
public class JoystickEvent : MonoBehaviour {

	void OnEnable(){
		EasyJoystick.On_JoystickMove += On_JoystickMove;
		EasyJoystick.On_JoystickMoveEnd += On_JoystickMoveEnd;
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
			GetComponent<Animation>().CrossFade("idle");
		}
	}
	void On_JoystickMove( MovingJoystick move){
		
		
		if (move.joystickName == "Move_Turn_Joystick"){
			
			//
			if ((move.joystickAxis.y)>0 && (move.joystickAxis.y)<0.5){
				GetComponent<Animation>().CrossFade("walk");
                transform.Translate(0f, 0.0f, 0.001f * move.joystickAxis.y);
			}	
			else if ((move.joystickAxis.y)>=0.5){
				GetComponent<Animation>().CrossFade("run");	
                transform.Translate(0f, 0.0f, 0.01f * move.joystickAxis.y);
			}
            else
            {
                GetComponent<Animation>().CrossFade("idle");
            }
		}
	}

}
