using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IBLL;
using IDAO;
using Model;

namespace BLL
{
    public class roleBLL : IroleBLL
    {
        private readonly IroleDAO rd;
        public roleBLL(IroleDAO rd)
        {
            this.rd = rd;
        }
        public Task<int> ADD(roleModel bjm)
        {
            return rd.ADD(bjm);
        }

        public Task<int> Delete(int id)
        {
            return rd.Delete(id);
        }

        public List<roleModel> FenYe(FenYeModel fen)
        {
            return rd.FenYe(fen);
        }

        public Task<List<roleModel>> RoleSelect()
        {
            return rd.RoleSelect();
        }

        public Task<roleModel> Select(int id)
        {
            return rd.Select(id);
        }

        public Task<int> Update(roleModel rb)
        {
            return rd.Update(rb);
        }
    }
}
