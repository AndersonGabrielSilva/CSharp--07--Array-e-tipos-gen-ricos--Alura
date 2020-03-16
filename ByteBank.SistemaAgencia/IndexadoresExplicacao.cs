using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    class IndexadoresExplicacao
    {

        /*Antes de tentarmos acessar os itens da nossa lista da mesma forma que em um array, vamos imaginar como faríamos
         * isso usando outros recursos que já aprendemos.

            No caso, vamos escrever um método chamado GetItemNoIndice(). Na nossa classe ListaDeContaCorrente, 
            vamos apagar o método EscreverListaNaTela() e colocar o nosso novo método.
            
            Precisaremos verificar os valores do nosso índice, que não pode ser negativo, certo? Portanto, 
            quando if(indice < 0), lançaremos uma nova exceção ArgumentOutOfRangeException - ou seja, o argumento está 
            fora do nosso intervalo permitido. Entre parênteses, vamos usar o nome do argumento, que é nameof(indice).
            
            public ContaCorrente GetContaCorrenteNoIndice(int indice)
            { 
                if(indice < 0)
                { 
                    throw new ArgumentOutOfRangeException(nameof(indice));
                } 
            }


            Agora temos um índice positivo, mas também não podemos ter um índice maior ou igual a _proximaPosicao. 
            Vamos adicionar isso:
            
            if(indice < 0 || indice >= _proximaPosicao)
            Dessa forma temos um valor permitido, e basta usarmos a instrução return do nosso itens no índice que recebemos por argumento:
            
            public ContaCorrente GetContaCorrenteNoIndice(int indice)
            {
                if(indice < 0 || indice >= _proximaPosicao)
                {
                    throw new ArgumentOutOfRangeException(nameof(indice));
                }
            
                return _itens[indice];
            }

            Para que possamos iterar por todos os itens dessa lista, precisamos saber qual é o tamanho dela. 
            Então, criaremos uma propriedade que indica o número de itens nessa lista - mas não o número de itens que são comportados no 
            nosso array, pois isso não é uma preocupação do usuário da nossa classe.
            
            Tamanho é uma propriedade que só vai ter um get, pois um código externo não deve alterar o tamanho de uma lista. 
            Se repararmos bem, a nossa _proximaPosicao coincide com o número de elementos que já existem no nosso array.
            Por exemplo, em um array com 3 itens, a _proximaPosicao livre também será 3. Portanto, teremos:
            
            public int Tamanho 
            { 
                get 
                {
                    return _proximaPosicao; 
                }
            } 

            Agora, na nossa classe Program, podemos iterar com for(int i = 0; i < lista.Tamanho; i++) e pegar o i-ésimo item dessa lista.
            Para verificarmos se nosso código está funcionando, vamos chamar o método Console.WriteLine() com os identificadores que criamos
            para conta-corrente:
            
            for(int i = 0; i < lista.Tamanho; i++) 
            { 
                ContaCorrente itemAtual = lista.GetContaCorrenteNoIndice(i);
                Console.WriteLine($"Item na posição {i} = Conta {itemAtual.numero}/{itemAtual.Agencia}");
            } 

            Para nossa tela não ficar muito poluída, no nosso método Adicionar(), vamos comentar as linhas referentes aos recursos que 
            já testamos antes:
            
            Console.WriteLine($"Adicionando item na posição {_proximaPosicao}")
            Console.WriteLine("Aumentando a capacidade da lista!")
            Console.WriteLine(".")
            Clicando em "Iniciar", o programa irá imprimir na tela:
            
            Item na posição 0 = Conta 1111111/11111
            
            Item na posição 1 = Conta 5679787/874
            
            Item na posição 2 = Conta 5679754/874
            
            Item na posição 3 = Conta 5679445/874
            
            Item na posição 4 = Conta 5679445/874
            
            Item na posição 5 = Conta 5679445/874
            
            Item na posição 6 = Conta 5679445/874
            
            (...)
            
            Como podemos ver, ele está funcionando da forma que esperávamos. Com isso, acessamos os itens da nossa lista da forma convencional.
            Mas e se quiséssemos acessar esses itens da mesma forma que fazemos com arrays - ou seja, com o índice entre colchetes (lista[i])?
            
            Isso não seria possível exatamente dessa forma, pois o compilador apontará um erro. Porém, é possível, na nossa classe, 
            implementar um "método" que funcione dessa maneira. Mas será mesmo um método?
            
            Quando testamos nosso array, utilizamos os colchetes ([]) para recuperar um item e para definir o valor de um item em uma posição
            do nosso array, o que se assemelha menos a um método, e mais a uma propriedade, com get e set.
            
            Então, vamos começar a construir uma propriedade pública que irá retornar um tipo ContaCorrente. Em seguida, colocaríamos o 
            nome da nossa propriedade/método. Ao invés disso, vamos escrever this.
            
            public ContaCorrente this 
            Se this fosse um método, colocaríamos os argumentos entre parênteses. No entanto, usaremos colchetes, pois não queremos 
            tratar this como um método, mas sim como um indexador. Dado que o índice de um item é definido por um int, colocaremos int 
            indice entre os colchetes:
            
            public ContaCorrente this[int indice]
            O Visual Studio irá apontar vários erros, mas logo iremos resolvê-los. Vimos que, por meio de um array, temos a opção de setar,
            ou definir (set), usando o sinal de igual, e também de recuperar (get). Faremos isso também no indexador que estamos criando:
            
            public ContaCorrente this[int indice]
            {
                get 
                {
            
                }
                set
                {
            
                }
            }

            No get, faremos o mesmo que escrevemos anteriormente em GetContaCorrenteNoIndice(). Para melhorarmos este nome, vamos mudá-lo
            para GetItemNoIndice(). Perceba que, se mudarmos o nome de um método público, iremos quebrar o código de quem está usando-o.
            
            Porém, usando o Visual Studio 2017, podemos pressionar "Ctrl + ." e clicar na função "Renomear "GetContaCorrenteNoIndice" 
            para "GetItemNoIndice"". Quando usamos essa função, o Visual Studio renomeia também os outros lugares do nosso código que
            estão usando o método com o nome antigo.
            
            O nosso get deve retornar GetItemNoIndice no índice que recebemos em int indice. Dessa forma, temos:
            
            public ContaCorrente this[int indice]
            {
                get 
                {
                    return GetItemNoIndice(indice);
                }
                set
                {
            
                }
            }

            Será que nossa lista deve ter um set pelo índice? Como estamos abstraindo essa questão de adicionar ou remover um item,
            talvez esse set não seja necessário, portanto iremos removê-lo. Agora dispomos de um indexador que tem somente o get - 
            inclusive, indexador é exatamente o nome da sintaxe que acabamos de criar (que se assemelha tanto a um método como a uma propriedade).
            
            public ContaCorrente this[int indice]
            {
                get 
                {
                    return GetItemNoIndice(indice);
                }
            }

            Nosso indexador recebe um int, mas também poderíamos criar, por exemplo, um indexador que recebe uma string. Em seguida, 
            escrevemos return null somente para nosso código ser compilado:
            
            public ContaCorrente this[string texto]
            {
                get
                { 
                    return null;
                } 
            }

            No momento em que criamos um indexador que recebe um int, o código que criamos (acessando a lista da mesma forma que acessamos 
            um array) passou a funcionar.
            
            Porém, se tentarmos definir algum valor em um índice qualquer dessa lista (por exemplo, lista[4234] = null, o compilador não 
            irá permitir, afinal não escrevemos o set, somente o get.
            
            Para testarmos como funcionam os indexadores, vamos utilizar o indexador que recebe uma string:
            
            for(int i = 0; i < lista.Tamanho; i++)
            {
            
                ContaCorrente teste = lista["texto"];
            
                ContaCorrente itemAtual = lista[i];
                Console.WriteLine($"Item na posição {i} = Conta {itemAtual.Numero}/{itemAtual.Agencia}");
            }


            Como podemos ver, esse código também funciona, e podemos, por meio do indexador, acessar um item utilizando qualquer tipo de índice.
            Porém, como não iremos implementar a chave de texto, removeremos o indexador que recebe um string, mantendo somente o indexador que 
            recebe um número inteiro (int).
            
            Repare que, quando removemos esse indexador, o código para de compilar! Portanto, devemos remover também ContaCorrente 
            teste = lista["texto"].
            
            Agora vamos executar o código para termos certeza de que ele está funcionando. Clicando em "Iniciar", o programa irá imprimir na tela:
            
            Item na posição 0 = Conta 1111111/11111
            
            Item na posição 1 = Conta 5679787/874
            
            Item na posição 2 = Conta 5679754/874
            
            Item na posição 3 = Conta 5679445/874
            
            Item na posição 4 = Conta 5679445/874
            
            Item na posição 5 = Conta 5679445/874
            
            Item na posição 6 = Conta 5679445/874
            
            (...)
            
            Ou seja, ele funcionou da mesma forma. Porém, dessa vez estamos usando um recurso interessante da linguagem C#,
            que é o acesso por meio de índices.*/

    }
}
