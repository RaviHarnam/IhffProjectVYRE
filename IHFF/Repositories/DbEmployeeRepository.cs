using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF.Models;

namespace IHFF.Repositories
{
    public class DbEmployeeRepository : IEmployeeRepository
    {
        private IhffContext ctx = new IhffContext();

        public bool EmployeeExist(Employee emp)
        {
            Employee e = (from em in ctx.EMPLOYEES
                          where em.Gebruikersnaam == emp.Gebruikersnaam && em.Wachtwoord == emp.Wachtwoord
                          select em).SingleOrDefault();
            return (e != null);
        }
    }
}