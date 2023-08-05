using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_monopoly.Apps.ManageApi.Controllers
{
    [Authorize(Roles = "Admin, SuperAdmin")]
    [Route("admin/api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {

    }
}
