using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TipoEstadoController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public TipoEstadoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pager<TipoEstadoDto>>> Get(
            [FromQuery] Params TipoEstadoParams
        )
        {
            if (TipoEstadoParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork.TiposEstados.GetAllAsync(
                TipoEstadoParams.PageIndex,
                TipoEstadoParams.PageSize
            );
            var TipoEstadoListDto = _mapper.Map<List<TipoEstadoDto>>(registers);
            return new Pager<TipoEstadoDto>(
                TipoEstadoListDto,
                totalRegisters,
                TipoEstadoParams.PageIndex,
                TipoEstadoParams.PageSize
            );
        }
        
        private ActionResult<Pager<TipoEstadoDto>> BadRequest(ApiResponse apiResponse)
        {
        throw new NotImplementedException();
        }
        
        [HttpGet]
        [MapToApiVersion("1.1")]
        public async Task<ActionResult<IEnumerable<TipoEstadoDto>>> Get1_1()
        {
            var registers = await _unitOfWork.TiposEstados.GetAllAsync();
            var TipoEstadoListDto = _mapper.Map<List<TipoEstadoDto>>(registers);
            return TipoEstadoListDto;
        }
        
        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<TipoEstado>> Post(TipoEstadoDto TipoEstadoDto)
        {
            var TipoEstado = _mapper.Map<TipoEstado>(TipoEstadoDto);
            _unitOfWork.TiposEstados.Add(TipoEstado);
            await _unitOfWork.SaveAsync();
            TipoEstadoDto.Id = TipoEstado.Id;
            return CreatedAtAction(nameof(Post), new { id = TipoEstadoDto.Id }, TipoEstadoDto);
        }
        
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<TipoEstadoDto>> Put(
            int id,
            [FromBody] TipoEstadoDto TipoEstadoDto
        )
        {
            if (TipoEstadoDto == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var TipoEstado = _mapper.Map<TipoEstado>(TipoEstadoDto);
            _unitOfWork.TiposEstados.Update(TipoEstado);
            await _unitOfWork.SaveAsync();
            return TipoEstadoDto;
        }
        
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Delete(int id)
        {
            var TipoEstado = await _unitOfWork.TiposEstados.GetByIdAsync(id);
            _unitOfWork.TiposEstados.Remove(TipoEstado);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}