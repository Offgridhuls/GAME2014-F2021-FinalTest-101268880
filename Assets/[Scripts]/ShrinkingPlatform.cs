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
        minSize = new Vector3(0.1f, 0.1f, 0.1f); // setting minimum size of platform
        maxSize = transform.localScale; // setting maximum size of platform
        collider = this.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
       LerpSize();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player") //when the player touches the collider box of the shrinking platform, set is shrinking to true
        {
            isShrinking = true;
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") //when the player exits the collider box of the shrinking platform, set shrinking to false
        {
            isShrinking = false;
        }
    }

    void LerpSize()
    {
        if (!isShrinking) // if the bool is false
            transform.localScale = Vector3.Lerp(transform.localScale, maxSize, 2.0f * Time.deltaTime); //lerp to the max size, set at start of script
        else
            transform.localScale = Vector3.Lerp(transform.localScale, minSize, 2.0f * Time.deltaTime); //else if true, lerp to minimum size, set at start of script
    }
}
