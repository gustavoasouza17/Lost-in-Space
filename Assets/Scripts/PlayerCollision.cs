using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o objeto que bateu na nave tem a Tag "Alien"
        if (collision.CompareTag("Alien"))
        {
            Destroy(gameObject); // Destrói a nave
            
            // Mensagem de teste no console. Futuramente, isso ativará a tela de Game Over.
            Debug.Log("Nave destruída! Chamar Game Over."); 
        }
    }
}