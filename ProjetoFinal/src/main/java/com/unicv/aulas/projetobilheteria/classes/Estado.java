/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package com.unicv.aulas.projetobilheteria.classes;

/**
 *
 * @author pedro
 */
public class Estado {
    public int id;
    public String sigla;
    public String nome;

    public static Estado criar(int pId, String pNome, String pSigla){
        Estado objeto = new Estado();
        objeto.id = pId;
        objeto.nome = pNome;
        objeto.sigla = pSigla;
        
        return objeto;
    }
}
