using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public void SwitchScene(string name) {
        SceneManager.LoadScene(name);
    }
}
