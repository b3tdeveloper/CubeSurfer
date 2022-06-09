using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCube : MonoBehaviour
{
    bool isCollected;
    int index;
    public Collector collector;
    int destroyAmount;
    int counter;

    // Start is called before the first frame update
    void Start()
    {
        isCollected = false;
        destroyAmount = 1;
        counter = 0;
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
        if (other.gameObject.CompareTag("Posion"))
        {
            Invoke("DestroyCubesInPosion", 0.15f);
        }
    }
    
    public void DestroyCubesInPosion()
    {
        collector.DecreaseHeight();
        transform.parent = null;
        GetComponent<BoxCollider>().enabled = false;
            
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
