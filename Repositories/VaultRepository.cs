using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repository
{
  public class VaultRepository
  {
    private readonly IDbConnection _db;
    public VaultRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Vault> GetALL()
    {
      return _db.Query<Vault>("SELECT * FROM vaults");
    }

    public Vault GetById(int id)
    {
      string query = "SELECT * FROM vaults WHERE id = @id";
      Vault data = _db.QueryFirstOrDefault<Vault>(query, new { id });
      if (data == null) throw new Exception("Invalid Id");
      return data;
    }

    public Vault Create(Vault value)
    {
      string query = @"
      INSERT INTO vaults (name, description, userId)
             VALUES(@Name, @Description, @UserId);
             SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(query, value);
      value.Id = id;
      return value;
    }

    public Vault Update(Vault value)
    {
      string query = @"
      UPDATE vaults
      SET
        name = @Name,
        descrtipion = @Description,
        WHERE id = @Id;
        SELECT * FROM keeps WHERE id = @Id;";
      return _db.QueryFirstOrDefault<Vault>(query, value);
    }

    public string Delete(int id)
    {
      string query = "DELETE FROM vaults WHERE id = @Id";
      int changedRows = _db.Execute(query, new { id });
      if (changedRows < 1) throw new Exception("Invalid Id");
      return "Successfully Deleted Vault";
    }
  }
}