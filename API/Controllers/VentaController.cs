using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class VentaController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public VentaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pager<VentaDto>>> Get(
            [FromQuery] Params VentaParams
        )
        {
            if (VentaParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork.Ventas.GetAllAsync(
                VentaParams.PageIndex,
                VentaParams.PageSize
            );
            var VentaListDto = _mapper.Map<List<VentaDto>>(registers);
            return new Pager<VentaDto>(
                VentaListDto,
                totalRegisters,
                VentaParams.PageIndex,
                VentaParams.PageSize
            );
        }
        
        private ActionResult<Pager<VentaDto>> BadRequest(ApiResponse apiResponse)
        {
        throw new NotImplementedException();
        }
        
        [HttpGet("1.1")]
        [MapToApiVersion("1.1")]
        public async Task<ActionResult<IEnumerable<VentaDto>>> Get1_1()
        {
            var registers = await _unitOfWork.Ventas.GetAllAsync();
            var VentaListDto = _mapper.Map<List<VentaDto>>(registers);
            return VentaListDto;
        }
        
        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Venta>> Post(VentaDto VentaDto)
        {
            var Venta = _mapper.Map<Venta>(VentaDto);
            _unitOfWork.Ventas.Add(Venta);
            await _unitOfWork.SaveAsync();
            VentaDto.Id = Venta.Id;
            return CreatedAtAction(nameof(Post), new { id = VentaDto.Id }, VentaDto);
        }
        
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<VentaDto>> Put(
            int id,
            [FromBody] VentaDto VentaDto
        )
        {
            if (VentaDto == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var Venta = _mapper.Map<Venta>(VentaDto);
            _unitOfWork.Ventas.Update(Venta);
            await _unitOfWork.SaveAsync();
            return VentaDto;
        }
        
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Delete(int id)
        {
            var Venta = await _unitOfWork.Ventas.GetByIdAsync(id);
            _unitOfWork.Ventas.Remove(Venta);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}