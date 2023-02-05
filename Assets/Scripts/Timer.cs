using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Timer : MonoBehaviour
{
    //Tutorial: https://www.youtube.com/watch?v=2gPHkaPGbpI    
    [SerializeField]
    private Image uiFill;

    [SerializeField]
    private TextMeshProUGUI textMesh;

    public int Duration { get; private set; }
    private int remainingDuration;


    private void Awake()
    {
        textMesh.enabled = false;
        ResetTimer();
    }
    
    private void ResetTimer()
    {
        textMesh.enabled = false;
        textMesh.text = "0:0";
        uiFill.fillAmount = 0f;
        Duration = remainingDuration = 0;
    }
    public Timer SetDuration(int seconds) {
        Duration = remainingDuration = seconds;
        return this;
    }
    public void Begin()
    {
        StopAllCoroutines();
        textMesh.enabled = true;
        StartCoroutine(UpdateTimer());
    }
    public IEnumerator UpdateTimer()
    {
        while (remainingDuration > 0)
        {
            textMesh.text = $"{remainingDuration % 60}";
            uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
            remainingDuration--;
            yield return new WaitForSeconds(1f);
        }
        OnEnd();
    }
    private void OnEnd()
    {
        ResetTimer();
        Debug.Log("EndTimer");
    }
}
