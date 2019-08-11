using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectTowards : MonoBehaviour
{
    public float speed;

    public PlayerAttack playerAttack{
        get{
            if(m_playerattack == null)
                m_playerattack = transform.root.GetComponent<PlayerAttack>();
                return m_playerattack;
        }
    }
    public PlayerAttack m_playerattack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerAttack.isAttacking)
            UpdateRotation();
    }

    public void UpdateRotation(){
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation,rotation,speed * Time.deltaTime);
    }
}
