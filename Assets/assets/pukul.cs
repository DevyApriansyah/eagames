using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pukul : MonoBehaviour {

    public float damage;
    public float knockBack;
    public float knockBackRadius;
    public float tingkatPukul;

    float habisPukul;

    int shootableMask;

    Animator myAnim;
    playerController myPC;
    
	// Use this for initialization
	void Start () {
        shootableMask = LayerMask.GetMask("Shootable");
        myAnim = transform.root.GetComponent<Animator>();
        myPC = transform.root.GetComponent<playerController>();
        habisPukul = 0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float pukul = Input.GetAxis("Fire2");
        if(pukul > 0 && habisPukul < Time.time && !(myPC.getLari())){
            myAnim.SetTrigger("senjataTonjok");
            habisPukul = Time.time + tingkatPukul;

            //do damage
            Collider[] serang = Physics.OverlapSphere(transform.position, knockBackRadius, shootableMask);

        }
	}
}
