/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package com.unicv.aulas.projetobilheteria.classes;

/**
 *
 * @author pedro
 */
public class MetodoPagamento {
    public int id;    
    public String nome;
    
    public static MetodoPagamento criar(int pId, String pNome){
        MetodoPagamento objeto = new MetodoPagamento();
        objeto.id = pId;
        objeto.nome = pNome;
        
        return objeto;
    }
}
