using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Configurações de Disparo")]
    public GameObject tiroPrefab;
    public Transform pontoDeDisparo;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip somTiro;

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Atirar();
        }
    }

    void Atirar()
    {
        Instantiate(tiroPrefab, pontoDeDisparo.position, Quaternion.identity);

        if (audioSource != null && somTiro != null)
        {
            audioSource.PlayOneShot(somTiro);
        }
    }
}