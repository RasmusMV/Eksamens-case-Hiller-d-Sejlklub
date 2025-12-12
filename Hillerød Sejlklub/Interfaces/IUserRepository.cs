using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub.Interfaces
{
    public interface IUserRepository
    {
        public Member Add(Member member);
        public void UpdateMemberName(string key, string name);
        public bool Delete(string memberName);
        public Member GetByName(string name);
        public List<Member> GetAll();



    }
}