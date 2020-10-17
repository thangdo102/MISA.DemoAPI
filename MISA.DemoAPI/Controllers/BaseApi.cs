using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.BusinessLayer.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApi<T> : ControllerBase
    {
        IBaseService<T> _baseService;

        public BaseApi(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }

        /// <summary>
        /// Lấy danh sách entity
        /// AUTHOR: DVTHANG(17/10/2020)
        /// </summary>
        /// <returns></returns>
        // GET: api/<BaseApi>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _baseService.Get();
            if (result != null)
                return Ok(result);
            return NoContent();
        }

        /// <summary>
        /// Lấy ra 1 entity theo Id
        /// AUTHOR: DVTHANG(17/10/2020)
        /// </summary>
        /// <param name="id">Id của entity cần lấy</param>
        /// <returns></returns>
        // GET api/<BaseApi>/5
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] Guid id)
        {
            var entity = _baseService.GetById(id);
            if (entity != null)
                return Ok(entity);
            return NoContent();
        }


        /// <summary>
        /// Thêm mới 1 entity
        /// AUTHOR: DVTHANG(17/10/2020)
        /// </summary>
        /// <param name="entity">Entity muốn thêm</param>
        /// <returns></returns>
        // POST api/<BaseApi>
        [HttpPost]
        public IActionResult Post([FromBody] T entity)
        {
            var affectRow = _baseService.Insert(entity);
            if (affectRow > 0)
                return CreatedAtAction("POST", affectRow);
            return BadRequest();
        }


        /// <summary>
        /// Hàm Edit 1 entity
        /// AUTHOR: DVTHANG(17/10/2020)
        /// </summary>
        /// <param name="entity">entity cần edit </param>
        /// <returns></returns>
        // PUT api/<BaseApi>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] T entity)
        {
            var effectRow = _baseService.update(entity);
            if (effectRow > 0)
                return CreatedAtAction("PUT", effectRow);
            else
                return BadRequest();
        }

        /// <summary>
        /// Xóa 1 nhân viên theo Id
        /// AUTHOR: DVTHANG(17/10/2020)
        /// </summary>
        /// <param name="entityId"> id của entity</param>
        // DELETE api/<BaseApi>/5
        [HttpDelete("{employeeId}")]
        public IActionResult Delete(Guid entityId)
        {
            var effectRow = _baseService.Delete(entityId);
            if (effectRow > 0)
                return CreatedAtAction("DELETE", effectRow);
            else
                return BadRequest();
        }
    }
}
