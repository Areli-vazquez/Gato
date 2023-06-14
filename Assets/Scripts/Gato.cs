using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gato : MonoBehaviour
{
    //Variables de clase
    public Button btn;
    public Text txtJuego;


    private int[,] matrizGato = new int[3, 3];
    private int turno = 0; //0- sin iniciar juego, 1 - juega las x, 2- juega las O
    private int ganador = 0, movimientos = 0;

    void Start(){
        //para iniciar el juego
        IniciaGato();
        txtJuego.text = "Juego nuevo";
    }

    public void AsignaTurno(Button btn) {
        if (ganador == 0 && ObtenValorMatrizGato(btn.name)== 0) {  //condiciones para seguir jugando. Que no exista un ganador y que el boton este vacio
            if (turno == 0) {
                turno = 1;//Inicia las x
            }else if (turno == 1) { 
                turno = 2;//continuan las O
            }else{
                turno = 1; //continua las x
            }
            txtJuego.text = "Juego en curso";
            DibujaSimbolo(btn, turno);
            EscribeValorMatrizGato(btn.name, turno);
            movimientos++;
            VerificaGanador();
        }
    }

    private void DibujaSimbolo(Button btn, int t) {
        if (t == 1) {
            btn.GetComponentInChildren<Text>().text = "X";
        } else if (t == 2) {
            btn.GetComponentInChildren<Text>().text = "O";
        }
    }

    private int ObtenValorMatrizGato(string btn) {
        int a = -1;
        switch (btn) {
            case "Btn1":
                a = matrizGato[0, 0];
                break;
            case "Btn2":
                a = matrizGato[0, 1];
                break;
            case "Btn3":
                a = matrizGato[0, 2];
                break;
            case "Btn4":
                a = matrizGato[1, 0];
                break;
            case "Btn5":
                a = matrizGato[1, 1];
                break;
            case "Btn6":
                a = matrizGato[1, 2];
                break;
            case "Btn7":
                a = matrizGato[2, 0];
                break;
            case "Btn8":
                a = matrizGato[2, 1];
                break;
            case "Btn9":
                a = matrizGato[2, 2];
                break;
        }
        return a;
    }


    private void EscribeValorMatrizGato(string btn, int t) {
        switch (btn) {
            case "Btn1":
                matrizGato[0, 0] = t ;
                break;
            case "Btn2":
                matrizGato[0, 1] = t;
                break;
            case "Btn3":
                matrizGato[0, 2] = t;
                break;
            case "Btn4":
                matrizGato[1, 0] = t;
                break;
            case "Btn5":
                matrizGato[1, 1] = t;
                break;
            case "Btn6":
                matrizGato[1, 2] = t;
                break;
            case "Btn7":
                matrizGato[2, 0] = t;
                break;
            case "Btn8":
                matrizGato[2, 1] = t;
                break;
            case "Btn9":
                matrizGato[2, 2] = t;
                break;
        }
    }

    private void VerificaGanador() {
        //Ganador X para los renglones
        if (matrizGato[0, 0] == 1 && matrizGato[0, 1] == 1 && matrizGato[0, 2] == 1) { //  X X X
            ganador = 1; //Gana X
        }
        if (matrizGato[1, 0] == 1 && matrizGato[1, 1] == 1 && matrizGato[1, 2] == 1) { //  X X X
            ganador = 1; //Gana X
        }
        if (matrizGato[2, 0] == 1 && matrizGato[2, 1] == 1 && matrizGato[2, 2] == 1) { //  X X X
            ganador = 1; //Gana X
        }

        //Ganador O para los renglones
        if (matrizGato[0, 0] == 2 && matrizGato[0, 1] == 2 && matrizGato[0, 2] == 2) { //  O O O
            ganador = 2; //Gana O
        }
        if (matrizGato[1, 0] == 2 && matrizGato[1, 1] == 2 && matrizGato[1, 2] == 2) { //  O O O
            ganador = 2; //Gana 0
        }
        if (matrizGato[2, 0] == 2 && matrizGato[2, 1] == 2 && matrizGato[2, 2] == 2) { //  O O O
            ganador = 2; //Gana 0
        }

        //Ganador X para columna
        if (matrizGato[0, 0] == 1 && matrizGato[1, 0] == 1 && matrizGato[2, 0] == 1) { //  X X X
            ganador = 1; //Gana X
        }
        if (matrizGato[0, 1] == 1 && matrizGato[1, 1] == 1 && matrizGato[2, 1] == 1) { //  X X X
            ganador = 1; //Gana X
        }
        if (matrizGato[0, 2] == 1 && matrizGato[1, 2] == 1 && matrizGato[2, 2] == 1) { //  X X X
            ganador = 1; //Gana X
        }

        //Ganador O para columna
        if (matrizGato[0, 0] == 2 && matrizGato[1, 0] == 2 && matrizGato[2, 0] == 2) { //  O O O
            ganador = 2; //Gana O
        }
        if (matrizGato[0, 1] == 2 && matrizGato[1, 1] == 2 && matrizGato[2, 1] == 2) { //  O O O
            ganador = 2; //Gana O
        }
        if (matrizGato[0, 2] == 2 && matrizGato[1, 2] == 2 && matrizGato[2, 2] == 2) { //  O O O
            ganador = 2; //Gana O
        }

        //Ganador X para DIAGONALES
        if (matrizGato[0, 0] == 1 && matrizGato[1, 1] == 1 && matrizGato[2, 2] == 1) { //  X X X
            ganador = 1; //Gana X
        }
        if (matrizGato[0, 2] == 1 && matrizGato[1, 1] == 1 && matrizGato[2, 0] == 1) { //  X X X
            ganador = 1; //Gana X
        }

        //Ganador O para DIAGONALES
        if (matrizGato[0, 0] == 2 && matrizGato[1, 1] == 2 && matrizGato[2, 2] == 2) { //  O O O
            ganador = 2; //Gana O
        }
        if (matrizGato[0, 2] == 2 && matrizGato[1, 1] == 2 && matrizGato[2, 0] == 2) { //  O O O
            ganador = 2; //Gana O
        }

        //SIN GANADOR
        if (ganador == 0 && movimientos == 9) {
            txtJuego.text = "EMPATE";
        }
        if (ganador ==1) {
            txtJuego.text = "Ganador : X";
        }
        if (ganador ==2) {
            txtJuego.text = "Ganador : O";
        }

    }

    private void IniciaGato() {
        //Borramos la matriz , ponemos TODOS sus valores en cero
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                matrizGato[i, j] = 0;
            }
        }
        //Borramos todos los textos de los botones
        GameObject.Find("Btn1").GetComponentInChildren<Text>().text = "";
        GameObject.Find("Btn2").GetComponentInChildren<Text>().text = "";
        GameObject.Find("Btn3").GetComponentInChildren<Text>().text = "";
        GameObject.Find("Btn4").GetComponentInChildren<Text>().text = "";
        GameObject.Find("Btn5").GetComponentInChildren<Text>().text = "";
        GameObject.Find("Btn6").GetComponentInChildren<Text>().text = "";
        GameObject.Find("Btn7").GetComponentInChildren<Text>().text = "";
        GameObject.Find("Btn8").GetComponentInChildren<Text>().text = "";
        GameObject.Find("Btn9").GetComponentInChildren<Text>().text = "";
    }

    public void ReiniciaJuego() {
        SceneManager.LoadScene("Main");
    }

}
