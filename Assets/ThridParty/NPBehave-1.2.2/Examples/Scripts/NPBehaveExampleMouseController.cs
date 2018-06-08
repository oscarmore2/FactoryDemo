using UnityEngine;

public class NPBehaveExampleMouseController : MonoBehaviour
{
    private Camera theCamera;

    void Start()
    {
        theCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        Ray ray = theCamera.ScreenPointToRay(Input.mousePosition);
        Vector3 pos = RayCast(ray);

		//Debug.Log ("pos="+pos.ToString()+"ray.origin"+ray.origin.ToString());
        this.transform.position = pos;
    }

    private Vector3 RayCast(Ray r)
    {
        float z = 0f;

        float delta = (z - r.origin.z) / r.direction.z;
	    //Debug.Log ("delta="+delta+"r.direction.z="+r.direction.z.ToString ()+"r.origin.z="+r.origin.z);
        if (delta > 0.1f && delta < 10000f)
        {
            return r.origin + r.direction * delta;
        }
        else
        {
            return Vector3.zero;
        }
    }

}