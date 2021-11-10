﻿using AspDotNetCoreApi.Models;
using AspDotNetCoreApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspDotNetCoreApi.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        StateRepository _stateRepository;
        public StatesController(StateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }
        // GET: api/<StatesController>
        [HttpGet]
        public IEnumerable<State> Get()
        {
            var states = _stateRepository.GetStates();
            return states;
        }

        // GET api/<StatesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StatesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StatesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StatesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
