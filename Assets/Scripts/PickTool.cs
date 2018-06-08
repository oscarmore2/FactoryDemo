using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickTool : MonoBehaviour {
    public float rayLength = 5f;
    public float radius = 5f;
    public bool raycastSingle = true;
    
    private GameObject gazingItemLastFrame = null;
    private RaycastHit hit;
    private Transform tr;
   
    public LayerMask mask;
    // Use this for initialization
    void Start()
    {
        //mask = 1 << LayerMask.NameToLayer("Tool");
        mask = 1 << ToolItem.ToolItemLayer;
        tr = GetComponent<Transform>();
    }
	// Update is called once per frame
	void Update () {
#region for test
        if (Input.GetKeyDown(KeyCode.P))
        {
            PickSingleItem();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            PickSurroundingItems();
        }
        Debug.DrawRay(tr.position, tr.forward * rayLength, Color.green);
#endregion
        if (raycastSingle && Physics.Raycast(tr.position, tr.forward, out hit, rayLength, mask.value))
        {
            //Debug.Log ("射线击中:" + hit.collider.gameObject.name + "\n tag:" + hit.collider.tag);
            GameObject gameObj = hit.collider.gameObject;
            if (gameObj != gazingItemLastFrame)
            {
                if (gazingItemLastFrame != null)
                {
                    ToolItem item = gazingItemLastFrame.GetComponent<ToolItem>();
                    if (item != null)
                        item.OnGazeEnd();
                }
                if (gameObj != null)
                {
                    ToolItem item = gameObj.GetComponent<ToolItem>();
                    if (item != null)
                        item.OnGazeStart();
                }
                gazingItemLastFrame = gameObj;
            }
           
        }
        else
        {
            //Debug.Log("射线没击中"); 
        }
	}
    //拾取单个物品。视线raycast到的
    void PickSingleItem()
    {
        if (gazingItemLastFrame != null)
        {
            ToolItem item = gazingItemLastFrame.GetComponent<ToolItem>();
            if (item != null)
                item.OnPicked();
        }
    }
    //拾取以摄像机为中心，半径为radius的区域内的物品。并把物品加入背包
   void PickSurroundingItems()
    {
        
        Collider[] colliders = Physics.OverlapSphere(tr.position, radius, mask.value);
        Debug.Log("范围内选中 " + colliders.Length);
        List<ItemInfo> itemList = new List<ItemInfo>();
        for (int i = 0; i < colliders.Length; i++)
        {
            Collider ht = colliders[i];
            GameObject gameobj = ht.gameObject;
            ToolItem item = gameobj.GetComponent<ToolItem>();
            if (item != null)
            {//把物品加入背包
                ItemInfo itemInfo = item.OnGetItemInfo();
                itemList.Add(itemInfo);
            }
        }
    }
}
