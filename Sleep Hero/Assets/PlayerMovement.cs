using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

	Rigidbody2D rb{
		get{
			if(m_rb == null)
			 m_rb = GetComponent<Rigidbody2D>();
			 return m_rb;
		}
	}

	Rigidbody2D m_rb;

	public PlayerManager manager{
			get{
				if(m_manager == null)
				m_manager = transform.root.GetComponent<PlayerManager>();
				return  m_manager;
			}
			}
	public PlayerManager m_manager;
	
	// Update is called once per frame
	void Update () {

		if(manager.knockbackCount <= 0){

			horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		}else{
			if(manager.knockfromRight){
				rb.velocity = new Vector2 ( -manager.knockback, manager.knockback);
			}else
			{
				rb.velocity = new Vector2 ( manager.knockback, manager.knockback);
			}
			manager.knockbackCount -= Time.deltaTime;
		}

		/*if (Input.GetButtonDown("Jump"))
		{
			jump = true;
		}*/

		// if (Input.GetButtonDown("Crouch"))
		// {
		// 	crouch = true;
		// } else if (Input.GetButtonUp("Crouch"))
		// {
		// 	crouch = false;
		// }

	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime,crouch,jump);
		//jump = false;
	}
}
