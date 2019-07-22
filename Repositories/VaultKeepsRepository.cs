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
      string query = "SELECT * FROM vaultkeeps WHERE vaultId = @id";
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

    public VaultKeeps Update(VaultKeeps value)
    {
      string query = @"
      UPDATE vaultkeeps
      SET
          vaultId = @VaultId,
          keepId = @KeepId
      WHERE id = @Id;
      SELECT * FROM vaultkeeps WHERE id = @Id";
      return _db.QueryFirstOrDefault(query, value);
    }
  }
}