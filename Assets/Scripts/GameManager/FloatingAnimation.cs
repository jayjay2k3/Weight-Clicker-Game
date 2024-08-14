using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Vector3.up * Time.deltaTime * 150;
        Destroy(gameObject,1f);
    }
}
