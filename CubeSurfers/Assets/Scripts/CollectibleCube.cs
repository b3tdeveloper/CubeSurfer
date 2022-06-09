using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCube : MonoBehaviour
{
    bool isCollected;
    int index;
    public Collector collector;

    // Start is called before the first frame update
    void Start()
    {
        isCollected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollected == true)
        {
            if (transform.parent != null)
            {
                transform.localPosition = new Vector3(0, -index, 0);
            }
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            collector.DecreaseHeight();
            transform.parent = null;
            GetComponent<BoxCollider>().enabled = false;
            other.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public bool GetIsCollected()
    {
        return isCollected;
    }
    public void Collected()
    {
        isCollected = true;
    }
    public void SetIndex(int index)
    {
        this.index = index;
    }
}
