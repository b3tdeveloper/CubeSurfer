using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float forwardSpeed;
    [SerializeField]
    private float horizontalSpeed;
    [SerializeField]
    private float border;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime;
        float vertical = forwardSpeed * Time.deltaTime;
        this.transform.Translate(horizontal, 0, vertical);
        if (transform.position.z > border)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, border);
        }
        else if (transform.position.z < -border)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -border); ;
        }
    }
}
