using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("-- Screens --")]
    [SerializeField] private GameObject PauseMenuUI;
    [SerializeField] private GameObject QuitMenuUI;
    [SerializeField] private GameObject GameOverMenuUI;

    [Space(10f)]
    [Header("-- Items --")]
    [SerializeField] private GameObject UIParrot;
    [SerializeField] private GameObject UIShovel;
    [SerializeField] private GameObject UIpatch;
    [SerializeField] private GameObject UIHat;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetActiveUIParrot(bool active)
    {
        UIParrot.SetActive(active);
    }
    public void SetActiveUIShovel(bool active)
    {
        UIShovel.SetActive(active);
    }
    public void SetActiveUIpatch(bool active)
    {
        UIpatch.SetActive(active);
    }
    public void SetActiveUIHat(bool active)
    {
        UIHat.SetActive(active);
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
