using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    class Foreach_params
    {
        /*
          FOREACH
          "foreach": para cada
         
         O que faz a instrução foreach ?

        A instrução foreach executa uma instrução ou um bloco de instruções para cada elemento em uma instância.
        por exemplo se há um array de 50 posiçoes para cada posição ele execulta um bloco de codigo.
        Sintaxe:
        
        int soma;
         foreach (int numero in valor)
            {
                soma += numero;
            }

        no exemplo a cima por exemplo o "valor" seria um array de "n" posiçoes, e a variavel int "numero" seria cada posição
        deste array "valor". Para cada indice presente na variavel "numero" ele irá execultar o bloco de instruçoes.
        Neste exemplo ele estpa somando todos os numeros presentes dentro do array na variavel soma.

    //--------------------------------------------------------------------------------------------------------------------------------------------

        PARAMS
        "params" = Parametros
        
        Usando a palavra-chave params, você pode especificar um parâmetro do método que aceita um número variável de argumentos.
        Atraves desta palavra reservada torna possivel adicionar varios paramentros (infinitos) sem precisar realizar
        varias sobrecargas para adicionar argumentos em um metodo.

        Sintaxe:

        public int SomarVarios(params int[] valor)
        {
            
        }
        
        Atravez da palavra reservada params eu estou disendo para o compilador que a variavel de array "valor", poderá receber
        varios parametros. E desta forma o compilador ja cria este array para mim por exemplo:

                                                    SomarVarios(10,10,10,5,2)
                                                         ^
                                                          `_nesteMetodo

        Neste metodo a cima o compilador entende que eu adicionei 5 parametros, desta forma ele automaticamente já cria um array de 5 posiçoes
        e devolve um array de 5 posiçoes para o metodo.


    //--------------------------------------------------------------------------------------------------------------------------------------------
        FOREACH JUNTO COM PARAMS
        
        Podemos fazer muitas coisas legais com a união destas duas palavras reservadas como no metodo abaixo.


         public int SomarVarios(params int[] valor)
        {
            int soma=0;
            foreach (int numero in valor)//Na Primeira variavel vai o indice que está dentro do array valor
            {
                soma += numero;
            }
            return soma;
        }

        Atravez do |-->params<--| um array com o nome "valor" é criado, depois que ja possuimos o array
        vamos para a linha do |-->foreach<--| (para cada), e estamos querendo diser para o compilador
        para cada indice na variavel "numero" no array "valor", some este numero com o anterior na variavel "soma".
        desta forma conseguimos construir um metodo que soma todos os valores presentes no array. E retornamos este somatorio
        atraves do return;

         */

    }
}
