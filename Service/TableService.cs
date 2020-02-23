
using AutoMapper;
using DAL.Interfaces;
using Entity;
using Service.Domains;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Service
{
    public class TableService : ITableService
    {
        private ITableRepository tableRepository { get; set; }
        private IMapper mapper { get; set; }
        private IUnitOfWork unitOfWork;

        public TableService(ITableRepository tableRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.tableRepository = tableRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public bool Add(TableDomain domain)
        {
            tableRepository.Add(mapper.Map<Counter>(domain));
            unitOfWork.Commit();
            return true;
        }

        public bool Delete(TableDomain domain)
        {
            Counter counter = mapper.Map<Counter>(domain);
            tableRepository.Delete(tableRepository.GetById(counter.Id));
            unitOfWork.Commit();
            return true;
        }

        public IEnumerable<TableDomain> GetAll()
        {
            return mapper.Map<IEnumerable<TableDomain>>(tableRepository.GetAll());
        }

        public TableDomain GetById(int id)
        {
            return mapper.Map<TableDomain>(tableRepository.GetById(id));
        }

        public IEnumerable<TableDomain> GetMany(Expression<Func<TableDomain, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Update(TableDomain domain)
        {
            Counter updatedCounter = mapper.Map<Counter>(domain);
            Counter counter = tableRepository.GetById(updatedCounter.Id);

            counter.Name = updatedCounter.Name;
            tableRepository.Update(counter);

        }
    }
}
