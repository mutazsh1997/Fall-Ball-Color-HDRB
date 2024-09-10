using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obsicalmoement : MonoBehaviour
{
    [SerializeField] float movementDir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.position.x , movementDir * Time.deltaTime, transform.position.z);
    }
 }
