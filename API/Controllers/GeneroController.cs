using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class GeneroController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public GeneroController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pager<GeneroDto>>> Get(
            [FromQuery] Params GeneroParams
        )
        {
            if (GeneroParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork.Generos.GetAllAsync(
                GeneroParams.PageIndex,
                GeneroParams.PageSize
            );
            var GeneroListDto = _mapper.Map<List<GeneroDto>>(registers);
            return new Pager<GeneroDto>(
                GeneroListDto,
                totalRegisters,
                GeneroParams.PageIndex,
                GeneroParams.PageSize
            );
        }
        
        private ActionResult<Pager<GeneroDto>> BadRequest(ApiResponse apiResponse)
        {
        throw new NotImplementedException();
        }
        
        [HttpGet("1.1")]
        [MapToApiVersion("1.1")]
        public async Task<ActionResult<IEnumerable<GeneroDto>>> Get1_1()
        {
            var registers = await _unitOfWork.Generos.GetAllAsync();
            var GeneroListDto = _mapper.Map<List<GeneroDto>>(registers);
            return GeneroListDto;
        }
        
        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Genero>> Post(GeneroDto GeneroDto)
        {
            var Genero = _mapper.Map<Genero>(GeneroDto);
            _unitOfWork.Generos.Add(Genero);
            await _unitOfWork.SaveAsync();
            GeneroDto.Id = Genero.Id;
            return CreatedAtAction(nameof(Post), new { id = GeneroDto.Id }, GeneroDto);
        }
        
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<GeneroDto>> Put(
            int id,
            [FromBody] GeneroDto GeneroDto
        )
        {
            if (GeneroDto == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var Genero = _mapper.Map<Genero>(GeneroDto);
            _unitOfWork.Generos.Update(Genero);
            await _unitOfWork.SaveAsync();
            return GeneroDto;
        }
        
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Delete(int id)
        {
            var Genero = await _unitOfWork.Generos.GetByIdAsync(id);
            _unitOfWork.Generos.Remove(Genero);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}