using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using DBWrapper.Entities;

namespace DBWrapper
{
    [DataContract]
    public class Users2
    {
        [DataMember] 
        public List<User2> UsersList;
    }

    [DataContract]
    public class User2
    {
        [DataMember]
        private readonly int _id;
        [DataMember]
        private readonly short? _userRights;
        [DataMember]
        private string _userName;

        public User2(UserData userData)
        {
            _id = userData.UserId;
            _userRights = userData.Rights;
            _userName = userData.Name;
        }

        public User2(int id, short userRights)
        {
            _id = id;
            _userRights = userRights;
        }

        [DataMember]
        public short? UserRights
        {
            get { return _userRights; }
        }

        [DataMember]
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        [DataMember]
        public int Id
        {
            get { return _id; }
        }
    }
}
