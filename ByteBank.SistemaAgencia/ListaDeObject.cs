using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class ListaDeObject
    {
        //Para gerar uma lista generica é só criaruma lista do tipo Object
        
        private object[] _itens;

        private int _proximaPosicao;

        public int Tamanho
        {
            get
            {
                return _proximaPosicao;
            }
        }
       
        public ListaDeObject(int capacidadeInicial = 5)
        {

            _itens = new object[capacidadeInicial];
            _proximaPosicao = 0;
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------
        public void Remover(object item)
        {
            int indiceItem = -1;
            for (int i = 0; i < _proximaPosicao; i++)
            {
                object itemAtual = _itens[i];

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

            
            _itens[_proximaPosicao] = null;

        }
        //--------------------------------------------------------------------------------------------------------------------------------------------

        public object GetNoIndice(int indice)
        {
            if (indice < 0 || indice >= _proximaPosicao)
            {
                
                throw new ArgumentOutOfRangeException(nameof(indice));
            }

            return _itens[indice];

        }
        //--------------------------------------------------------------------------------------------------------------------------------------------

        public void Adicionar(object item)
        {
           
            VerificarCapacidade(_proximaPosicao + 1);
            
            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------
        public void AdicionarVarios(params object[] contasItens)
        {
           
            foreach (object item  in contasItens)
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


            object[] outroArray = new object[novoTamanho];

            for (int indice = 0; indice < _itens.Length; indice++)
            {
                outroArray[indice] = _itens[indice];
             
            }

           
            _itens = outroArray;

        }

        //--------------------------------------------------------------------------------------------------------------------------------------------


        public object this[int indice]
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

       

        //--------------------------------------------------------------------------------------------------------------------------------------------


    }
}
