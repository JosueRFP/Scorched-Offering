using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Nome da fase do jogo")]
    [SerializeField] string NomeDaFase;
    [Header("O painel do controle do jogo")]
    [SerializeField] GameObject painelControle;

    [Header("O painel do Menu")]
    [SerializeField] GameObject painelMenuPrincipal;
    


    public void Jogar()
    {
        SceneManager.LoadScene(NomeDaFase);
        Time.timeScale = 1f;

    }
    public void AbrirOsControle()
    {
        painelControle.SetActive(true);
        painelMenuPrincipal.SetActive(false);
       
    }
    public void FecharOsControle()
    {
       painelControle.SetActive(false);
        painelMenuPrincipal.SetActive(true);
      
    }
    public void Sair()
    {
        Application.Quit();
    }
}
