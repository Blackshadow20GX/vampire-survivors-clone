using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator am;
    PlayerMovement pm;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        am = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        am.SetBool("Move", pm.IsMoving());
        if (pm.IsMoving()) 
        {
            SpriteDirectionTracker();
        }
    }

    void SpriteDirectionTracker()
    {
        // Was previously pm.lastHorizontalVector, but I didn't have this bug. See PlayerMovement script.
        if (pm.IsMovingLeft())
        {
            sr.flipX = true;
        }
        if (pm.IsMovingRight())
        {
            sr.flipX = false;
        }
    }
}
