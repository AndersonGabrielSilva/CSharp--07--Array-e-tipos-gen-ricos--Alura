using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    class ListaDeContaCorrente
    {
        // [null][null][null][null]
        //  ^
        //   `-_proximaPosicao
    //--------------------------------------------------------------------------------------------------------------------------------------------
            
        private ContaCorrente[] _itens;

        //Aponta para proxima posição aondeo array seráadicionado 
        private int _proximaPosicao;

        /*O tamanho de um array é sempre o tamanho da proxima posição*/
        public int Tamanho 
        {
            get 
            { 
                return _proximaPosicao; 
            } 
        }
    //--------------------------------------------------------------------------------------------------------------------------------------------

        /*Argumento Opcional, o usuario podeou não informar. Casonão informe nada
         ele começara com o seu valor padrao "5"*/
        public ListaDeContaCorrente(int capacidadeInicial = 5)
        {

            _itens = new ContaCorrente[capacidadeInicial];
            _proximaPosicao = 0;
        }
    //--------------------------------------------------------------------------------------------------------------------------------------------
        public void Remover(ContaCorrente item)
        {
            int indiceItem = -1;
            for (int i = 0; i < _proximaPosicao; i++)
            {
                ContaCorrente itemAtual = _itens[i];
                
                if (itemAtual.Equals(item))
                {
                    indiceItem = i;
                    break;
                }
            }
            
            for (int i = indiceItem; i < _proximaPosicao; i++)
            {
                    _itens[i] = _itens[i + 1];
            }

                /*Ao remover um indice a ltima posição irá ficar nula. por este motivo nos aprocamos o --
                  aonde estamos decrementando a ultima posição.*/
                _proximaPosicao--;

                /*Neste local, como a ultima posição já tera algum valor dentro dela. pois movemos todos os vetoresum indice para traz.
                 * então no ultimo indice o valor sera duplicado. Para evitar isto logo apos mover todos os indices o ultimo rece o valor de Null*/
                _itens[_proximaPosicao] = null;            
            
        }
    //--------------------------------------------------------------------------------------------------------------------------------------------

       public ContaCorrente GetNoIndice(int indice)
        {
            if (indice<0 || indice >= _proximaPosicao)
            {
                /*Esta Exceção é lançada quando o argumento não está no indice do array. Como neste exemplo abaixo
                 aonde o indice é impossivel ser menor que 0.*/
                throw new ArgumentOutOfRangeException(nameof(indice));
            }

            return _itens[indice];

        }
    //--------------------------------------------------------------------------------------------------------------------------------------------

        public void Adicionar( ContaCorrente item)
        {
            /*Nesta linha abaixo ele irá verificar se há Cpacidade no vetor, se simele retorna para o adicionar, se "Não" elecria um novo vetor*/
            VerificarCapacidade(_proximaPosicao+1);
            //Console.WriteLine($"Adicionado item na posição {_proximaPosicao}");
            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
        }
    //--------------------------------------------------------------------------------------------------------------------------------------------
            public void AdicionarVarios(params ContaCorrente[] contasItens)
            {
                //"foreach" = Para cada
                /*Para cada conta em contaItens*/
                foreach(ContaCorrente conta in contasItens)
                {
                    Adicionar(conta);
                }

            }
    //--------------------------------------------------------------------------------------------------------------------------------------------
        private void VerificarCapacidade(int tamanhoNecessario)
        {
            /*Se o "tamanhoNecessario" for menor que o tamanho já estabelecido, ele para a execução do metodo 
             e não retorna nada (Não faznada)*/
            if (_itens.Length >= tamanhoNecessario)
            {
                return;
            }

            //Console.WriteLine("Aumentando a capacidade da lista!!");
            
            /*No bloco a baixo o tamanho nescessario é dobrado. Para evitar queo compilador tenha que transferir todos os valores parao novo array em 
             * todasas vezes.
             Já no vloco do "if" ele verifica se o tamanho nescessario é menor que o novo valor se sim o novoTamanho recebe o tamnho nescesario
             se não vai o calculo daoperação de cima( tamanhoNescesario * 2 ) */
            
            int novoTamanho = tamanhoNecessario * 2;
            if (novoTamanho<tamanhoNecessario)
            {
                novoTamanho = tamanhoNecessario; 
            }

            /*Se o tamanho atual do array não for o sufuciente para armazenar os valores da lista?
             Simples, criamosum outro array com o tamanho necessario para suportar estes novos itens*/
            ContaCorrente[] outroArray = new ContaCorrente[novoTamanho];
            
            for(int indice = 0; indice < _itens.Length; indice++)
            {
                outroArray[indice] = _itens[indice];
                //Console.WriteLine(".");
            }

            /*Depois de copiar todos os itens do array antigo(_itens) para  novo(outroArray) eu troco a referencia da variavel "_itens"
             * que agora a partir de agora começa a apontar para o endereço do "outroArray".  */
            _itens = outroArray;

        }

        
        /*Criando um indexador, apartir do bloco abaixo tornou possivel o uso de indexadores na classe main
         * desta maneira eu consigo acessar aminha lista como um array. Apenas indicando o indice dela. Sem precisar chamar 
         alista por um metodo.
         Desta Forma acessamos os valores de nossa lista demaneira convencional, sem precisar chamar um metodopara isto.*/
        public ContaCorrente this[int indice]
        {
            get
            {
                return GetNoIndice(indice);
            }
            set
            {

            }
        }
    //--------------------------------------------------------------------------------------------------------------------------------------------

        public void Listarcontas()
        {
            foreach (ContaCorrente contaLista in _itens)
            {
                if (contaLista!=null)
                {
                    Console.WriteLine($"Conta: {contaLista.Agencia}/{contaLista.Numero}");
                }
            }
        }

    //--------------------------------------------------------------------------------------------------------------------------------------------

    }
}
