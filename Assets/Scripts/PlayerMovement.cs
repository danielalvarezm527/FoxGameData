using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
    public activarPalanca activa;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	float vertivalMove = 0f;
	float tiempo = 0f;
    float movimientoSuave = 0.05f;

    Rigidbody2D player;

    Vector3 velocidad = Vector3.zero;

    public Animator Player;

	public bool puedeSaltar = false;
    public bool activaPalanca = false;
    bool jump = false;
    bool muere = false;
	bool crouch = false;
	public bool escaleras = false;

    private void Start()
    {
        player = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update () {
        if(muere == false)
		    horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (escaleras)
            vertivalMove = Input.GetAxisRaw("Vertical") * runSpeed;
        else
            vertivalMove = 0;

        if (escaleras)
        {
            if (vertivalMove > 0)
            {
                player.AddForce(transform.up * 10f);
                Player.SetBool("SubeEscaleras", true);
            }

            if (vertivalMove < 0)
            {
                player.AddForce(transform.up * -10f);
                Player.SetBool("SubeEscaleras", true);
            }

            if (vertivalMove == 0)
            {
                if (!puedeSaltar)
                {
                    player.velocity = new Vector2(0, 0);
                    Player.SetBool("SubeEscaleras", false);
                    Player.PlayInFixedTime("SubeEscaleras", 0, 0.0f);
                }
                else
                    Player.SetBool("SubeEscaleras", false);
            }
        }
        else
            Player.SetBool("SubeEscaleras", false);

        if (muere)
        {
            horizontalMove = 0;
            tiempo += Time.fixedDeltaTime;
            if (tiempo > 2)
                SceneManager.LoadScene(0);
        }

        if (horizontalMove < 0)
            this.gameObject.transform.localScale = new Vector2(-1, 1);
        else
            this.gameObject.transform.localScale = new Vector2(1, 1);

        if (horizontalMove != 0)
        {
            Player.SetBool("Camina", true);

        }
        else
        {
            Player.SetBool("Camina", false);
        }

		if (Input.GetButtonDown("Jump"))
		{
            if (puedeSaltar)
            {
                if (!escaleras)
                {
                    player.AddForce(new Vector2(0f, 700));
                    Player.SetBool("Salto", true);
                    Debug.Log("Puede Saltar");
                }
            }

		}

        if (activa.adentro)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                activaPalanca = true;
            }
        }

        if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

	}

    void FixedUpdate ()
	{
        Vector3 targetVelocity = new Vector2((horizontalMove * Time.fixedDeltaTime) * 7f, player.velocity.y);
        player.velocity = Vector3.SmoothDamp(player.velocity, targetVelocity, ref velocidad, movimientoSuave);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Aguila")
        {
            Player.SetBool("Muere", true);
            muere = true;
        }
    }
}
