using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    private UIManager uiManager;

    void Start()
    {
        // Procura o gestor de UI automaticamente na cena
        uiManager = FindFirstObjectByType<UIManager>();
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o objeto que bateu na nave tem a Tag "Alien"
        if (collision.CompareTag("Alien"))
        {
            uiManager.AtivarGameOver(); 
        }

        Destroy(gameObject);
    }
}