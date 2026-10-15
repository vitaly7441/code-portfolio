using System;
using Practice5_TestingPlatform.Models;
using Practice5_TestingPlatform.Data;
using Microsoft.AspNetCore.Mvc;

namespace Practice5_TestingPlatform.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class GroupsController:ControllerBase
	{
		private readonly AppDbContext _db;

        public GroupsController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAllGroups() {
            var groups = _db.Groups.ToList();
            return Ok(groups);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetGroupById(int id)
        {
            if (id <= 0)
                return BadRequest("Некорректный id");

            var group = _db.Groups.FirstOrDefault(g => g.Id == id);
            if (group is null)
                return NotFound();

            return Ok(group);
        }

        [HttpPost]
        public IActionResult CreateGroup([FromBody] Group group)
        {
            if (string.IsNullOrWhiteSpace(group.Name))
                return BadRequest("Название группы обязательно");

            var groupExists = _db.Groups.Where(g => g.Name == group.Name).ToList();
            if (groupExists.Any())
                return Conflict($"Группа {group.Name} уже существует, выберите другое название");

            _db.Groups.Add(group);
            _db.SaveChanges();

            return CreatedAtAction(nameof(GetGroupById), new { id = group.Id }, group);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateGroup(int id, [FromBody] Group updatedGroup)
        {
            var existingGroup = _db.Groups.FirstOrDefault(g => g.Id == id);
            if (existingGroup is null)
                return NotFound();

            existingGroup.Name = updatedGroup.Name;
            existingGroup.DirectionId = updatedGroup.DirectionId;
            existingGroup.CourseId = updatedGroup.CourseId;
            existingGroup.ProjectId = updatedGroup.ProjectId;

            _db.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteGroup(int id)
        {
            var group = _db.Groups.Find(id);
            if (group is null)
                return NotFound();

            _db.Groups.Remove(group);
            _db.SaveChanges();
            return NoContent();
        }
    }
}

