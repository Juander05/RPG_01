using System.Collections;
using UnityEngine;
using TMPro;

public class DialogoNPC : MonoBehaviour
{
    [SerializeField] private GameObject MarcaDeDialogo;
    [SerializeField] private GameObject PanelDeDialogo;
    [SerializeField] private TMP_Text DialogoTexto;
    [SerializeField, TextArea(4,6)]  private string[] LineasDialogo;

    private float typingTime = 0.05f;

    private bool isplayerInRange;
    private bool didDialogueStart;
    private  int lineIndex;

    void Update()
    {
        if(isplayerInRange && Input.GetButtonDown("Fire1"))
        {
            if(!didDialogueStart)
            {
                StartDialogue();
            }
            else if(DialogoTexto.text == LineasDialogo[lineIndex])
            {
                SiguienteLinea();
            }
            else
            {
                StopAllCoroutines();
                DialogoTexto.text = LineasDialogo[lineIndex];
            }

        }
    }


    private void StartDialogue()
    {
        didDialogueStart = true;
        PanelDeDialogo.SetActive(true);
        MarcaDeDialogo.SetActive(false);
        lineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());

    }


    private void SiguienteLinea() {
        lineIndex++;
        if(lineIndex < LineasDialogo.Length)
        {
            StartCoroutine(ShowLine());
        }
        else {            
            didDialogueStart = false;
            PanelDeDialogo.SetActive(false);
            MarcaDeDialogo.SetActive(true);
            Time.timeScale = 1f;
        }
    }

    private IEnumerator ShowLine()
    {
        DialogoTexto.text = string.Empty;

        foreach(char ch in LineasDialogo[lineIndex])
        {
            DialogoTexto.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.CompareTag("Player"))
        {
            isplayerInRange = true;
            MarcaDeDialogo.SetActive(true);
            Debug.Log("se puede iniciar dialogo");
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isplayerInRange = false;
            MarcaDeDialogo.SetActive(false);
            Debug.Log("no se puede iniciar dialogo");
            
        }
    }


}
