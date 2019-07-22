using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repository
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Keep> GetKeepsByVaultId(int id)
    {
      string query = @"
      SELECT * FROM vaultkeeps vk
      INNER JOIN keeps k ON k.id = vk.keepId
      WHERE(vaultId = @vaultId AND vk.userId = @userId)";
      return _db.Query<Keep>(query, new { id });
    }

    public string Create(VaultKeeps value)
    {
      string query = @"
      INSERT INTO vaultkeeps (vaultId, keepId, userId)
             VALUES(@VaultId, @KeepId, @UserId);";
      int changedRows = _db.Execute(query, value);
      if (changedRows < 1) throw new Exception("Invalid Ids");
      return "Successfully added Keep to Vault";
    }

    public string Update(VaultKeeps value)
    {
      string query = @"
      DELETE FROM vaultkeeps
      WHERE (vaultId = @VaultId AND keepId = @KeepId AND userId = @UserId);
      ";
      int changedRows = _db.Execute(query, value);
      if (changedRows < 1) throw new Exception("Invalid Id");
      return "Successfully Deleted Keep";
    }
  }
}