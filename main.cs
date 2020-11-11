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
              Console.WriteLine($"Bem-Vindo(a) {ListaUsuarios[usuarioLogado].getNomeUsuario()}\n");

              Console.WriteLine("O que deseja fazer?");
              Console.WriteLine("1 - Cadastrar uma Idéia \n2 - Votar em Idéias \n3 - Top 3 Idéias \n3 - Sair");
              Console.Write(">> ");
              respostaUsuarioOpcoes = int.Parse(Console.ReadLine());

              if (respostaUsuarioOpcoes < 1 && respostaUsuarioOpcoes > 4) {
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
                  Console.WriteLine("Lista de Idéias\n");
                  for (int c = 0; c < Repositorio.Count; c++) {
                    Repositorio[c].mostraRepositorio();
                    Console.WriteLine("------------------------");
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
                  }
                  break;
                
                case 4:
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