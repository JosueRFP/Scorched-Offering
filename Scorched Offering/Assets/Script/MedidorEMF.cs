using UnityEngine;

public class MedidorEMF : MonoBehaviour
{
    [Header("Referencindo")]
    [SerializeField] private Transform player;
    [SerializeField] private Transform boitata;
    [SerializeField] private GameObject modeloMedidor;

    [Header("Material")]
    [SerializeField] private GameObject[] luzes;

    [Header("Distância ativar material")]
    [SerializeField] private float[] faixasDistancia = { 20f, 15f, 10f, 5f, 2f };

    [Header("Seguir player")]
   [SerializeField] private Transform pontoMedidor; 

    private bool medidorAtivo = false;

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (medidorAtivo) DesativarMedidor();
            else AtivarMedidor();
        }

        if (medidorAtivo && boitata != null)
        {
            AtualizarLuzes();
        }
    }

    private void AtualizarLuzes()
    {
        float distancia = Vector3.Distance(player.position, boitata.position);

        int luzesParaAtivar = 0;
        for (int i = 0; i < faixasDistancia.Length; i++)
        {
            if (distancia <= faixasDistancia[i])
                luzesParaAtivar = i + 1;
        }

        for (int i = 0; i < luzes.Length; i++)
        {
            luzes[i].SetActive(i < luzesParaAtivar);
        }
    }

  public void AtivarMedidor()
{
    modeloMedidor.SetActive(true);
    medidorAtivo = true;

    
    modeloMedidor.transform.SetParent(pontoMedidor);
    modeloMedidor.transform.localPosition = Vector3.zero;     
    modeloMedidor.transform.localRotation = Quaternion.identity;
}   

  public void DesativarMedidor()
{
    modeloMedidor.SetActive(false);
    medidorAtivo = false;

    modeloMedidor.transform.SetParent(null); 
}
}
