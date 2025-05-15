using UnityEngine;
using UnityEngine.Events;

public class SelectItem : MonoBehaviour, ISelectItem
{
    [SerializeField] int bateryQtd, itensToConsume;
    [SerializeField] UnityEvent OnUse;

    private void Start()
    {
        bateryQtd = 1;
    }

    public void UseItem(int itenQtd)
    {
      OnUse.Invoke();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bateria"))
        {
            bateryQtd++;
        }
    }

    private void OnMouseDown()
    {
        UseItem(itensToConsume);
    }
}
