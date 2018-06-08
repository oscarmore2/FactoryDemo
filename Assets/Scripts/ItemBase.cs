using UnityEngine;


public enum EItemType
{
    EItemType_Tool,
    EItemType_Material,
    EItemType_Machine,
}

[System.Serializable]
public class ItemInfo
{
    public Sprite imagePath;
    public string name;
    public EItemType itemType;
}

public interface IItem
{
    void OnGazeStart();
    void OnGazeEnd();
    void OnPicked();
    ItemInfo OnGetItemInfo();
}
