using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClubeLeitura.ConsoleApp.Compartilhado;
using System;

namespace ClubeLeitura.ConsoleApp.ModuloAmigo
{
    public class TelaCadastroAmigo
    {

        public int numeroAmigo;
        public Notificador notificador;
        public RopositorioAmigo repositorioAmigo;

        public string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Amigo");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void InserirNovoAmigo()
        {
            MostrarTitulo("Inserindo nova Amigo");

            Amigo novoAmigo = ObterAmigo();

            repositorioAmigo.Inserir(novoAmigo);

            notificador.ApresentarMensagem("Amigo inserido com sucesso!", "Sucesso");
        }



        public void EditarAmigo()
        {
            MostrarTitulo("Editando Amigo");

            bool temAmigosCadastrados = VisualizarAmigos("Pesquisando");

            if (temAmigosCadastrados == false)
            {
                notificador.ApresentarMensagem("Nenhuma amigo cadastrado para poder editar", "Atencao");
                return;
            }

            int numeroAmigo = ObterNumeroAmigo();

            Amigo amigoAtualizado = ObterAmigo();

            repositorioAmigo.Editar(numeroAmigo, amigoAtualizado);

            notificador.ApresentarMensagem("Amigo editado com sucesso", "Sucesso");
        }
        public int ObterNumeroAmigo()
        {
            int numeroAmigo;
            bool numeroAmigoEncontrado;

            do
            {
                Console.Write("Digite o número do amigo que deseja editar: ");
                numeroAmigo = Convert.ToInt32(Console.ReadLine());

                numeroAmigoEncontrado = repositorioAmigo.VerificarNumeroAmigoExiste(numeroAmigo);

                if (numeroAmigoEncontrado == false)
                    notificador.ApresentarMensagem("Número de amigo não encontrado, digite novamente", "Atencao");

            } while (numeroAmigoEncontrado == false);
            return numeroAmigo;
        }

        public void ExcluirAmigo()
        {
            MostrarTitulo("Excluindo Amigo");

            bool temAmigosCadastrados = VisualizarAmigos("Pesquisando");

            if (temAmigosCadastrados == false)
            {
                notificador.ApresentarMensagem(
                    "Nenhum amigo cadastrado para poder excluir", "Atencao");
                return;
            }

            int numeroAmigo = ObterNumeroAmigo();

            repositorioAmigo.Excluir(numeroAmigo);

            notificador.ApresentarMensagem("Amigo excluído com sucesso", "Sucesso");
        }

        public bool VisualizarAmigos(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização de Amigos");

            Amigo[] amigos = repositorioAmigo.SelecionarTodos();

            if (amigos.Length == 0)
                return false;

            for (int i = 0; i < amigos.Length; i++)
            {
                Amigo a = amigos[i];

                Console.WriteLine("Nome: " + a.nome);
                Console.WriteLine("Responsavel: " + a.nomeResponsalvel);
                Console.WriteLine("Telefone: " + a.telefone);
                Console.WriteLine("Endereço: " + a.endereço);

                Console.WriteLine();
            }

            return true;
        }

        public Amigo ObterAmigo()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o nome do responsavel: ");
            string nomeResponsalvel = Console.ReadLine();

            Console.Write("Digite o endereço: ");
            string endereço = Console.ReadLine();

            Console.Write("Digite o telefone: ");
            string telefone = Console.ReadLine();

                       

            Amigo amigo = new Amigo();

            amigo.nome = nome;
            amigo.nomeResponsalvel = nomeResponsalvel;
            amigo.endereço = endereço;
            amigo.telefone = telefone;


            return amigo;
        }

        public void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();
        }


    }
}
