using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class baseItem : MonoBehaviour {
    public ItemInfo info;
	// Use this for initialization
	void Start () {
        Init(info);
	}
    public Image img;
    public Text nameText;
    //public Text countText;
    public void Init(ItemInfo itemInfo)
    {
        info = itemInfo;
        img.sprite = itemInfo.imagePath;
        nameText.text = itemInfo.name;
    }
    public abstract void Onclicked();
    // Update is called once per frame
 //   void Update () {
		
	//}
}
