using UnityEngine;

public class SkeletonController : MonoBehaviour
{
    public float speed = 2.0f; // Velocidade de movimentação do esqueleto
    public Transform groundCheck; // Objeto que checa se o esqueleto está no chão
    public float groundCheckRadius = 0.1f; // Raio do círculo que checa se o esqueleto está no chão
    public LayerMask whatIsGround; // Camada que representa o chão

    private bool isFacingRight = true; // Verifica se o esqueleto está virado para a direita
    private bool isGrounded = false; // Verifica se o esqueleto está no chão

    void FixedUpdate()
    {
        // Checa se o esqueleto está no chão
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        // Movimenta o esqueleto
        if (isFacingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        // Verifica se o esqueleto chegou no limite do chão
        if (!isGrounded || Physics2D.Raycast(transform.position, Vector2.down, 1f, whatIsGround))
        {
            Flip(); // Vira o esqueleto
        }
    }

    // Vira o esqueleto
    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
