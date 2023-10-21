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
    public class InsumoProveedorController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InsumoProveedorController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pager<InsumoProveedorDto>>> Get(
            [FromQuery] Params InsumoParams
        )
        {
            if (InsumoParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork.InsumosProveedores.GetAllAsync(
                InsumoParams.PageIndex,
                InsumoParams.PageSize
            );
            var InsumoListDto = _mapper.Map<List<InsumoProveedorDto>>(registers);
            return new Pager<InsumoProveedorDto>(
                InsumoListDto,
                totalRegisters,
                InsumoParams.PageIndex,
                InsumoParams.PageSize
            );
        }

        private ActionResult<Pager<InsumoProveedorDto>> BadRequest(ApiResponse apiResponse)
        {
            throw new NotImplementedException();
        }

        [HttpGet("1.1")]
        [MapToApiVersion("1.1")]
        public async Task<ActionResult<IEnumerable<InsumoProveedorDto>>> Get1_1()
        {
            var registers = await _unitOfWork.InsumosProveedores.GetAllAsync();
            var InsumoListDto = _mapper.Map<List<InsumoProveedorDto>>(registers);
            return InsumoListDto;
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<InsumoProveedor>> Post(InsumoProveedorDto InsumoProveedorDto)
        {
            var Insumo = _mapper.Map<InsumoProveedor>(InsumoProveedorDto);
            _unitOfWork.InsumosProveedores.Add(Insumo);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(Post), InsumoProveedorDto);
        }

        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<InsumoProveedorDto>> Put(
            int id,
            [FromBody] InsumoProveedorDto InsumoProveedorDto
        )
        {
            if (InsumoProveedorDto == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var Insumo = _mapper.Map<InsumoProveedor>(InsumoProveedorDto);
            _unitOfWork.InsumosProveedores.Update(Insumo);
            await _unitOfWork.SaveAsync();
            return InsumoProveedorDto;
        }
    }
}
