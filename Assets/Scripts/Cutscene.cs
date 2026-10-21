using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    [SerializeField] private GameObject[] pages;
    [SerializeField] private string sceneName;
    private int currPage = 0;

    public void NextPage() {
        if(currPage == pages.Length-1){
            SceneManager.LoadScene(sceneName);
            return;
        }
        pages[currPage].SetActive(false);
        currPage++;
        pages[currPage].SetActive(true);
    }
}
