using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TipoPersonaController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public TipoPersonaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pager<TipoPersonaDto>>> Get(
            [FromQuery] Params TipoPersonaParams
        )
        {
            if (TipoPersonaParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork.TiposPersonas.GetAllAsync(
                TipoPersonaParams.PageIndex,
                TipoPersonaParams.PageSize
            );
            var TipoPersonaListDto = _mapper.Map<List<TipoPersonaDto>>(registers);
            return new Pager<TipoPersonaDto>(
                TipoPersonaListDto,
                totalRegisters,
                TipoPersonaParams.PageIndex,
                TipoPersonaParams.PageSize
            );
        }
        
        private ActionResult<Pager<TipoPersonaDto>> BadRequest(ApiResponse apiResponse)
        {
        throw new NotImplementedException();
        }
        
        [HttpGet("1.1")]
        [MapToApiVersion("1.1")]
        public async Task<ActionResult<IEnumerable<TipoPersonaDto>>> Get1_1()
        {
            var registers = await _unitOfWork.TiposPersonas.GetAllAsync();
            var TipoPersonaListDto = _mapper.Map<List<TipoPersonaDto>>(registers);
            return TipoPersonaListDto;
        }
        
        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<TipoPersona>> Post(TipoPersonaDto TipoPersonaDto)
        {
            var TipoPersona = _mapper.Map<TipoPersona>(TipoPersonaDto);
            _unitOfWork.TiposPersonas.Add(TipoPersona);
            await _unitOfWork.SaveAsync();
            TipoPersonaDto.Id = TipoPersona.Id;
            return CreatedAtAction(nameof(Post), new { id = TipoPersonaDto.Id }, TipoPersonaDto);
        }
        
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<TipoPersonaDto>> Put(
            int id,
            [FromBody] TipoPersonaDto TipoPersonaDto
        )
        {
            if (TipoPersonaDto == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var TipoPersona = _mapper.Map<TipoPersona>(TipoPersonaDto);
            _unitOfWork.TiposPersonas.Update(TipoPersona);
            await _unitOfWork.SaveAsync();
            return TipoPersonaDto;
        }
        
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Delete(int id)
        {
            var TipoPersona = await _unitOfWork.TiposPersonas.GetByIdAsync(id);
            _unitOfWork.TiposPersonas.Remove(TipoPersona);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}