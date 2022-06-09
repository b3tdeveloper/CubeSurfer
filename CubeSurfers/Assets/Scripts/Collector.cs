using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    GameObject mainCube;
    int height;

    // Start is called before the first frame update
    void Start()
    {
        mainCube = GameObject.Find("MainCube");
    }

    // Update is called once per frame
    void Update()
    {
        mainCube.transform.position = new Vector3 (transform.position.x, height + 1, transform.position.z);
        this.transform.localPosition = new Vector3 (0, -height, 0);
    }

    public void DecreaseHeight()
    {
        height--;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible")&& other.gameObject.GetComponent<CollectibleCube>().GetIsCollected() == false)
        {
            height += 1;
            other.gameObject.GetComponent<CollectibleCube>().Collected();
            other.gameObject.GetComponent<CollectibleCube>().SetIndex(height);
            other.gameObject.transform.parent = mainCube.transform;
        }
    }
}
