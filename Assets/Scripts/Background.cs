using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Camera.main.gameObject.transform.position.x, Camera.main.gameObject.transform.position.y, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Camera.main.gameObject.transform.position.x, Camera.main.gameObject.transform.position.y, 0.0f);
    }
}
