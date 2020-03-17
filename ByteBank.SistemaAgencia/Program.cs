using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            Lista<int> idades = new Lista<int>();

            Console.ReadLine();
        }

        static void ArrayDeInteiros()
        {
            /*ARRAY de Inteiros, com 5 posiçoes! */
            int[] idades = new int[5];

            idades[0] = 15;
            idades[1] = 25;
            idades[2] = 35;
            idades[3] = 45;
            //idades[4] = 28;
            /*Ao acessar algum valor em um indice não atribuido, o resultado se torna 0. pois por vlor padrao todosos indices criados são
             atribuidos por 0*/
            int idadeNoIndice4 = idades[3];

            /*O array é um tipo de referencia ou seja o que fica dentro de sua variavel não é o valor do tipo inteiro e sim a refencia (endereço)
             aonde está o valor. Sendo assim é possivel eu passar todos os dados de uma referencia para outro como no exemplo abaixo. ao realizar 
             esta ação a variavel "outroArray" recebe o endereço detodasas variaveis de "idades". 
             */
            int[] outroArray = idades;



            Console.WriteLine(idadeNoIndice4);
            Console.WriteLine(outroArray[3]);
        }

        static void ArrayDeBoleano()
        {
            /*Também é possivel criar um array de boleanos. */
            bool[] arrayDeBoleanos = new bool[10];

            arrayDeBoleanos[0] = true;
            arrayDeBoleanos[1] = false;
            arrayDeBoleanos[2] = false;
            arrayDeBoleanos[3] = true;

            Console.WriteLine(arrayDeBoleanos[3]);

        }

        static void ArrayMedia()
        {
            /*ARRAY de Inteiros, com 5 posiçoes! */
            //int[] idades = new int[5];

            //idades[0] = 15;
            //idades[1] = 28;
            //idades[2] = 35;
            //idades[3] = 50;
            //idades[4] = 28;

            //Ou pode criar desta maneira
            int[] idades = new int[] { 15, 28, 35, 50, 25 };

            int acumulador = 0;
            for (int indice = 0; indice < idades.Length; indice++)
            {
                int idade = idades[indice];

                Console.WriteLine($"Acessando o array idades no indíce {indice}");
                Console.WriteLine($"Valor de idades[{indice}] = {idade}");
                
                /*Ele vai somando as idades dos indices, acumulando seus valores*/
                acumulador+=idade;
            }

            /*A propriedade "Length" me retorna o tamanho do array, ou seja o numero de indices que ele possui*/
            double media = acumulador / idades.Length;
            Console.WriteLine($"Media de idades: {media}");
        }
        static void TestaArrayContaCorrente()
        {
            /*Desta forma de inicializar o array não se torna nescessario colocar o numero de arrays, pois o proprio compilador 
             * já faz isto para nós. O tamanho do array será sempre a quantidade de objetos instanciados. */

            ContaCorrente[] contas = new ContaCorrente[]
            {
                new ContaCorrente(1621,45896),
                new ContaCorrente(1456,78564),
                new ContaCorrente(4789,15466)
            };

            for (int indice = 0; indice < contas.Length; indice++)
            {
                Console.WriteLine($"Conta : {indice}  {contas[indice].Numero}");
            }
        }

        static int SomarVarios(params int[] valor)
        {
            int soma=0;
            foreach (int numero in valor)//Na Primeira variavel vai o indice que está dentro do array valor
            {
                soma += numero;
            }
            return soma;
        }

        static void TestaListaContaCorrente()
        {
            ListaDeContaCorrente lista = new ListaDeContaCorrente(14);
            ContaCorrente contaAnderson = new ContaCorrente(121212, 121212);
            //ContaCorrente[] contas = new ContaCorrente[]
            //{
            //    new ContaCorrente(824,45698),
            //    new ContaCorrente(824,45698),
            //    new ContaCorrente(824,45698),
            //    new ContaCorrente(824,45698),
            //    contaAnderson
            //};
            //OU PODEMOS ADICIONAR AS CONTAS CORRENTES DA SEGUINTE MANEIRA
            lista.AdicionarVarios(contaAnderson,
                new ContaCorrente(824, 45698),
                new ContaCorrente(824, 45698),
                new ContaCorrente(824, 45698),
                new ContaCorrente(824, 45698)
                );

            lista.Listarcontas();
        }
        static void testaListaDeObject()
        {
            ListaDeObject listaDeidades = new ListaDeObject();
            listaDeidades.AdicionarVarios(10, 5, 4, 10, 45);
            listaDeidades.Adicionar(10);

            for (int i = 0; i < listaDeidades.Tamanho; i++)
            {
                int idade = (int)listaDeidades[i];
                Console.WriteLine($"Idade no indice {i} : {idade}");
            }
        }
    }
}
