using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{

    public void MenuShow()
    {
        this.gameObject.SetActive( true);
    }

    public void MenuHide()
    {
        this.gameObject.SetActive(false);
    }
    void Start()
    {

    }
}
