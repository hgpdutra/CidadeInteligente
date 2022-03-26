using CidadeInteligente.Dominio.Interfaces;
using CidadeInteligente.Infraestrutura.Config;
using Microsoft.EntityFrameworkCore;

namespace CidadeInteligente.Infraestrutura.Repositorio
{
    public class RepositorioBase<T> : IBase<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<CidadeInteligenteDbContext> _optionsBuilder;

        public RepositorioBase()
        {
            _optionsBuilder = new DbContextOptions<CidadeInteligenteDbContext>();
        }

        public void Adicionar(T obj)
        {
            using (var db = new CidadeInteligenteDbContext(_optionsBuilder))
            {
                db.Set<T>().Add(obj);
                db.SaveChanges();

                //throw new NotImplementedException();
            }
        }
        public void Atualizar(T obj)
        {
            using (var db = new CidadeInteligenteDbContext(_optionsBuilder))
            {
                db.Set<T>().Update(obj);
                db.SaveChanges();
            }

            //throw new NotImplementedException();
        }

        public void Excluir(T obj)
        {
            using (var db = new CidadeInteligenteDbContext(_optionsBuilder))
            {
                db.Set<T>().Remove(obj);
                db.SaveChanges();
            }

            //throw new NotImplementedException();
        }

        public IList<T> Listar()
        {
            using (var db = new CidadeInteligenteDbContext(_optionsBuilder))
            {
                return db.Set<T>().AsNoTracking().ToList();
            }

            //throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        /*
        public T RecuperarPorId(Guid id)
        {
            throw new NotImplementedException();
        }
        */
    }
}

        
