using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class onShadow : MonoBehaviour
{

    [SerializeField] private GameObject lightSource;
    [SerializeField] private Image dehydrationBar;
    [SerializeField] private float dehydrationSpeed;

    [SerializeField] private float startingDehydration;

    private LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        dehydrationBar.fillAmount = startingDehydration;
        line = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (dehydrationBar.fillAmount <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Linecast(gameObject.transform.position, lightSource.transform.position);

        Debug.DrawLine(gameObject.transform.position, lightSource.transform.position);

        Vector3[] positions = { gameObject.transform.position, lightSource.transform.position };

        line.SetPositions(positions);
        //Debug.Log(hit.transform);

        if (hit.transform == null && dehydrationBar.transform.localScale.x > 0 && dehydrationBar.fillAmount > 0)
        {
            dehydrationBar.fillAmount -= dehydrationSpeed;
            line.startColor = Color.red;
            line.endColor = Color.red;
        }
        else
        {
            line.startColor = Color.white;
            line.endColor = Color.white;
        }
    }
}
