using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Shrinking Platform
//Julian Sangiorgio
//101268880
//2021-12-17
public class ShrinkingPlatform : MonoBehaviour
{
    [Header("ShrinkingBool")]
    bool isShrinking = false;

    [Header("Minimum and Maximum, platform sizes")]
    private Vector3 maxSize;
    private Vector3 minSize;

    private BoxCollider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        minSize = new Vector3(0.1f, 0.1f, 0.1f);
        maxSize = transform.localScale;
        collider = this.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
       LerpSize();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isShrinking = true;
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isShrinking = false;
        }
    }

    void LerpSize()
    {
        if (!isShrinking)
            transform.localScale = Vector3.Lerp(transform.localScale, maxSize, 2.0f * Time.deltaTime);
        else
            transform.localScale = Vector3.Lerp(transform.localScale, minSize, 2.0f * Time.deltaTime);
    }
}
