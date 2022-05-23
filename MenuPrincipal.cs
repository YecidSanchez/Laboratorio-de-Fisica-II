using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour {
    //Menú Corte I
    public void EscenaCaidaLibre() {
        SceneManager.LoadScene("Caída Libre");
    }
    public void EscenaPlanoInclinado() {
        SceneManager.LoadScene("Plano Inclinado");
    }
    public void EscenaSistemaMasaResorte() {
        SceneManager.LoadScene("Sistema Masa Resorte");
    }

    public void EscenaTiroParabolico() {
        SceneManager.LoadScene("Tiro parabólico");
    }
    //Menú Corte II
    public void EscenaMomentoLineal() {
        SceneManager.LoadScene("Momento Lineal");
    }
    public void EscenaColisionEn2D() {
        SceneManager.LoadScene("Colisión en 2D");
    }
    public void EscenaColisionEn2DConVariasEsferas() {
        SceneManager.LoadScene("Colisión en 2D con varias Esferas");
    }
    public void EscenaColisionContraUnPlano() {
        SceneManager.LoadScene("Colisión Contra un Plano");
    }
    //Menú Corte III
    public void EscenaBarcosYBotes() {
        SceneManager.LoadScene("Barcos y Botes");
    }
    //Otras Funciones
    public void Regresar() {
        SceneManager.LoadScene("Menú Principal");
    }
    public void Salir() {
        Application.Quit();
        Debug.Log("Se ha salido del juego");
    }
}