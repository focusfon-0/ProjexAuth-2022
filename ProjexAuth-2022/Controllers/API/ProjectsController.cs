using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjexAuth_2022.Data;
using ProjexAuth_2022.Models;

namespace ProjexAuth_2022.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ApplicationDbContext database;

        public ProjectsController(ApplicationDbContext database)
        {
            this.database = database;
        }

        [HttpGet("Get")]
        public ActionResult Get()
        {
            Dictionary<int, Projects> projects = new Dictionary<int, Projects>();

            for (int i = 0; i < database.Projects.Count(); i++)
            {
                projects.Add(database.Projects.ToArray()[i].ID, database.Projects.ToArray()[i]);
            }

            return Ok(projects);
        }
    }
}