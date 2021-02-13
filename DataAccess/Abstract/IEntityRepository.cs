using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    // T'ye kısıtlama getirme : generic constraint
    // T, class yani refereans tip olabilir ve T ya IEntity ya da IEntity den implemente bir şey olabilir
    //new(), new lenebilir olmalı, IEntity new lenemez, interface new lenemez
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        // ister datanın hepsini getir ister filtreleyerek getirme için (expression)
        // filter = null demek filtre yok hepsini getir
        List<T> GetAll(Expression<Func<T,bool>> filter = null); //expression verme 
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAllByCategory(int categoryId);
    }
}
