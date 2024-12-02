using UnityEngine;
using Mirror;

[RequireComponent(typeof(Rigidbody2D))]
public class Player2Controller : NetworkBehaviour
{
    private Rigidbody2D rb;
    public Animator anim;
    public float speed = 5f;

    // Хранение направления персонажа
    private bool facingRight = true;
    private float horizontalMove = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Блокировка вращения Rigidbody2D
        rb.freezeRotation = true;
    }

    void Update()
    {
        // Получаем вход от пользователя
        horizontalMove = Input.GetAxisRaw("Horizontal");

        // Анимация ходьбы
        if (horizontalMove != 0)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        // Проверяем направление и поворачиваем персонажа
        if (horizontalMove > 0 && !facingRight)
        {
            Flip();
        }
        else if (horizontalMove < 0 && facingRight)
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        // Реализуем движение через Rigidbody2D
        Vector2 targetVelocity = new Vector2(horizontalMove * speed, rb.linearVelocity.y);
        rb.linearVelocity = targetVelocity;
    }

    void Flip()
    {
        // Инвертируем направление
        facingRight = !facingRight;

        // Отражаем персонажа по оси X
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}



	// public void Escape()
	// {
	// 	anim.SetBool("Escape", true);
	// }

	// public void EscapeOff()
	// {
	// 	anim.SetBool("Escape", false);
	// }

	
	// public void Walk()
	// {
	// 	anim.SetBool("Walk", true);
	// }

	// public void WalkOff()
	// {
	// 	anim.SetBool("Walk", false);
	// }
	// public void Doll()
	// {
	// 	anim.SetBool("Doll", true);
	// }
	// public void DollOff()
	// {
	// 	anim.SetBool("Doll", false);
	// }
	// public void Attack()
	// {
	// 	anim.SetBool("Attack", true);
	// }
	// public void AttackOff()
	// {
	// 	anim.SetBool("Attack", false);
	// }



