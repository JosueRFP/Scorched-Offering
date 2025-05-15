using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public enum PlayStates
{
    INVENTORY, PLAYING
}
public abstract class InventoryController : MonoBehaviour
{
    
    [SerializeField] GameObject inventoryPainel = null; // O inventário tem um valor nulo
    [SerializeField]  PlayStates _playStates = PlayStates.PLAYING;

    public UnityEvent OnInventory, OnPlay;
    public PlayStates State { get => _playStates; set => _playStates = value; }

    
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

    public void States()
    {

        switch (_playStates)
        {
             case PlayStates.INVENTORY:
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = true;
                break;
                       
            case PlayStates.PLAYING:
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                break;
        }

    }
}
