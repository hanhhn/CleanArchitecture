using System.Reflection;

namespace Web.Controllers;

[ApiController]
[Route("version")]
public class VersionController : ControllerBase
{
    private string Version => Assembly.GetExecutingAssembly().GetName().Version.ToString();

    [HttpGet]
    public ActionResult<string> GetVersion()
    {
        return Ok(Version);
    }
}

