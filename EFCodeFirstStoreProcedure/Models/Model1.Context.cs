﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFCodeFirstStoreProcedure.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class StoreProcedureDBEntities : DbContext
    {
        public StoreProcedureDBEntities()
            : base("name=StoreProcedureDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Employee> Employees { get; set; }
    
        public virtual ObjectResult<sp_getEmp_Result> sp_getEmp()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getEmp_Result>("sp_getEmp");
        }
    
        public virtual int sp_insertEmp(string name, string fname, Nullable<int> salary)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var fnameParameter = fname != null ?
                new ObjectParameter("fname", fname) :
                new ObjectParameter("fname", typeof(string));
    
            var salaryParameter = salary.HasValue ?
                new ObjectParameter("salary", salary) :
                new ObjectParameter("salary", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_insertEmp", nameParameter, fnameParameter, salaryParameter);
        }
    
        public virtual ObjectResult<sp_getempbyid_Result> sp_getempbyid(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getempbyid_Result>("sp_getempbyid", idParameter);
        }
    
        public virtual int sp_update(string name, string fname, Nullable<int> salary, Nullable<int> id)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var fnameParameter = fname != null ?
                new ObjectParameter("fname", fname) :
                new ObjectParameter("fname", typeof(string));
    
            var salaryParameter = salary.HasValue ?
                new ObjectParameter("salary", salary) :
                new ObjectParameter("salary", typeof(int));
    
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_update", nameParameter, fnameParameter, salaryParameter, idParameter);
        }
    
        public virtual int sp_delete(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_delete", idParameter);
        }
    }
}
