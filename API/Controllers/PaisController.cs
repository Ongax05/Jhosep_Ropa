using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PaisController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public PaisController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pager<PaisDto>>> Get(
            [FromQuery] Params PaisParams
        )
        {
            if (PaisParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork.Paises.GetAllAsync(
                PaisParams.PageIndex,
                PaisParams.PageSize
            );
            var PaisListDto = _mapper.Map<List<PaisDto>>(registers);
            return new Pager<PaisDto>(
                PaisListDto,
                totalRegisters,
                PaisParams.PageIndex,
                PaisParams.PageSize
            );
        }
        
        private ActionResult<Pager<PaisDto>> BadRequest(ApiResponse apiResponse)
        {
        throw new NotImplementedException();
        }
        
        [HttpGet]
        [MapToApiVersion("1.1")]
        public async Task<ActionResult<IEnumerable<PaisDto>>> Get1_1()
        {
            var registers = await _unitOfWork.Paises.GetAllAsync();
            var PaisListDto = _mapper.Map<List<PaisDto>>(registers);
            return PaisListDto;
        }
        
        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pais>> Post(PaisDto PaisDto)
        {
            var Pais = _mapper.Map<Pais>(PaisDto);
            _unitOfWork.Paises.Add(Pais);
            await _unitOfWork.SaveAsync();
            PaisDto.Id = Pais.Id;
            return CreatedAtAction(nameof(Post), new { id = PaisDto.Id }, PaisDto);
        }
        
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<PaisDto>> Put(
            int id,
            [FromBody] PaisDto PaisDto
        )
        {
            if (PaisDto == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var Pais = _mapper.Map<Pais>(PaisDto);
            _unitOfWork.Paises.Update(Pais);
            await _unitOfWork.SaveAsync();
            return PaisDto;
        }
        
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Delete(int id)
        {
            var Pais = await _unitOfWork.Paises.GetByIdAsync(id);
            _unitOfWork.Paises.Remove(Pais);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}