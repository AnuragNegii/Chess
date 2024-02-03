using UnityEngine;

public class MovePlate : MonoBehaviour {
    public GameObject controller;

    GameObject reference = null;

    //Board Positions , not word positions
    int matrixX, matrixY;

    // false: movement , true : attacking
    public bool attack = false;

    public void Start(){
        if (attack){
            //change to red
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
    }

    public void OnMouseUp(){
        controller = GameObject.FindGameObjectWithTag("GameController");

        if (attack){
            GameObject cp = controller.GetComponent<Game>().GetPosition(matrixX, matrixY);

            if(cp.name == "white_king")controller.GetComponent<Game>().Winner("black");
            if(cp.name == "black_king")controller.GetComponent<Game>().Winner("white");

            Destroy(cp);
        }

        controller.GetComponent<Game>().SetPositionEmpty(reference.GetComponent<ChessMan>().GetXBoard(), 
                        reference.GetComponent<ChessMan>().GetYBoard());

        reference.GetComponent<ChessMan>().SetXBoard(matrixX);
        reference.GetComponent<ChessMan>().SetYBoard(matrixY);
        reference.GetComponent<ChessMan>().SetCoords();

        controller.GetComponent<Game>().SetPosition(reference);

        controller.GetComponent<Game>().NextTurn();
        
        reference.GetComponent<ChessMan>().DestroyMovePlates();
    }

    public void SetCoords(int x, int y){
        matrixX = x;
        matrixY = y;
    }

    public void SetReference(GameObject obj){
        reference = obj;
    }

    public GameObject GetReference(){
        return reference;
    }
}