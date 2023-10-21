using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PrendaController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public PrendaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pager<PrendaDto>>> Get(
            [FromQuery] Params PrendaParams
        )
        {
            if (PrendaParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork.Prendas.GetAllAsync(
                PrendaParams.PageIndex,
                PrendaParams.PageSize
            );
            var PrendaListDto = _mapper.Map<List<PrendaDto>>(registers);
            return new Pager<PrendaDto>(
                PrendaListDto,
                totalRegisters,
                PrendaParams.PageIndex,
                PrendaParams.PageSize
            );
        }
        
        private ActionResult<Pager<PrendaDto>> BadRequest(ApiResponse apiResponse)
        {
        throw new NotImplementedException();
        }
        
        [HttpGet("1.1")]
        [MapToApiVersion("1.1")]
        public async Task<ActionResult<IEnumerable<PrendaDto>>> Get1_1()
        {
            var registers = await _unitOfWork.Prendas.GetAllAsync();
            var PrendaListDto = _mapper.Map<List<PrendaDto>>(registers);
            return PrendaListDto;
        }
        
        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Prenda>> Post(PrendaDto PrendaDto)
        {
            var Prenda = _mapper.Map<Prenda>(PrendaDto);
            _unitOfWork.Prendas.Add(Prenda);
            await _unitOfWork.SaveAsync();
            PrendaDto.Id = Prenda.Id;
            return CreatedAtAction(nameof(Post), new { id = PrendaDto.Id }, PrendaDto);
        }
        
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<PrendaDto>> Put(
            int id,
            [FromBody] PrendaDto PrendaDto
        )
        {
            if (PrendaDto == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var Prenda = _mapper.Map<Prenda>(PrendaDto);
            _unitOfWork.Prendas.Update(Prenda);
            await _unitOfWork.SaveAsync();
            return PrendaDto;
        }
        
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Delete(int id)
        {
            var Prenda = await _unitOfWork.Prendas.GetByIdAsync(id);
            _unitOfWork.Prendas.Remove(Prenda);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}