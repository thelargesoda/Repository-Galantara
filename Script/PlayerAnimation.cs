using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator PlayerAnim;
  
    
    public void FailAnim()  // Ketiga jatuh
    {
        PlayerAnim.SetTrigger("Fell");
    }
    public void JumpAnim()  // Ketiga jatuh
    {
        PlayerAnim.SetTrigger("Jump");
    }

    public void MovementAnim()  // Ketiga jatuh
    {
        if(Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            PlayerAnim.SetBool("Left", true);
        }
        else { PlayerAnim.SetBool("Left", false); }

        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            PlayerAnim.SetBool("Right", true);
        }
        else { PlayerAnim.SetBool("Right", false); }

        if (Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.D))
        {
            PlayerAnim.SetBool("Right", false);
            PlayerAnim.SetBool("Left", false);
        }
       
    }

    public void Flying()
    {
        PlayerAnim.SetBool("Flying", true);
    }
    public void UnFlying()
    {
        PlayerAnim.SetBool("Flying", false);
    }

}
