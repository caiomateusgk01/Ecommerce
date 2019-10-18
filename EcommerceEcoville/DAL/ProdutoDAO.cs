using EcommerceEcoville.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceEcoville.Dao
{
    public class ProdutoDAO
    {
        private readonly Context _context;
        public ProdutoDAO(Context context)
        {
            _context = context;
        }

        public void Cadastrar(Produto p)
        {
            _context.Produtos.Add(p);
            _context.SaveChanges();
        }
        public List<Produto> ListarProdutos() => _context.Produtos.ToList();

        public  Produto BuscarProdutoId(int? id)
        {
            //FirstOrDefault : é o metodo que retorna um objeto na buca(Primeiro Objeto)
            //SingleOrDefault : é o metodo que retorna um obejo na busca(Retorna uma excesão se tiver objeto com mesmo nome)
            return _context.Produtos.Find(id);

        }


        public  void RemoverProduto(int? id)
        {
            _context.Produtos.Remove(BuscarProdutoId(id));
            _context.SaveChanges();
        }
        public void AlterarProduto(Produto p)
        {
            _context.Entry(p).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
