//
//
//

using blacktriangles;
using UnityEngine;

//
// This class is responsible for controlling the player visuals, including
// animations, placement of hands, head look, etc.
//

public class PlayerView
    : MonoBehaviour
{
    //
    // types //////////////////////////////////////////////////////////////////
    //

    [System.Serializable]
    public struct BodyPart
    {
        //
        // members ////////////////////////////////////////////////////////////
        //
        
        public Vector3 offset;
        public SpriteRenderer sprite;
        public Transform muzzle;
        public Transform transform                              { get { return sprite.transform; } }
    }
    
    //
    // members ////////////////////////////////////////////////////////////////
    //
    
    [Header("Components")]
    [SerializeField] Animator animator                          = null;
    [SerializeField] SimplePlayerMovement playerMovement        = null;
    [SerializeField] Camera sceneCam                            = null;

    [Header("Body Parts")]
    [SerializeField] BodyPart leftHand;
    [SerializeField] BodyPart rightHand;
    [SerializeField] BodyPart head;

    [Header("FX")]
    [SerializeField] GameObjectPool gunshots;

    private Vector3 mousepos                                    = Vector3.zero;

    //
    // public methods ////////////////////////////////////////////////////////
    //

    public static Quaternion GetRot(Vector3 diff)
    {
        float angle = Mathf.Atan2(diff.y, diff.x)*Mathf.Rad2Deg;
        if(diff.x < 0f)
        {
            return Quaternion.Euler(0f,0f,angle-180f);
        }
        else
        {
            return Quaternion.Euler(0f,0f,angle);
        }
    }

    //
    // ------------------------------------------------------------------------
    //
    
    public void UpdateBodyPart(BodyPart part, Vector3 target, Color color)
    {
        Vector3 diff = target - part.transform.position;

        float angle = Mathf.Atan2(diff.y, diff.x)*Mathf.Rad2Deg;
        part.transform.rotation = GetRot(diff);
    }

    //
    // ////////////////////////////////////////////////////////////////////////
    //

    protected virtual void Awake()
    {
    }

    //
    // ------------------------------------------------------------------------
    //
    
    protected virtual void LateUpdate()
    {
        if(animator == null || playerMovement == null || sceneCam == null) return;

        mousepos = sceneCam.ScreenToWorldPoint(Input.mousePosition);
        mousepos.z = 0f;
        UpdateBodyPart(leftHand, mousepos, Color.red);
        UpdateBodyPart(rightHand, mousepos, Color.green);
        UpdateBodyPart(head, mousepos, Color.blue);

        animator.SetBool("ismoving", playerMovement.isMoving);

        if(mousepos.x - transform.position.x < 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            transform.localScale = Vector3.one;
        }

        ///###hsmith $ARTHACK
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("firepistol");
        }
        else if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            animator.SetTrigger("fireshotgun");
        }
    }

    //
    // ------------------------------------------------------------------------
    //
    
    private void AnimEvent_Gunblast()
    {
        Vector3 diff = mousepos - transform.position;
        
        Quaternion rot = Quaternion.Euler(0f, 0f, Mathf.Atan2(diff.y, diff.x)*Mathf.Rad2Deg);
        GameObject go = gunshots.Take(transform.position + (diff.normalized*1.5f), rot, null);
        go.GetComponent<Animator>().Rebind();
        if(diff.x < 0f)
        {
            go.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            go.transform.localScale = Vector3.one;
        }
    }
}

