using UnityEngine;
using System.Collections;

public class SimpleFollow : MonoBehaviour
{
    public Transform target;

	void LateUpdate()
    {
	    if(target)
        {
            transform.position = target.position;
        }
	}
}
