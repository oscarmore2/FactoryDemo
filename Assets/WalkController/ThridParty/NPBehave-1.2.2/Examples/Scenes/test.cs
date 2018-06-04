using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public List<System.Action<string, object>> GetObserverList(Dictionary<string, List<System.Action<string, object>>> target, string key)
    {
        List<System.Action<string, object>> observers;
        if (target.ContainsKey(key))
        {
            observers = target[key];
        }
        else
        {
            observers = new List<System.Action<string, object>>();
            target[key] = observers;
        }
        return observers;
    }
	// Update is called once per frame
	//void Update () {
		
	//}
}
