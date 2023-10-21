using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [Authorize(Roles = "Employee,Admin")]
    public class DepartamentoController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public DepartamentoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pager<DepartamentoDto>>> Get(
            [FromQuery] Params DepartamentoParams
        )
        {
            if (DepartamentoParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork.Departamentos.GetAllAsync(
                DepartamentoParams.PageIndex,
                DepartamentoParams.PageSize
            );
            var DepartamentoListDto = _mapper.Map<List<DepartamentoDto>>(registers);
            return new Pager<DepartamentoDto>(
                DepartamentoListDto,
                totalRegisters,
                DepartamentoParams.PageIndex,
                DepartamentoParams.PageSize
            );
        }
        
        private ActionResult<Pager<DepartamentoDto>> BadRequest(ApiResponse apiResponse)
        {
        throw new NotImplementedException();
        }
        
        [HttpGet("1.1")]
        [MapToApiVersion("1.1")]
        public async Task<ActionResult<IEnumerable<DepartamentoDto>>> Get1_1()
        {
            var registers = await _unitOfWork.Departamentos.GetAllAsync();
            var DepartamentoListDto = _mapper.Map<List<DepartamentoDto>>(registers);
            return DepartamentoListDto;
        }
        
        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Departamento>> Post(DepartamentoDto DepartamentoDto)
        {
            var Departamento = _mapper.Map<Departamento>(DepartamentoDto);
            _unitOfWork.Departamentos.Add(Departamento);
            await _unitOfWork.SaveAsync();
            DepartamentoDto.Id = Departamento.Id;
            return CreatedAtAction(nameof(Post), new { id = DepartamentoDto.Id }, DepartamentoDto);
        }
        
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<DepartamentoDto>> Put(
            int id,
            [FromBody] DepartamentoDto DepartamentoDto
        )
        {
            if (DepartamentoDto == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var Departamento = _mapper.Map<Departamento>(DepartamentoDto);
            _unitOfWork.Departamentos.Update(Departamento);
            await _unitOfWork.SaveAsync();
            return DepartamentoDto;
        }
        
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Delete(int id)
        {
            var Departamento = await _unitOfWork.Departamentos.GetByIdAsync(id);
            _unitOfWork.Departamentos.Remove(Departamento);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}