using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TallaController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public TallaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pager<TallaDto>>> Get(
            [FromQuery] Params TallaParams
        )
        {
            if (TallaParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork.Tallas.GetAllAsync(
                TallaParams.PageIndex,
                TallaParams.PageSize
            );
            var TallaListDto = _mapper.Map<List<TallaDto>>(registers);
            return new Pager<TallaDto>(
                TallaListDto,
                totalRegisters,
                TallaParams.PageIndex,
                TallaParams.PageSize
            );
        }
        
        private ActionResult<Pager<TallaDto>> BadRequest(ApiResponse apiResponse)
        {
        throw new NotImplementedException();
        }
        
        [HttpGet("1.1")]
        [MapToApiVersion("1.1")]
        public async Task<ActionResult<IEnumerable<TallaDto>>> Get1_1()
        {
            var registers = await _unitOfWork.Tallas.GetAllAsync();
            var TallaListDto = _mapper.Map<List<TallaDto>>(registers);
            return TallaListDto;
        }
        
        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Talla>> Post(TallaDto TallaDto)
        {
            var Talla = _mapper.Map<Talla>(TallaDto);
            _unitOfWork.Tallas.Add(Talla);
            await _unitOfWork.SaveAsync();
            TallaDto.Id = Talla.Id;
            return CreatedAtAction(nameof(Post), new { id = TallaDto.Id }, TallaDto);
        }
        
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<TallaDto>> Put(
            int id,
            [FromBody] TallaDto TallaDto
        )
        {
            if (TallaDto == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var Talla = _mapper.Map<Talla>(TallaDto);
            _unitOfWork.Tallas.Update(Talla);
            await _unitOfWork.SaveAsync();
            return TallaDto;
        }
        
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Delete(int id)
        {
            var Talla = await _unitOfWork.Tallas.GetByIdAsync(id);
            _unitOfWork.Tallas.Remove(Talla);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}