using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform target;

    [SerializeField] private float speed;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 targetPosition = target.position;
        targetPosition.z = transform.position.z;
        targetPosition.y = transform.position.y;

        Vector3 error = targetPosition - transform.position;

        //transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        transform.position = transform.position + error * Mathf.Min(Time.fixedDeltaTime / speed, 1);

    }

    public void SetTargetCamera(Vector3 position)
    {
        target.position = position;
    }
}
