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
    public class TipoProteccionController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public TipoProteccionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pager<TipoProteccionDto>>> Get(
            [FromQuery] Params TipoProteccionParams
        )
        {
            if (TipoProteccionParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork.TiposProtecciones.GetAllAsync(
                TipoProteccionParams.PageIndex,
                TipoProteccionParams.PageSize
            );
            var TipoProteccionListDto = _mapper.Map<List<TipoProteccionDto>>(registers);
            return new Pager<TipoProteccionDto>(
                TipoProteccionListDto,
                totalRegisters,
                TipoProteccionParams.PageIndex,
                TipoProteccionParams.PageSize
            );
        }
        
        private ActionResult<Pager<TipoProteccionDto>> BadRequest(ApiResponse apiResponse)
        {
        throw new NotImplementedException();
        }
        
        [HttpGet("1.1")]
        [MapToApiVersion("1.1")]
        public async Task<ActionResult<IEnumerable<TipoProteccionDto>>> Get1_1()
        {
            var registers = await _unitOfWork.TiposProtecciones.GetAllAsync();
            var TipoProteccionListDto = _mapper.Map<List<TipoProteccionDto>>(registers);
            return TipoProteccionListDto;
        }
        
        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<TipoProteccion>> Post(TipoProteccionDto TipoProteccionDto)
        {
            var TipoProteccion = _mapper.Map<TipoProteccion>(TipoProteccionDto);
            _unitOfWork.TiposProtecciones.Add(TipoProteccion);
            await _unitOfWork.SaveAsync();
            TipoProteccionDto.Id = TipoProteccion.Id;
            return CreatedAtAction(nameof(Post), new { id = TipoProteccionDto.Id }, TipoProteccionDto);
        }
        
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<TipoProteccionDto>> Put(
            int id,
            [FromBody] TipoProteccionDto TipoProteccionDto
        )
        {
            if (TipoProteccionDto == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var TipoProteccion = _mapper.Map<TipoProteccion>(TipoProteccionDto);
            _unitOfWork.TiposProtecciones.Update(TipoProteccion);
            await _unitOfWork.SaveAsync();
            return TipoProteccionDto;
        }
        
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Delete(int id)
        {
            var TipoProteccion = await _unitOfWork.TiposProtecciones.GetByIdAsync(id);
            _unitOfWork.TiposProtecciones.Remove(TipoProteccion);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }        
    }
}