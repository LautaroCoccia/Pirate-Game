using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenuUI;
    [SerializeField] private GameObject QuitMenuUI;
    [SerializeField] private GameObject GameOverMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetActivePauseMenuUI(bool active)
    {
        PauseMenuUI.SetActive(active);
    }
    public bool GetActivePauseMenuUI()
    {
        return PauseMenuUI.activeSelf;
    }
    public void SetActiveQuitMenuUI(bool active)
    {
        QuitMenuUI.SetActive(active);
    }
    public bool GetActiveQuitMenuUI()
    {
        return QuitMenuUI.activeSelf;
    }
    public void SetActiveGameOverMenuUI(bool active)
    {
        GameOverMenuUI.SetActive(active);
    }
}
