namespace Bl;
using System.Data;
using Dal;

public sealed class PersonsEntity
{
    public int? Id { get; set; }

    public string? Name { get; set; }
}

public interface IPersonsBl
{
    public List<PersonsEntity> GetAll();

    public PersonsEntity GetBy(int id);

    public int DeleteBy(int id);

    public PersonsEntity CreateBy(PersonsEntity entity);

    public int UpdateBy(PersonsEntity entity);
}

public sealed class PersonsBl(IPersonsDal personsDal) : IPersonsBl
{
    private IPersonsDal PersonsDal { get; } = personsDal;

    public List<PersonsEntity> GetAll()
    {
        var dt = this.PersonsDal.GetAll();
        return Map2Entities(dt);
    }

    public PersonsEntity GetBy(int id)
    {
        var dt = this.PersonsDal.GetBy(id);
        return Map2Entity(dt);
    }

    public int DeleteBy(int id) => this.PersonsDal.DeleteBy(id);

    public PersonsEntity CreateBy(PersonsEntity entity)
    {
        var dt = this.PersonsDal.CreateBy(Map2Dt(entity));
        return Map2Entity(dt);
    }

    public int UpdateBy(PersonsEntity entity) => this.PersonsDal.UpdateBy(Map2Dt(entity));

    private static PersonsEntity Map2Entity(DataTable dt)
    {
        if (dt.Rows.Count <= 0)
        {
            return new PersonsEntity { };
        }

        if (dt.Rows.Count >= 2)
        {
            throw new InvalidOperationException();
        }

        var r = dt.Rows[0];

        return new PersonsEntity
        {
            Id = (int)r["Id"],
            Name = (string)r["Name"]
        };
    }

    private static DataTable Map2Dt(List<PersonsEntity> entities)
    {
        var dt = CreateDt();
        foreach (var e in entities)
        {
            dt.Rows.Add(e.Id, e.Name);
        }
        return dt;
    }

    private static List<PersonsEntity> Map2Entities(DataTable dt)
    {
        var entity = new List<PersonsEntity>();
        foreach (DataRow r in dt.Rows)
        {
            var tempDt = CreateDt();
            tempDt.ImportRow(r);
            entity.Add(Map2Entity(tempDt));
        }
        return entity;
    }

    private static DataTable Map2Dt(PersonsEntity entity)
    {
        var entities = new List<PersonsEntity>
        {
            entity
        };
        return Map2Dt(entities);
    }

    private static DataTable CreateDt()
    {
        var dt = new DataTable();
        dt.Columns.Add("Id", typeof(int));
        dt.Columns.Add("Name", typeof(string));
        return dt;
    }
}
