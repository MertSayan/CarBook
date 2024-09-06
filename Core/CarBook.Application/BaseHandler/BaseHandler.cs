using CarBook.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.BaseHandler
{
    public class BaseHandler <T> where T : class
    {
        protected readonly IRepository<T> _repository;

        public BaseHandler(IRepository<T> repository)
        {
            _repository = repository;
        }
    }
}
