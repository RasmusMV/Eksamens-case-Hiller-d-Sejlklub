using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub.Interfaces
{
    public interface IUserRepository
    {
        public string Name { get; set; }
        public Member Add(Member member);
        public Member Update(Member member, string key);
        public bool Delete(string memberName);
        public Member GetByName(string name);
        public List<Member> GetAll();



    }
}