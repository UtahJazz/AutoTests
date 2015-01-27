using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DBWrapper;
using DBWrapper.Entities;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace DBWrapperTest
{
    class Program
    {
        private const string DbFile = "TestService";
        private static ISessionFactory _sessionFactory;
        private static TestSet _testSet;
        public static void Main()
        {

            _sessionFactory = CreateSessionFactory();
            AddTest();
            AddTestSet();
            AddStatistic();
            AddUniversity();
            AddUserData();
            AddGroup();

            AddFullTestSet();

            AddStatisticWithTestSetAndUserData();

            /*
            using (var session = _sessionFactory.OpenSession())
            {
                // retreive all stores and display them
                using (session.BeginTransaction())
                {
                    var tests = session.CreateCriteria(typeof(UserData)).List<UserData>();

                    foreach (var test in tests)
                    {
                        Console.WriteLine("-----");
                        Console.WriteLine(test.Name);
                    }
                }
            }*/
            _sessionFactory.Close();
            _sessionFactory.Dispose();
            Console.WriteLine("---------------------------------------------------");
            Console.ReadKey();
        }

        public static void AddStatisticWithTestSetAndUserData()
        {
            using (var session = _sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var result = new Statistic
                {
                    Mark = 5,
                    RightTasks = 5,
                    TestSet = GetTestSetById(2),
                    UserData = GetUserById(1)
                };

                session.SaveOrUpdate(result);
                transaction.Commit();
            }
        }
        public static void AddFullTestSet()
        {
            var testSet = new TestSet {Complexity = 5, Name = "Name"};
            const int userId = 1;
            var tests = new List<Test>
            {
                new Test {Answer = "Answer1", Complexity = 5, Text = "Text1"},
                new Test {Answer = "Answer2", Complexity = 5, Text = "Text2"},
                new Test {Answer = "Answer3", Complexity = 5, Text = "Text3"},
                new Test {Answer = "Answer4", Complexity = 5, Text = "Text4"},
                new Test {Answer = "Answer5", Complexity = 5, Text = "Text5"}
            };
            using (var session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var user = GetUserById(userId);
                    testSet.UserData = user;
                    user.TestSet.Add(testSet);
                    session.Save(testSet);
                    foreach (var test in tests)
                    {
                        test.TestSet = testSet;
                        if (test.Text == null)
                            throw new InvalidDataException();
                        session.SaveOrUpdate(test);
                    }
                    //TestIdentityOn(session, "TestSet");
                    transaction.Commit();
                    //TestIdentityOff(session, "TestSet");
                }
            }
        }

        private static void AddTest()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var test = new Test {Complexity = 102, Text = "33331233", Answer = "22222"};
                    session.SaveOrUpdate(test);
                    transaction.Commit();
                }
            }
        }

        private static void AddTestSet()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var test = new TestSet {Complexity = 102, Name = "33331233"};
                    _testSet = test;
                    session.SaveOrUpdate(test);
                    transaction.Commit();
                }
            }
        }

        private static void AddUserData()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var test = new UserData {Rights = 102, Name = "33331233", Password = "123"};
                    session.SaveOrUpdate(test);
                    transaction.Commit();
                }
            }
        }

        private static void AddStatistic()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var test = new Statistic {Mark = 102, RightTasks = 10, TestSet = _testSet};
                    session.SaveOrUpdate(test);
                    transaction.Commit();
                }
            }
        }

        private static void AddUniversity()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var test = new University { Name = "MAI" };
                    session.SaveOrUpdate(test);
                    transaction.Commit();
                }
            }
        }

        private static void AddGroup()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var test = new Group {Name = "123"};
                    session.SaveOrUpdate(test);
                    transaction.Commit();
                }
            }
        }

        
        private static void TestIdentityOn(NHibernate.ISession session, string tableName)
        {
            var sqlQry = session.CreateSQLQuery(@"SET IDENTITY_INSERT TestService.dbo." + tableName + " On");
            sqlQry.UniqueResult();
        }

        private static void TestIdentityOff(NHibernate.ISession session, string tableName)
        {
            var sqlQry = session.CreateSQLQuery(@"SET IDENTITY_INSERT TestService.dbo." + tableName + " OFF");
            sqlQry.UniqueResult();
        }



        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                .ConnectionString("Data Source=localhost;" +
                  "Initial Catalog=" + DbFile + ";Trusted_Connection=True")
                .ShowSql())
                .Mappings(m => m
                .FluentMappings.AddFromAssemblyOf<UserData>())
                .BuildSessionFactory();
        }

        public static List<UserData> GetAllUsersData()
        {
            using (var session = _sessionFactory.OpenSession())
            using (session.BeginTransaction())
                return session.CreateCriteria(typeof(UserData)).List<UserData>().ToList();
        }

        public List<User2> GetAllUsers()
        {
            using (var session = _sessionFactory.OpenSession())
            using (session.BeginTransaction())
                return session.CreateCriteria(typeof(UserData)).List<UserData>()
                    .Select(user => new User2(user)).ToList();
        }

        public static UserData GetUserById(int id)
        {
            return GetAllUsersData().First(u => u.UserId == id);
        }

        public static TestSet GetTestSetById(int id)
        {
            return GetAllTestSets().First(u => u.TestSetId == id);
        }

        public static List<TestSet> GetAllTestSets()
        {
            using (var session = _sessionFactory.OpenSession())
            using (session.BeginTransaction())
                return session.CreateCriteria(typeof(TestSet)).List<TestSet>().ToList();
        }

    }
}
