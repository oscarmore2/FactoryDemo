using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInteraction
{

}

public interface IInputProvider {

    Vector3 OnTranlatingInput(); //移动
    Quaternion OnDirectionInput(); //转向
	//Debug.Log("nihao");
}
