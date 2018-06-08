using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolItem : MonoBehaviour, IItem{
    private long itemId;

    public static int ToolItemLayer = 8; 
    public ItemInfo info;
	// Use this for initialization
	void Start () {
        transform.gameObject.layer = ToolItemLayer;
	}

    public void OnPicked()
    {
        //should have animation
        ItemPackage.instance.AddItem(info);
        Destroy(transform.gameObject);
        //GetComponent<MeshRenderer>().material.color = Color.green;
    }
    public void OnGazeStart()
    {
        Debug.Log ("start gaze:" + name);
    }
    public void OnGazeEnd()
    {
        Debug.Log("end gaze:" + name);
    }
    public ItemInfo OnGetItemInfo()
    {
        return info;
    }
}
