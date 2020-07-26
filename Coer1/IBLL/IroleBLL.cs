using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IBLL
{
    public interface IroleBLL
    {
        List<roleModel> FenYe(FenYeModel fen);
        Task<List<roleModel>> RoleSelect();
        Task<int> ADD(roleModel bjm);
        Task<int> Delete(int id);
        Task<roleModel> Select(int id);
        Task<int> Update(roleModel rb);
    }
}
