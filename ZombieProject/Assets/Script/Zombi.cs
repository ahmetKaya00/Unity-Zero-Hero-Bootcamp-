using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Zombi : MonoBehaviour
{
    public float moveSpeed = 0.5f, detectRange = 10f, attackRange = 1.5f;
    public Transform target;
    public GameObject zombi, ekranFlas;
    private Animator animator;
    public AudioSource[] sound;
    public int Saldiri, VurmaSesi;
    private bool isAttakcing = false, isCashing = false;

    private float attackCoolDown = 1.5f;
    private float currentCoolDown = 0f;

    private void Start()
    {
        animator = zombi.GetComponent<Animator>();
        InvokeRepeating("RandomMovement", 0f, 2f);
    }

    private void Update()
    {
        
        if(target != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            if(distanceToTarget <= attackRange)
            {
                Attack();
            }
            else if(distanceToTarget <= detectRange)
            {
                MoveTowardsTarget();
                isCashing = true;
            }
            else
            {
                isCashing =false;
                isCashing =false;
                animator.SetBool("Walking", true);
                animator.SetBool("Attacking", false);
            }
        }
        if(currentCoolDown > 0)
        {
            currentCoolDown -= Time.deltaTime;
        }
        else
        {
            isAttakcing = false;
        }
    }
    void RandomMovement()
    {
        if (!isCashing)
        {
            float randomAngle = Random.Range(0, 360f);
            transform.Rotate(0f, randomAngle, 0f);
        }
    }
    void MoveTowardsTarget()
    {
        transform.LookAt(target);
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        animator.SetBool("Walking", true);
        animator.SetBool("Attacking", false);
    }
    void Attack()
    {
        animator.SetBool("Walking", false);
        animator.SetBool("Attacking", true);
        if(!isAttakcing && KalanCan.OyuncuCan > 0)
        {
            isAttakcing = true;
            KalanCan.OyuncuCan -= 1;
            currentCoolDown = attackCoolDown;
            if(KalanCan.OyuncuCan > 0)
            {
                int randomSoundIndex = Random.Range(0, sound.Length);
                sound[randomSoundIndex].Play();
                StartCoroutine(ActiveAndDeactiveFlash());
            }
        }
    }

    IEnumerator ActiveAndDeactiveFlash()
    {
        ekranFlas.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        ekranFlas.SetActive(false);
    }
}
