using UnityEngine;
using UnityEngine.UI;

public class States : MonoBehaviour
{
    public Text energy;
    public Text hp;
    private gameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        hp.text = gameManager.playerHp + "/" + gameManager.playerMaxHp;
        energy.text = "" + gameManager.playerEnergy;
    }
}
