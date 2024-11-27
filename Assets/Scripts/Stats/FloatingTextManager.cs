using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextManager : MonoBehaviour
{
    public static FloatingTextManager Instance;
    public GameObject textPrefabs;

    private void Awake()
    {
        instance = this;
    }

    public void Show(string text, Vector3 worldPos)
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(worldPos);

        GameObject textObj = Instantiate(textPrefabs, transform);
        textObj.transform.position = screenPos;

        TextMeshProUGUI temp = textObj.GetComponent<TextMeshProUGUI>();

        if(temp != null )
        {
            temp.text = text;
            StartCoroutine(AnimateText(textObj));
        }
    }

    private IEnumerator AnimateText(GameObject textObj)
    {
        float duration = 1f;
        float timer = 0;

        Vector3 startPos = textObj.transform.position;
        TextMeshProUGUI temp = textObj.GetComponet<TextMeshProUGUI>();

        while(timer<duration)
        {
            timer += timer.deltaTime;
            float progress = timer / duration;

            textObj.transform.position = startPos + Vexctor3.up * (progress * 50f);

            if(temp != null )
            {
                temp.alpha = 1- progress;
            }
            yield return null;
        }

        Destroy(textObj);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
