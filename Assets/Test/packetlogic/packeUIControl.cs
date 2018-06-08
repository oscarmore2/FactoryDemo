using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class packeUIControl : MonoSingleton<packeUIControl> {

	// Use this for initialization
	void Start () {
		
	}
    public GameObject pickedElementOrigin;
    public Transform pickedElementParentTrans;
    public void AddPickedElementUI(ItemInfo info)
    {
        GameObject element=Instantiate(pickedElementOrigin, pickedElementParentTrans);
        element.SetActive(true);
        element.GetComponent<pikcedItem>().Init(info);
    }
	// Update is called once per frame
	//void Update () {
		
	//}
}
