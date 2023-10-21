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
    public class EstadoController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public EstadoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet("1.1")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pager<EstadoDto>>> Get(
            [FromQuery] Params EstadoParams
        )
        {
            if (EstadoParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork.Estados.GetAllAsync(
                EstadoParams.PageIndex,
                EstadoParams.PageSize
            );
            var EstadoListDto = _mapper.Map<List<EstadoDto>>(registers);
            return new Pager<EstadoDto>(
                EstadoListDto,
                totalRegisters,
                EstadoParams.PageIndex,
                EstadoParams.PageSize
            );
        }
        
        private ActionResult<Pager<EstadoDto>> BadRequest(ApiResponse apiResponse)
        {
        throw new NotImplementedException();
        }
        
        [HttpGet]
        [MapToApiVersion("1.1")]
        public async Task<ActionResult<IEnumerable<EstadoDto>>> Get1_1()
        {
            var registers = await _unitOfWork.Estados.GetAllAsync();
            var EstadoListDto = _mapper.Map<List<EstadoDto>>(registers);
            return EstadoListDto;
        }
        
        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Estado>> Post(EstadoDto EstadoDto)
        {
            var Estado = _mapper.Map<Estado>(EstadoDto);
            _unitOfWork.Estados.Add(Estado);
            await _unitOfWork.SaveAsync();
            EstadoDto.Id = Estado.Id;
            return CreatedAtAction(nameof(Post), new { id = EstadoDto.Id }, EstadoDto);
        }
        
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<EstadoDto>> Put(
            int id,
            [FromBody] EstadoDto EstadoDto
        )
        {
            if (EstadoDto == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var Estado = _mapper.Map<Estado>(EstadoDto);
            _unitOfWork.Estados.Update(Estado);
            await _unitOfWork.SaveAsync();
            return EstadoDto;
        }
        
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Delete(int id)
        {
            var Estado = await _unitOfWork.Estados.GetByIdAsync(id);
            _unitOfWork.Estados.Remove(Estado);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}