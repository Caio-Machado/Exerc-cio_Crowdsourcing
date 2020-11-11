using System;
using System.Collections.Generic;

class Usuarios {
  string nomeUsuario, senhaUsuario;
  bool sentinelaDeRegistroUSU = false;

  public Usuarios (string n, string s) {
    nomeUsuario = n;
    senhaUsuario = s;
  }

  public string getNomeUsuario () {
    return nomeUsuario;
  }

  public string getSenhaUsuario () {
    return senhaUsuario;
  }
  
}

