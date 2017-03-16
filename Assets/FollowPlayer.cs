using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{
    public static int hitCount = 0;
    Animator anim;
    Animation am1;
    Transform tr_Player;
    float f_RotSpeed = Spawn.enemyId+3, f_MoveSpeed = Spawn.enemyId+3;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        am1 = GetComponent<Animation>();
        tr_Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        /* Look at Player*/
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(tr_Player.position - transform.position), f_RotSpeed * Time.deltaTime);
        /* Move at Player*/
        transform.position += transform.forward * f_MoveSpeed * Time.deltaTime;
        Vector3 dist = transform.position - tr_Player.position;
        if (dist.magnitude<3.0f&&hitCount<=300)
        {
                hitCount++;
                anim = transform.GetComponent<Animator>();
                anim.SetTrigger("LeftPunch");
            anim = tr_Player.GetComponent<Animator>();
            anim.SetTrigger("HitStomach");
        }
        else
        {
            anim = transform.GetComponent<Animator>();
            anim.ResetTrigger("LeftPunch");
            anim = tr_Player.GetComponent<Animator>();
            anim.ResetTrigger("HitStomach");
        }
        if(hitCount>300)
        {
            anim = tr_Player.GetComponent<Animator>();
            if (hitCount > 300)
            {
                anim.SetTrigger("Die");
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(transform.position - transform.position), f_RotSpeed * Time.deltaTime);
            }
            transform.position = transform.position;
            Application.Quit();
        }
    }
}
