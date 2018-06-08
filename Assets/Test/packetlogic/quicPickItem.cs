using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class quicPickItem : baseItem {

	// Use this for initialization
	void Start () {
		
	}
    public override void Onclicked()
    {
        // throw new System.NotImplementedException();
        ItemPackage.instance.AddItem(this.info);
        packeUIControl.instance.AddPickedElementUI(this.info);
    }
}
