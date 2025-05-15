using System.Collections;
using UnityEngine;

public enum PlayStates
{
    INVENTORY, PLAYING
}
public abstract class InventoryController : MonoBehaviour
{
    
    [SerializeField] GameObject inventoryPainel = null; // O inventário tem um valor nulo
    [SerializeField]  PlayStates playStates = PlayStates.PLAYING;
    public PlayStates State { get => playStates; set => playStates = value; }

    
    void Awake()
    {        
        inventoryPainel.SetActive(false);// o inventario começa desativado
        
    }

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Q)) // quando se aperta o botão "Q" o inventário abre 
        {            
            inventoryPainel.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape)) // quando se aperta o botão "ESC" o inventário fecha 
        {
            inventoryPainel.SetActive(false);
        }
    }

    public IEnumerator States()
    {
        
        
            switch (playStates)
            {
                case PlayStates.INVENTORY:

                    break;
            }
        
    }
}
