using Microsoft.AspNetCore.Mvc;

namespace QuizGame.Api.Controllers;

[Route("[controller]")]

public class LobbyController : ApiController
{
    [HttpGet]
    public IActionResult ListLobby()
    {
        return Ok(Array.Empty<string>());
    }
}