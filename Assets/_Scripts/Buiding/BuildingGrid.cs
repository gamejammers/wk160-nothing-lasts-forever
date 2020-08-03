using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGrid : MonoBehaviour
{
    public SpriteRenderer alertSprite;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ground" )
        {
            alertSprite.enabled = true;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Ground" )
        {
            alertSprite.enabled = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Ground" )
        {
            alertSprite.enabled = false;
        }
    }
}
