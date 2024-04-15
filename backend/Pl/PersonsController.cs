namespace Pl;
using Bl;
using Dal;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/[controller]/[Action]")]
public class PersonsController : ControllerBase
{
    private IPersonsBl PersonsBl { get; }

    public PersonsController(IConfiguration config)
    {
        var connectionString = config["ConnectionStrings:db1"] ?? string.Empty;
        this.PersonsBl = new PersonsBl(new PersonsDal(connectionString));
    }

    [HttpGet]
    public IActionResult GetAll() => this.Ok(this.PersonsBl.GetAll());

    [HttpGet("{id}")]
    public IActionResult GetBy(int id) => this.Ok(this.PersonsBl.GetBy(id));

    [HttpDelete("{id}")]
    public IActionResult DeleteBy(int id) => this.Ok(this.PersonsBl.DeleteBy(id));

    [HttpPost]
    public IActionResult CreateBy([FromBody] PersonsEntity entity) => this.Ok(this.PersonsBl.CreateBy(entity));

    [HttpPut]
    public IActionResult UpdateBy([FromBody] PersonsEntity entity) => this.Ok(this.PersonsBl.UpdateBy(entity));
}
