using DBWrapper.Entities;
using FluentNHibernate.Mapping;

namespace DBWrapper.Mappings
{
    public class GroupMap : ClassMap<Group>
    {
        public GroupMap()
        {
            Table("[Group]");
            Id(x => x.GroupId, "GroupId").GeneratedBy.Identity();
            Map(x => x.Name).Nullable().Length(50);
            Map(x => x.Number).Nullable();
            HasMany(x => x.UserData).Table("UserData").KeyColumn("GroupId").Cascade.All();
            References(x => x.University, "UniversityId").Cascade.All();
        }
    }

    public class UniversityMap : ClassMap<University>
    {
        public UniversityMap()
        {
            Table("University");
            Id(x => x.UniversityId, "UniversityId").GeneratedBy.Identity();
            Map(x => x.Name).Unique().Nullable().Length(50);
            HasMany(x => x.UserData).Table("UserData").KeyColumn("UniversityId").Cascade.All();
            HasMany(x => x.Group).Table("[Group]").KeyColumn("UniversityId").Cascade.All();
        }
    }

    public class StatisticMap : ClassMap<Statistic>
    {
        public StatisticMap()
        {
            Table("Statistic");
            Id(x => x.StatisticId, "StatisticId").GeneratedBy.Identity();
            Map(x => x.Mark).Nullable();
            Map(x => x.RightTasks).Nullable();
            References(x => x.UserData, "UserId");
            References(x => x.TestSet, "TestSetId");
            References(x => x.Group, "GroupId").Cascade.All();
            References(x => x.University, "UniversityId").Cascade.All();
        }
    }


    public class UserDataMap : ClassMap<UserData>
    {
        public UserDataMap()
        {
            Table("UserData");
            Id(x => x.UserId, "UserId").GeneratedBy.Identity();
            Map(x => x.Name).Nullable().Length(50);
            Map(x => x.Password).Nullable().Length(50);
            Map(x => x.Rights);
            HasMany(x => x.TestSet).Table("TestSet").KeyColumn("UserId").Cascade.All().Not.LazyLoad();
            References(x => x.Group, "GroupId").Cascade.All();
            References(x => x.University, "UniversityId").Cascade.All();
        }
    }

    public class TestSetMap : ClassMap<TestSet>
    {
        public TestSetMap()
        {
            Table("TestSet");
            Id(x => x.TestSetId, "TestSetId").GeneratedBy.Identity();
            Map(x => x.Complexity).Nullable();
            Map(x => x.Name);
            References(x => x.UserData, "UserId").Cascade.All();
            HasMany(x => x.Test).Table("Test").KeyColumn("TestSetId").Cascade.All().Not.LazyLoad();
        }
    }

    public class Testmap : ClassMap<Test>
    {
        public Testmap()
        {
            Table("Test");
            Id(x => x.TestId, "TestId").GeneratedBy.Identity();
            Map(x => x.Complexity).Nullable();
            Map(x => x.Text);
            Map(x => x.FakeAnswers);
            //Map(x => x.Image);
            Map(x => x.Answer).Nullable();
            References(x => x.TestSet, "TestSetId").Cascade.All();
        }
    }
}
