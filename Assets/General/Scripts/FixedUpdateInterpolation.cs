using UnityEngine;
using System.Collections;

public class FixedUpdateInterpolation : MonoBehaviour
{
    new private Transform transform;
    
    private Vector3 lastPosition;
    private Vector3 position;

    
	void Awake()
    {
        transform = GetComponent<Transform>();
        lastPosition = position = transform.position;
	}

    void Start()
    {
        StartCoroutine(UpdatePosition());
    }

    void FixedUpdate()
    {
        transform.position = position;
    }
    
    IEnumerator UpdatePosition()
    {
        while(enabled)
        {
            yield return new WaitForFixedUpdate();
            lastPosition = position;
            position = transform.position;
        }
    }
    
	void Update()
    {
        float amount = (Time.time - Time.fixedTime) / Time.fixedDeltaTime;
        
        transform.position = Vector3.Lerp(lastPosition, position, amount);
	}
}