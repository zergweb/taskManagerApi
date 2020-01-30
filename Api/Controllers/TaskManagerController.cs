using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos;
using Infrastructure.Entitys;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskManagerController : ControllerBase
    {
        private readonly TaskManagerService _taskService;

        public TaskManagerController(TaskManagerService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("init")]
        public async Task<ActionResult> InitDb()
        {
            await _taskService.InitDbAsync();
            return Ok();
        }
        [HttpGet("getData")]
        public async Task<ActionResult> GetData()
        {
            var (template, tasks) = await _taskService.GetDataAsync();
            return Ok(new TasksDto() { Template = template, Tasks = tasks});
        }
    }
 }
