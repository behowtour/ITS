using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionGrassToNextStage : MonoBehaviour
{
    [SerializeField]
    float scoreCountToMakeTransition;
    float currentScore;
    [SerializeField]
    GameObject transitionPrefab;
    [SerializeField]
    Camera mainCamera;
    float transitionPrefabYpositionToAdd;
    [SerializeField]
    ScoreController scoreController;
    [SerializeField]
    float offset = 0f;
    [SerializeField]
    GameObject background;
    // Start is called before the first frame update



    /* TO FIX :
     переписать scoreCountToMakeTransition = 0 на ФЛАГ
    убрть упоминание конкретного Dandellion , именовать обобщенно
    обобщить некоторые расчеты
    проверить offset  - он общий для поинта и Перехода
    */


    void Start()
    {
           transitionPrefabYpositionToAdd = transitionPrefab.transform.GetChild(0).GetComponent<SpriteRenderer>().bounds.size.y / 2 + mainCamera.orthographicSize;

          
    }

    // Update is called once per frame
    void Update()
    {
       TransitionPrefabInstantiation();

        //  TRANSITION PERIOD



    }

    void TransitionPrefabInstantiation() {

        float prefabYposition = transitionPrefabYpositionToAdd + mainCamera.transform.position.y;
        currentScore = scoreController.score.score;

        // INSTANTIATE Dandellion Transit
        if (currentScore > scoreCountToMakeTransition && scoreCountToMakeTransition != 0)
        {
            Vector3 newPrefabPosition = new Vector3(mainCamera.transform.position.x, prefabYposition, 0);

            Instantiate(transitionPrefab, newPrefabPosition, transitionPrefab.transform.rotation, background.transform);
            scoreCountToMakeTransition = 0;
        }
    }
    
}
