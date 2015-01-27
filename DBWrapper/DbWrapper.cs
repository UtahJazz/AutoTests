using System.Collections.Generic;
using System.Linq;
using DBWrapper.Entities;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace DbWrapper
{
    public class DbWrapper
    {
        private const string DbFile = "TestService";
        public readonly ISessionFactory SessionFactory;
        public ISession CurrentSession;
        public DbWrapper()
        {
            SessionFactory = CreateSessionFactory();
        }

        public List<UserData> GetAllUsersData()
        {
            using (var session = SessionFactory.OpenSession())
            using (session.BeginTransaction())
                return session.CreateCriteria(typeof (UserData)).List<UserData>().ToList();
        }

        public List<Statistic> GetAllStatistic()
        {
            using (var session = SessionFactory.OpenSession())
            using (session.BeginTransaction())
                return session.CreateCriteria(typeof(Statistic)).List<Statistic>().ToList();
        }

        public List<Statistic> GetAllStatisticByUserId(int userId)
        {
            return GetAllStatistic().Where(statistic => statistic.UserData != null && statistic.UserData.UserId == userId).ToList();
        }

        public UserData GetUserById(int id)
        {
            return GetAllUsersData().DefaultIfEmpty(null).FirstOrDefault(u => u.UserId == id);
        }

        public TestSet GetTestSetById(int id)
        {
            return GetAllTestSets().DefaultIfEmpty(null).FirstOrDefault(testSet => testSet.TestSetId == id);
            //return GetAllTestSets().First(u => u.TestSetId == id);
        }

        public List<TestSet> GetAllTestSets()
        {
            using (var session = SessionFactory.OpenSession())
                using (session.BeginTransaction())
                    return session.CreateCriteria(typeof(TestSet)).List<TestSet>().ToList();
        }

        public List<Test> GetAllTests()
        {
            CurrentSession = SessionFactory.OpenSession();
            CurrentSession.BeginTransaction();
            return CurrentSession.CreateCriteria(typeof(Test)).List<Test>().ToList();
        }

        public List<Test> GetTestsInTestSet(int testSetId)
        {
            CurrentSession = SessionFactory.OpenSession();
            CurrentSession.BeginTransaction();
            return CurrentSession.CreateCriteria(typeof (Test)).List<Test>()
                .Where(test => test.TestSet != null).Where(test => test.TestSet.TestSetId == testSetId).ToList();
            //return CurrentSession.CreateCriteria(typeof(Test)).List<Test>().Where(t => t.TestSet.TestSetId == testSetId).ToList();
        }

        public void AddUser(UserData user)
        {
            using (var session = SessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(user);
                    transaction.Commit();
                }
        }

        public void AddStatistic(Statistic statistic, int testSetId, int userId)
        {
            using (var session = SessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var result = statistic;
                result.TestSet = GetTestSetById(testSetId);
                result.UserData = GetUserById(userId);

                session.SaveOrUpdate(result);
                transaction.Commit();
            }
        }

        public void AddTestSet(TestSet testSet)
        {
            using (var session = SessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(testSet);
                    transaction.Commit();
                }
        }

        public void AddTestSet(TestSet testSet, int userId)
        {
            using (var session = SessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var set = testSet;
                set.UserData = GetUserById(userId);
                session.SaveOrUpdate(set);
                transaction.Commit();
            }
        }

        public void AddTestSet(TestSet testSet, int userId, List<Test> tests)
        {
            using (var session = SessionFactory.OpenSession())
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
                        session.SaveOrUpdate(test);
                    }
                    transaction.Commit();
                }
            }
        }

        public void AddTest(Test test)
        {
            using (var session = SessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.SaveOrUpdate(test);
                transaction.Commit();
            }
        }

        public void AddTest(Test test, int testSetId)
        {
            using (var session = SessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var newTest = test;
                newTest.TestSet = GetTestSetById(testSetId);
                newTest.TestSet.Test.Add(newTest);
                session.SaveOrUpdate(test);
                transaction.Commit();
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
    }
}
