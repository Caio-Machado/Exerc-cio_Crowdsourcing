using System;
using System.Collections.Generic;

class Projetos {
  private string tituloDoProjeto, descricaoDoProjeto, areaDoProjeto, donoDoProjeto;
  private int indiceDoProjeto, votosTotais;

  public Projetos (string titulo, string descricao, string area, int indice, string dono) {
    tituloDoProjeto = titulo;
    descricaoDoProjeto = descricao;
    areaDoProjeto = area;
    indiceDoProjeto = indice;
    votosTotais = 0;
    donoDoProjeto = dono;
  }


  // GET's
  public string getTituloDoProjeto () {
    return tituloDoProjeto;
  }

  public string getDescricaoDoProjeto () {
    return descricaoDoProjeto;
  }

  public string getAreaDoProjeto () {
    return areaDoProjeto;
  }

  public int getVotosTotais () {
    return votosTotais;
  }


  // SET's
  public void setVotosTotais () {
    votosTotais++;
  }

  public void mostraRepositorio () {
    //Console.Clear();
    Console.WriteLine($"----- {tituloDoProjeto} -----");
    Console.WriteLine($"indice do Idéia >> {indiceDoProjeto}");
    Console.WriteLine($"Área da Idéia: {areaDoProjeto}");
    Console.WriteLine($"Descrição da Ideia: {descricaoDoProjeto}");
    Console.WriteLine($"Total de Likes: {votosTotais}");
    Console.WriteLine($"Dono do Projeto: {donoDoProjeto}");
  }
}
