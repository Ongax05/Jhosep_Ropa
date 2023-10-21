using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class DetalleOrdenController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public DetalleOrdenController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pager<DetalleOrdenDto>>> Get(
            [FromQuery] Params DetalleOrdenParams
        )
        {
            if (DetalleOrdenParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork.DetallesOrdenes.GetAllAsync(
                DetalleOrdenParams.PageIndex,
                DetalleOrdenParams.PageSize
            );
            var DetalleOrdenListDto = _mapper.Map<List<DetalleOrdenDto>>(registers);
            return new Pager<DetalleOrdenDto>(
                DetalleOrdenListDto,
                totalRegisters,
                DetalleOrdenParams.PageIndex,
                DetalleOrdenParams.PageSize
            );
        }
        
        private ActionResult<Pager<DetalleOrdenDto>> BadRequest(ApiResponse apiResponse)
        {
        throw new NotImplementedException();
        }
        
        [HttpGet("1.1")]
        [MapToApiVersion("1.1")]
        public async Task<ActionResult<IEnumerable<DetalleOrdenDto>>> Get1_1()
        {
            var registers = await _unitOfWork.DetallesOrdenes.GetAllAsync();
            var DetalleOrdenListDto = _mapper.Map<List<DetalleOrdenDto>>(registers);
            return DetalleOrdenListDto;
        }
        
        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<DetalleOrden>> Post(DetalleOrdenDto DetalleOrdenDto)
        {
            var DetalleOrden = _mapper.Map<DetalleOrden>(DetalleOrdenDto);
            _unitOfWork.DetallesOrdenes.Add(DetalleOrden);
            await _unitOfWork.SaveAsync();
            DetalleOrdenDto.Id = DetalleOrden.Id;
            return CreatedAtAction(nameof(Post), new { id = DetalleOrdenDto.Id }, DetalleOrdenDto);
        }
        
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<DetalleOrdenDto>> Put(
            int id,
            [FromBody] DetalleOrdenDto DetalleOrdenDto
        )
        {
            if (DetalleOrdenDto == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var DetalleOrden = _mapper.Map<DetalleOrden>(DetalleOrdenDto);
            _unitOfWork.DetallesOrdenes.Update(DetalleOrden);
            await _unitOfWork.SaveAsync();
            return DetalleOrdenDto;
        }
        
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Delete(int id)
        {
            var DetalleOrden = await _unitOfWork.DetallesOrdenes.GetByIdAsync(id);
            _unitOfWork.DetallesOrdenes.Remove(DetalleOrden);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}