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
    public class DetalleVentaController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public DetalleVentaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pager<DetalleVentaDto>>> Get(
            [FromQuery] Params DetalleVentaParams
        )
        {
            if (DetalleVentaParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork.DetallesVentas.GetAllAsync(
                DetalleVentaParams.PageIndex,
                DetalleVentaParams.PageSize
            );
            var DetalleVentaListDto = _mapper.Map<List<DetalleVentaDto>>(registers);
            return new Pager<DetalleVentaDto>(
                DetalleVentaListDto,
                totalRegisters,
                DetalleVentaParams.PageIndex,
                DetalleVentaParams.PageSize
            );
        }
        
        private ActionResult<Pager<DetalleVentaDto>> BadRequest(ApiResponse apiResponse)
        {
        throw new NotImplementedException();
        }
        
        [HttpGet("1.1")]
        [MapToApiVersion("1.1")]
        public async Task<ActionResult<IEnumerable<DetalleVentaDto>>> Get1_1()
        {
            var registers = await _unitOfWork.DetallesVentas.GetAllAsync();
            var DetalleVentaListDto = _mapper.Map<List<DetalleVentaDto>>(registers);
            return DetalleVentaListDto;
        }
        
        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<DetalleVenta>> Post(DetalleVentaDto DetalleVentaDto)
        {
            var DetalleVenta = _mapper.Map<DetalleVenta>(DetalleVentaDto);
            _unitOfWork.DetallesVentas.Add(DetalleVenta);
            await _unitOfWork.SaveAsync();
            DetalleVentaDto.Id = DetalleVenta.Id;
            return CreatedAtAction(nameof(Post), new { id = DetalleVentaDto.Id }, DetalleVentaDto);
        }
        
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<DetalleVentaDto>> Put(
            int id,
            [FromBody] DetalleVentaDto DetalleVentaDto
        )
        {
            if (DetalleVentaDto == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var DetalleVenta = _mapper.Map<DetalleVenta>(DetalleVentaDto);
            _unitOfWork.DetallesVentas.Update(DetalleVenta);
            await _unitOfWork.SaveAsync();
            return DetalleVentaDto;
        }
        
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Delete(int id)
        {
            var DetalleVenta = await _unitOfWork.DetallesVentas.GetByIdAsync(id);
            _unitOfWork.DetallesVentas.Remove(DetalleVenta);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}