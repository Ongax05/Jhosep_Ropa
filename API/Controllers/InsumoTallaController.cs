using System;
using System.Collections.Generic;
using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistency;

namespace API.Controllers
{
    public class InventarioTallaController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public InventarioTallaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pager<InventarioTallaDto>>> Get(
            [FromQuery] Params InventarioTallaParams
        )
        {
            if (InventarioTallaParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork.InventariosTallas.GetAllAsync(
                InventarioTallaParams.PageIndex,
                InventarioTallaParams.PageSize
            );
            var InventarioTallaListDto = _mapper.Map<List<InventarioTallaDto>>(registers);
            return new Pager<InventarioTallaDto>(
                InventarioTallaListDto,
                totalRegisters,
                InventarioTallaParams.PageIndex,
                InventarioTallaParams.PageSize
            );
        }
        
        private ActionResult<Pager<InventarioTallaDto>> BadRequest(ApiResponse apiResponse)
        {
        throw new NotImplementedException();
        }
        
        [HttpGet("1.1")]
        [MapToApiVersion("1.1")]
        public async Task<ActionResult<IEnumerable<InventarioTallaDto>>> Get1_1()
        {
            var registers = await _unitOfWork.InventariosTallas.GetAllAsync();
            var InventarioTallaListDto = _mapper.Map<List<InventarioTallaDto>>(registers);
            return InventarioTallaListDto;
        }
        
        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<InventarioTalla>> Post(InventarioTallaDto InventarioTallaDto)
        {
            var InventarioTalla = _mapper.Map<InventarioTalla>(InventarioTallaDto);
            _unitOfWork.InventariosTallas.Add(InventarioTalla);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(Post), InventarioTallaDto);
        }
        
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<InventarioTallaDto>> Put(
            int id,
            [FromBody] InventarioTallaDto InventarioTallaDto
        )
        {
            if (InventarioTallaDto == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var InventarioTalla = _mapper.Map<InventarioTalla>(InventarioTallaDto);
            _unitOfWork.InventariosTallas.Update(InventarioTalla);
            await _unitOfWork.SaveAsync();
            return InventarioTallaDto;
        }
    }
}