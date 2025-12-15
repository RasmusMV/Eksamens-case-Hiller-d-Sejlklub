using Hillerød_Sejlklub.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Static fields
        private static MemberRepository _instance = null;
        #endregion
        private readonly Dictionary<string, Member> _members;

        public UserRepository()
        {
            _members = new Dictionary<string, Member>
        {
                {"Jan", new Member("Jan", new DateTime(1952,10,5), "JanErSej@gmail.com", 20202020) },
                {"Erik", new Member("Erik", new DateTime(1959, 1, 5), "ErikErSej@gmail.com", 20202021) },
                {"Buller", new Member("Buller", new DateTime (1960,6,5), "BullerErSej@gmail.com", 20202022) }
        };
      
        }          

     public static MemberRepository GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MemberRepository();
            }
            return _instance;
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

        public void UpdateMemberName(string key, string name)
        {
            _members[key].Name = name;
        }

        List<Member> IUserRepository.GetAll()
        {
            return _members.Values.ToList();
        }
    }
}
