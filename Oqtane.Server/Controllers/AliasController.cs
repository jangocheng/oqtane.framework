﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Oqtane.Repository;
using Oqtane.Models;

namespace Oqtane.Controllers
{
    [Route("{site}/api/[controller]")]
    public class AliasController : Controller
    {
        private readonly IAliasRepository aliases;

        public AliasController(IAliasRepository Aliases)
        {
            aliases = Aliases;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Alias> Get()
        {
            return aliases.GetAliases();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Alias Get(int id)
        {
            return aliases.GetAlias(id);
        }

        // POST api/<controller>
        [HttpPost]
        public Alias Post([FromBody] Alias Alias)
        {
            if (ModelState.IsValid)
            {
                Alias = aliases.AddAlias(Alias);
            }
            return Alias;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public Alias Put(int id, [FromBody] Alias Alias)
        {
            if (ModelState.IsValid)
            {
                Alias = aliases.UpdateAlias(Alias);
            }
            return Alias;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            aliases.DeleteAlias(id);
        }
    }
}