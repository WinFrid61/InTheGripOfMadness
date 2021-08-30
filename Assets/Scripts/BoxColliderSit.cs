using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliderSit : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    BoxCollider2D Sitting, Standing;

    public bool SitR, SitL;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Sitting = GetComponent<BoxCollider2D>();
        Standing = GetComponent<BoxCollider2D>();
    }
    
    // Update is called once per frame
    void Update()   
    {
        if (((Input.GetKey("s")) && (Input.GetKeyDown("d"))) ||
            ((Input.GetKey("s")) && (!spriteRenderer.flipX)) || 
            ((Input.GetKey("down")) && (Input.GetKeyDown("right"))) || 
            ((Input.GetKey("down")) && (!spriteRenderer.flipX)))
            {
            SitR = true;
            SitL = false;
                Sitting.size = new Vector2(1.017f, 3.69f);
                Sitting.offset = new Vector2(0.048f, -0.08f);
                Sitting.size = new Vector2(Sitting.size.x * 1.47f, Sitting.size.y * 0.69f); // x 1.47230383480826 # y 0.6968745257452575
                Sitting.offset = new Vector2(Sitting.offset.x * 7.1f, Sitting.offset.y * 8.1f); // x 7.12644583# y 8.37965875
            }
        else if (((Input.GetKey("s")) && (Input.GetKeyDown("a"))) ||
            ((Input.GetKey("s")) && (spriteRenderer.flipX)) ||
            ((Input.GetKey("down")) && (Input.GetKeyDown("left"))) ||
            ((Input.GetKey("down")) && (spriteRenderer.flipX)))
            {
                SitR = false;
                SitL = true;
                Sitting.size = new Vector2(1.017f, 3.69f);
                Sitting.offset = new Vector2(0.048f, -0.08f);
                Sitting.size = new Vector2(Sitting.size.x * 1.47f, Sitting.size.y * 0.69f); // x 1.47230383480826 # y 0.6968745257452575
                Sitting.offset = new Vector2(Sitting.offset.x * -7.1f, Sitting.offset.y * 8.1f); // x 7.12644583# y 8.37965875
            }
        else if (Input.GetKeyUp("s") || Input.GetKeyUp("down") || Input.GetKeyDown("w") || Input.GetKey("up") || Input.GetKey("space")) 
            {
                SitR = false;
                SitL = false;
                Sitting.size = new Vector2(1.017f, 3.69f);
                Sitting.offset = new Vector2(0.048f, -0.08f);
            }

        //if (Input.GetKey("d") || Input.GetKey("right")) 
        //{
        //    Sitting.offset = new Vector2(0.4f, Sitting.offset.y);

        //}
        //else if (Input.GetKey("a") || Input.GetKey("left"))
        //{
        //    Sitting.offset = new Vector2(-0.4f, Sitting.offset.y); 
        //}
    }
}
