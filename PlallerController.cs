using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlallerController : MonoBehaviour {

    [SerializeField] private float velocidad = 3; //unidades de espacio global por segundo

    private float horizontal;
    private float vertical;
    private InputPlayer inputPlayer;
    private new Transform transform;
    private Rigidbody2D rigidBody2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    int isRunningHashCode;
    

	// Use this for initialization
	void Start () {
        inputPlayer = GetComponent<InputPlayer>();
        transform = GetComponent<Transform>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isRunningHashCode = Animator.StringToHash("Running");
    }

    // Update is called once per frame
    void Update()
    {
        // Monitorea si el jugador presiona las flechas
        horizontal = inputPlayer.EjeHorizontal;
        vertical = inputPlayer.EjeVertical;

        // Traslada el movimiento al animador del jugador solo si se presiona una tecla (si el estado es distinto a 0)
        if (horizontal != 0 || vertical != 0)
        {
            SetXYAnimator();
            animator.SetBool(isRunningHashCode, true);
        }
        else
        {
           animator.SetBool(isRunningHashCode, false);
        }

    }

    private void SetXYAnimator()
    {
        animator.SetFloat("X", horizontal);
        animator.SetFloat("Y", vertical);
    }

    void FixedUpdate()
    {
        //--- Movimiento ---//
        Vector2 velocidadDelVector = new Vector2(horizontal, vertical) * velocidad;
        rigidBody2D.velocity = velocidadDelVector;
    }
   
}
