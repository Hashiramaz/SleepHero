using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {
    public float WalkSpeed;
    public float JumpForce;
    public AnimationClip _walk, _jump;
    public Animation _Legs;
    public Transform _Blade, _GroundCast;
    public Camera cam;
    public bool mirror;

    public SleepManager sleepManager{
        get{
            if(m_sleepManager == null){
                m_sleepManager = GetComponent<SleepManager>();
            }
                return m_sleepManager;
        }
    }

    public SleepManager m_sleepManager;

    public Animator HeroBody;






    private bool _canJump, _canWalk;
    private bool _isWalk, _isJump;
    private float rot, _startScale;
    private Rigidbody2D rig;
    private Vector2 _inputAxis;
    private RaycastHit2D _hit;

    public Animator anim{
        get{
            if(m_anim == null)
            m_anim = transform.root.GetComponent<Animator>();
            return m_anim;

        }
    }

    public Animator m_anim;

	void Start ()
    {
        rig = gameObject.GetComponent<Rigidbody2D>();
        _startScale = transform.localScale.x;
	}

    void Update()
    {
        if(!sleepManager.playerWantsSleep){

            if(!sleepManager.isSleeping){
                
                if (_hit = Physics2D.Linecast(new Vector2(_GroundCast.position.x, _GroundCast.position.y + 0.2f), _GroundCast.position))
                {
                    if (!_hit.transform.CompareTag("Player"))
                    {
                        _canJump = true;
                        _canWalk = true;
                    
                        anim.SetBool("IsGrounded", true); 
                    }
                
        //            Debug.Log(_hit.transform.gameObject.name);
                }
                else{
                _canJump = false;
                anim.SetBool("IsGrounded",false);
                } 
                    

                _inputAxis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                if (_inputAxis.y > 0 && _canJump)
                {
                    _canWalk = false;
                    _isJump = true;
                }
                HeroBody.SetFloat("HSpeed",Mathf.Abs(rig.velocity.x));
                anim.SetFloat("YVelocity",rig.velocity.y);
        
                }
            }
    }

    void FixedUpdate()
    {
        if(!sleepManager.playerWantsSleep){
            if(!sleepManager.isSleeping){

                UpdateMirror();

                UpdateMovement();

                UpdateJump();

                UpdateMirrorAgain();

                }
            }

    }

    void UpdateMirror(){
        Vector3 dir = cam.ScreenToWorldPoint(Input.mousePosition) - _Blade.transform.position;
        dir.Normalize();

        // if (cam.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x + 0.2f)
        //     mirror = false;
        // if (cam.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x - 0.2f)
        //     mirror = true;

        if (!mirror)
        {
            rot = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.localScale = new Vector3(_startScale, _startScale, 1);
            //_Blade.transform.rotation = Quaternion.AngleAxis(rot, Vector3.forward);
        }
        if (mirror)
        {
            rot = Mathf.Atan2(-dir.y, -dir.x) * Mathf.Rad2Deg;
            transform.localScale = new Vector3(-_startScale, _startScale, 1);
            //_Blade.transform.rotation = Quaternion.AngleAxis(rot, Vector3.forward);
        }
    }

void UpdateMovement(){
     if (_inputAxis.x != 0)
        {
            rig.velocity = new Vector2(_inputAxis.x * WalkSpeed * Time.deltaTime, rig.velocity.y);

            if (_canWalk)
            {
                _Legs.clip = _walk;
                _Legs.Play();
            }
        }

        else
        {
            rig.velocity = new Vector2(0, rig.velocity.y);
        }
    }
   
    void UpdateJump(){
  if (_isJump)
        {
            
            rig.AddForce(new Vector2(0, JumpForce));
            _Legs.clip = _jump;
            _Legs.Play();
            _canJump = false;
            _isJump = false;

            anim.SetTrigger("Jump");
        }

    }

 void UpdateMirrorAgain(){
        
        if(rig.velocity.x > 0 && mirror){
            mirror = false;
        }
        if(rig.velocity.x < 0 && !mirror){
            mirror = true;
        }
    }
    

    public bool IsMirror()
    {
        return mirror;
    }

    public void FlipPlayer(){

    }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, _GroundCast.position);
    }
}
