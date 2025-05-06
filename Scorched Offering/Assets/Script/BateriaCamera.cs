using UnityEngine;

public class BateriaCamera : MonoBehaviour

{
    
    [Header("Quantos vai carregar a visao noturna")]
    [SerializeField] private float rechargeAmount = 25f;
    
    [Header("Referência a VisaoNoturna")]
    [SerializeField] private VisaoNoturna cameraMecanicas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (cameraMecanicas != null)
            {
                cameraMecanicas.RecarregarBateria(rechargeAmount);
                Destroy(gameObject);
            }
        }
    }
}
