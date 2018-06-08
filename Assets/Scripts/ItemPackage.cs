using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//背包类
public class ItemPackage : MonoSingleton<ItemPackage> {
    
    Dictionary<EItemType, List<ItemInfo>> itemsDic = new Dictionary<EItemType, List<ItemInfo>>();
    public bool AddItem(ItemInfo itemInfo)
    {
        List<ItemInfo> itemList;
        if (!itemsDic.TryGetValue(itemInfo.itemType, out itemList) || itemList == null)
        {
            itemList = new List<ItemInfo>();
            itemsDic[itemInfo.itemType] = itemList;
        }
        itemList.Add(itemInfo);
        Debug.Log(itemInfo.name + "添加到了工具箱");
        return true;
    }
    public bool RemoveItem(ItemInfo itemInfo)
    {
        List<ItemInfo> itemList;
        if (!itemsDic.TryGetValue(itemInfo.itemType, out itemList) || itemList == null)
        {
            return false;
        }
        itemList.Remove(itemInfo);
        return true;
    }
}
