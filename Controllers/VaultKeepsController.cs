using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Keepr.Models;
using Keepr.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsRepository _repo;
    public VaultKeepsController(VaultKeepsRepository repo)
    {
      _repo = repo;
    }

    // GET api/vaultkeeps/5
    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Keep>> Get(int id)
    {
      try
      {
        return Ok(_repo.GetKeepsByVaultId(id));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // POST api/vaultkeeps
    [Authorize]
    [HttpPost]
    public ActionResult<string> Post([FromBody] VaultKeeps value)
    {
      try
      {
        var userId = HttpContext.User.FindFirstValue("Id");
        value.UserId = userId;
        return Ok(_repo.Create(value));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // DELETE api/vaultkeeps/5
    [Authorize]
    [HttpPut]
    public ActionResult<string> Put([FromBody] VaultKeeps value)
    {
      try
      {
        var userId = HttpContext.User.FindFirstValue("Id");
        value.UserId = userId;
        return Ok(_repo.Update(value));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
  }
}