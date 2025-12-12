using Hillerød_Sejlklub.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub.Repositories
{
    public class MemberRepository : IUserRepository
    {
        private readonly Dictionary<string, Member> _members;

        public MemberRepository()
        {
            _members = new Dictionary<string, Member>
        {
                {"Jan", new Member("Jan", 52,  110100, "JanErSej@gmail.com", 20202020) },
                {"Erik", new Member("Erik", 67,  110101, "ErikErSej@gmail.com", 20202021) },
                {"Buller", new Member("Buller", 55,  110102, "BullerErSej@gmail.com", 20202022) }
        };

        }


        public Member Add(Member member)
        {
            _members.Add(member.Name, member);
            return member;
        }

        public bool Delete(string memberName)
        {
            if (_members.Remove(memberName))
            {
                return true;
            }

            else { throw new Exception($"{memberName} could not be found"); }
        }

        public List<Member> GetAll()
        {
            return _members.Values.ToList();
        }
        public Member GetByName(string name)

        {
            if (_members.TryGetValue(name, out var member))
                return member;
            return null;
        }

        public Member Update(Member member, string key, string name)
        {
            _members[key].Name = name;
            var updatedMember = Add(member);

            return updatedMember;
        }

        List<Member> IUserRepository.GetAll()
        {
            return _members.Values.ToList();
        }
    }
}
