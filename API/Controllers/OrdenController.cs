using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class OrdenController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public OrdenController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pager<OrdenDto>>> Get(
            [FromQuery] Params OrdenParams
        )
        {
            if (OrdenParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork.Ordenes.GetAllAsync(
                OrdenParams.PageIndex,
                OrdenParams.PageSize
            );
            var OrdenListDto = _mapper.Map<List<OrdenDto>>(registers);
            return new Pager<OrdenDto>(
                OrdenListDto,
                totalRegisters,
                OrdenParams.PageIndex,
                OrdenParams.PageSize
            );
        }
        
        private ActionResult<Pager<OrdenDto>> BadRequest(ApiResponse apiResponse)
        {
        throw new NotImplementedException();
        }
        
        [HttpGet("1.1")]
        [MapToApiVersion("1.1")]
        public async Task<ActionResult<IEnumerable<OrdenDto>>> Get1_1()
        {
            var registers = await _unitOfWork.Ordenes.GetAllAsync();
            var OrdenListDto = _mapper.Map<List<OrdenDto>>(registers);
            return OrdenListDto;
        }
        
        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Orden>> Post(OrdenDto OrdenDto)
        {
            var Orden = _mapper.Map<Orden>(OrdenDto);
            _unitOfWork.Ordenes.Add(Orden);
            await _unitOfWork.SaveAsync();
            OrdenDto.Id = Orden.Id;
            return CreatedAtAction(nameof(Post), new { id = OrdenDto.Id }, OrdenDto);
        }
        
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<OrdenDto>> Put(
            int id,
            [FromBody] OrdenDto OrdenDto
        )
        {
            if (OrdenDto == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var Orden = _mapper.Map<Orden>(OrdenDto);
            _unitOfWork.Ordenes.Update(Orden);
            await _unitOfWork.SaveAsync();
            return OrdenDto;
        }
        
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Delete(int id)
        {
            var Orden = await _unitOfWork.Ordenes.GetByIdAsync(id);
            _unitOfWork.Ordenes.Remove(Orden);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}