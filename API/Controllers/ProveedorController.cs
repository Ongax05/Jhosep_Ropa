using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProveedorController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public ProveedorController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pager<ProveedorDto>>> Get(
            [FromQuery] Params ProveedorParams
        )
        {
            if (ProveedorParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork.Proveedores.GetAllAsync(
                ProveedorParams.PageIndex,
                ProveedorParams.PageSize
            );
            var ProveedorListDto = _mapper.Map<List<ProveedorDto>>(registers);
            return new Pager<ProveedorDto>(
                ProveedorListDto,
                totalRegisters,
                ProveedorParams.PageIndex,
                ProveedorParams.PageSize
            );
        }
        
        private ActionResult<Pager<ProveedorDto>> BadRequest(ApiResponse apiResponse)
        {
        throw new NotImplementedException();
        }
        
        [HttpGet("1.1")]
        [MapToApiVersion("1.1")]
        public async Task<ActionResult<IEnumerable<ProveedorDto>>> Get1_1()
        {
            var registers = await _unitOfWork.Proveedores.GetAllAsync();
            var ProveedorListDto = _mapper.Map<List<ProveedorDto>>(registers);
            return ProveedorListDto;
        }
        
        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Proveedor>> Post(ProveedorDto ProveedorDto)
        {
            var Proveedor = _mapper.Map<Proveedor>(ProveedorDto);
            _unitOfWork.Proveedores.Add(Proveedor);
            await _unitOfWork.SaveAsync();
            ProveedorDto.Id = Proveedor.Id;
            return CreatedAtAction(nameof(Post), new { id = ProveedorDto.Id }, ProveedorDto);
        }
        
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<ProveedorDto>> Put(
            int id,
            [FromBody] ProveedorDto ProveedorDto
        )
        {
            if (ProveedorDto == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var Proveedor = _mapper.Map<Proveedor>(ProveedorDto);
            _unitOfWork.Proveedores.Update(Proveedor);
            await _unitOfWork.SaveAsync();
            return ProveedorDto;
        }
        
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Delete(int id)
        {
            var Proveedor = await _unitOfWork.Proveedores.GetByIdAsync(id);
            _unitOfWork.Proveedores.Remove(Proveedor);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}