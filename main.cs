using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    // Atributos
    //Sentinelas dos whiles
    bool sentinelaPrincipal = false, sentinelaMenuOpcoes = false;

    //Atributos para validar o Login e o Registro
    bool usuarioValidoLogin = false, usuarioValidoRegistro = true;

    //Inicializar a variável que gerencia o menu de login e registro
    string respostaMenuIniciar = "R";

    //Atributo que salva o nome e a senhas tanto do registro quanto o login
    string nomeRegistro, senhaRegistro, nomeLogin, senhaLogin;

    //Atributo que salva qual usuário está logado
    int usuarioLogado = 0;

    //Atributo que registra a resposta do usuário das opções
    int respostaUsuarioOpcoes = 0;

    //Atributo que registra qual ideia o usuário escolheu votar
    int respostaUsuarioVoto;

    //Atributo que guarda o indice da ideia mais votada
    int primeiroLugar, segundoLugar, terceiroLugar, ideiaVencedora = 0;

    //Atributo que guarda o total de votos ja realizados
    double totalGeralVotos = 0;

    //Atributos que quardam as especificações de uma Idéia
    string registraTitulo, registraDescricao, registraArea;

    // Listas
    List<Projetos> Repositorio = new List<Projetos>{};
    List<Usuarios> ListaUsuarios = new List<Usuarios>{};

    // Instanciação
    Usuarios AreaUsuario = new Usuarios("Vazio", "Vazio");
    Projetos Ideias = new Projetos("Titulo", "Descricao", "Área", 0, "Dono");

    while (sentinelaPrincipal == false) {
      try {
        Console.WriteLine("Olá, Deseja Logar ou Registrar (L/R)");
        Console.Write(">> ");
        respostaMenuIniciar = Console.ReadLine();
        if (respostaMenuIniciar != "L" && respostaMenuIniciar != "R") {
          throw new ArgumentException();
        }

        if (respostaMenuIniciar == "R") {
          Console.WriteLine("-----Cadastro de Usuário-----");
          Console.Write("Nome >> ");
          nomeRegistro = Console.ReadLine();

          Console.Write("Senha >> ");
          senhaRegistro = Console.ReadLine();

          if (nomeRegistro == "" || senhaRegistro == "") {
            throw new ArgumentException();
          }

          for (int b = 0; b < ListaUsuarios.Count; b++) {
            if (nomeRegistro == ListaUsuarios[b].getNomeUsuario()) {
              usuarioValidoRegistro = false;
            }
          }

          if (usuarioValidoRegistro == true) {
            AreaUsuario = new Usuarios(nomeRegistro, senhaRegistro);
            ListaUsuarios.Add(AreaUsuario);
          }
          
          else {
            Console.WriteLine("Usuário já registrado!!");
          }
        }

        else if (respostaMenuIniciar == "L") {
          Console.WriteLine("-----Login-----");
          Console.Write("Nome >> ");
          nomeLogin = Console.ReadLine();
          Console.Write("Senha >> ");
          senhaLogin =  Console.ReadLine();

          for (int a=0; a < ListaUsuarios.Count; a++) {
            if (nomeLogin == ListaUsuarios[a].getNomeUsuario() && senhaLogin == ListaUsuarios[a].getSenhaUsuario()) {
              usuarioValidoLogin = true;
              usuarioLogado = a;
            }
          }
          sentinelaMenuOpcoes = false;
          while (sentinelaMenuOpcoes == false) {
            if (usuarioValidoLogin == true) {
              Console.Clear();
              Console.WriteLine($"Bem-Vindo(a) {ListaUsuarios[usuarioLogado].getNomeUsuario()}\n");

              Console.WriteLine("O que deseja fazer?");
              Console.WriteLine("1 - Cadastrar uma Idéia \n2 - Votar em Idéias \n3 - Top 3 Idéias \n4 - Simular Vencedor \n5 - Sair");
              Console.Write(">> ");
              respostaUsuarioOpcoes = int.Parse(Console.ReadLine());

              if (respostaUsuarioOpcoes < 1 && respostaUsuarioOpcoes > 5) {
                throw new ArgumentException();
              }

              switch (respostaUsuarioOpcoes) {
                case 1:
                  Console.Write("Titulo da Ideia >> ");
                  registraTitulo = Console.ReadLine();

                  Console.Write("Descrição da Ideia >> ");
                  registraDescricao = Console.ReadLine();

                  Console.Write("Área da Ideia >> ");
                  registraArea = Console.ReadLine();

                  Ideias = new Projetos(registraTitulo, registraDescricao, registraArea, Repositorio.Count, ListaUsuarios[usuarioLogado].getNomeUsuario());

                  Repositorio.Add(Ideias);

                  Console.WriteLine("Ideia Criada com sucesso!!");
                  Pausa();

                  Repositorio[Repositorio.Count - 1].mostraRepositorio();
                  Console.Clear();
                  break;

                case 2:
                  Console.Clear();
                  Console.WriteLine("Lista de Idéias");
                  Console.WriteLine("As idéias estão organizadas da mais votada até a menos votada.\n");
                  for (int c = 0; c < Repositorio.Count; c++) {
                    Repositorio[c].mostraRepositorio();
                    Console.WriteLine("-----------------------------");
                  }
                  Console.Write("\nDigite o indice da Idéia que deseja votar >> ");
                  respostaUsuarioVoto = int.Parse(Console.ReadLine());

                  if (respostaUsuarioVoto >= Repositorio.Count) {
                    Console.Write("Índice inválido!! ");
                    Console.WriteLine("Seu voto não foi computado!!");
                    Pausa();
                  }

                  else {
                    Repositorio[respostaUsuarioVoto].setVotosTotais();
                    Console.WriteLine("Voto computado com sucesso!!");
                    totalGeralVotos++;
                    Pausa();
                  }
                  break;

                case 3:
                  primeiroLugar = 0;
                  segundoLugar = 0;
                  terceiroLugar = 0;

                  if (Repositorio.Count >= 3) {
                    Console.Clear();
                    for (int d = 0; d < Repositorio.Count; d++) {
                      if (Repositorio[primeiroLugar].getVotosTotais() < Repositorio[d].getVotosTotais()) {
                        primeiroLugar = d;
                      }
                    }

                    if (segundoLugar == primeiroLugar) {
                      segundoLugar = segundoLugar + 1;
                    }

                    for (int e = 0; e < Repositorio.Count; e++) {
                      if (Repositorio[segundoLugar].getVotosTotais() < Repositorio[e].getVotosTotais() && Repositorio[e].getVotosTotais() != Repositorio[primeiroLugar].getVotosTotais()) {
                        segundoLugar = e;
                      }
                    }

                    if (terceiroLugar == primeiroLugar) {
                      terceiroLugar = terceiroLugar + 1;
                    }

                    if (terceiroLugar == segundoLugar) {
                      terceiroLugar = terceiroLugar + 1;
                    }
                    //Console.WriteLine(primeiroLugar);
                    //Console.WriteLine(segundoLugar);
                    //Console.WriteLine(terceiroLugar);

                    for (int f = 0; f < Repositorio.Count; f++) {
                      if (Repositorio[terceiroLugar].getVotosTotais() < Repositorio[f].getVotosTotais() && Repositorio[f] != Repositorio[primeiroLugar] && Repositorio[f].getVotosTotais() != Repositorio[segundoLugar].getVotosTotais()) {
                        terceiroLugar = f;
                      }
                    }

                    
                    Console.WriteLine("----- Top 3 -----");

                    Repositorio[primeiroLugar].mostraRepositorio();
                    Console.WriteLine("-----------------------------");

                    Repositorio[segundoLugar].mostraRepositorio();
                    Console.WriteLine("-----------------------------");

                    Repositorio[terceiroLugar].mostraRepositorio();
                    Console.WriteLine("-----------------------------");
                    Pausa();
                    break;
                  }

                  else {
                    Console.WriteLine("Ainda não existem 3 ideias registradas!!!");
                    Pausa();
                    break;
                  }
                case 4:
                  Console.Clear();
                  for (int h = 0; h < Repositorio.Count; h++) {
                    if (Repositorio[ideiaVencedora].getVotosTotais() < Repositorio[h].getVotosTotais()) {
                      ideiaVencedora = h;
                    }
                  }

                  Console.WriteLine("------ Vencedor -----");
                  Console.WriteLine("A ideia vencedora foi a:");
                  Repositorio[ideiaVencedora].mostraRepositorio();

                  Console.WriteLine($"\n Com {Repositorio[ideiaVencedora].getVotosTotais()} Likes a ideia recebera {Math.Pow((Repositorio[ideiaVencedora].getVotosTotais() / totalGeralVotos), 2) * 30000)}R$ de doação!!");

                  Pausa();
                  break;
                case 5:
                  sentinelaMenuOpcoes = true;
                  break;
              }


            }

            else if (usuarioValidoLogin == false) {
              Console.WriteLine("Erro");
            }
          }
        }
      }

      catch (ArgumentException) {
        Console.WriteLine("Resposta Inválida!!");
      }
    }
  }

  public static void Pausa () {
    Console.Write("Aperte enter para continuar...");
    Console.ReadLine();
  }
}