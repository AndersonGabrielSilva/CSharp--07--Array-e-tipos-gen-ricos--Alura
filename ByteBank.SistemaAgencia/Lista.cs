using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    /*Ésta não é uma lista comum, é uma classe generica. Que ainda não póssui algum tipo, para se trabalhar.
     seu tipo sera informado no momento da execulção e substitituira por "T".*/
   public class Lista<T>
    {

        private T[] _itens;

        private int _proximaPosicao;

        public int Tamanho
        {
            get
            {
                return _proximaPosicao;
            }
        }

        public Lista(int capacidadeInicial = 5)
        {

            _itens = new T[capacidadeInicial];
            _proximaPosicao = 0;
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------
        public void Remover(T item)
        {
            int indiceItem = -1;
            for (int i = 0; i < _proximaPosicao; i++)
            {
                T itemAtual = _itens[i];

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

            _proximaPosicao--;
            //_itens[_proximaPosicao] = null;

        }
        //--------------------------------------------------------------------------------------------------------------------------------------------

        public T GetNoIndice(int indice)
        {
            if (indice < 0 || indice >= _proximaPosicao)
            {

                throw new ArgumentOutOfRangeException(nameof(indice));
            }

            return _itens[indice];

        }
        //--------------------------------------------------------------------------------------------------------------------------------------------

        public void Adicionar(T item)
        {

            VerificarCapacidade(_proximaPosicao + 1);

            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------
        public void AdicionarVarios(params T[] contasItens)
        {

            foreach (T item in contasItens)
            {
                Adicionar(item);
            }

        }
        //--------------------------------------------------------------------------------------------------------------------------------------------
        private void VerificarCapacidade(int tamanhoNecessario)
        {

            if (_itens.Length >= tamanhoNecessario)
            {
                return;
            }


            int novoTamanho = tamanhoNecessario * 2;
            if (novoTamanho < tamanhoNecessario)
            {
                novoTamanho = tamanhoNecessario;
            }


            T[] outroArray = new T[novoTamanho];

            for (int indice = 0; indice < _itens.Length; indice++)
            {
                outroArray[indice] = _itens[indice];

            }


            _itens = outroArray;

        }

        //--------------------------------------------------------------------------------------------------------------------------------------------
        
        public T this[int indice]
        {
            get
            {
                return GetNoIndice(indice);
            }
            set
            {

            }
        }

    }
}
