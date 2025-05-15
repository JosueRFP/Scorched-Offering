using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SelectItem : MonoBehaviour, ISelectItem // interface de selecionar o item
{
    [SerializeField] GameObject bateryBTN;
    [SerializeField] int bateryQtd;// a quantidade de bateria
    [SerializeField] UnityEvent OnUse;// evento de uso

    int itensToConsume = -1;// quantidade de consumo dos itens
    private void Start()
    {
        bateryQtd = 1;// a quantidade de pilhas começa em 1
    }

    public void UseItem(int itenQtd)// função diretamente da interface
    {
        OnUse.Invoke();// invoca o evento 
        OnMouseDown();
        if (bateryQtd == 0)// se a quantidade for igual a zero
        {
            bateryBTN.SetActive(false);
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bateria"))// quando a colisão bate em algum objeto com a tag
        {
            bateryQtd++;// a quantidade de itens aumenta 
            Destroy(other.gameObject);// o objeto que foi colidido é destruido
        }
            
        
    }

    public void OnMouseDown()
    {
        if (bateryBTN == true)
        {
            print("fuinciona");
            UseItem(itensToConsume - bateryQtd);
        }
        
    }
}
