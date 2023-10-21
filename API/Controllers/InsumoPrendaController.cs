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
    public class InsumoPrendaController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public InsumoPrendaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pager<InsumoPrendaDto>>> Get(
            [FromQuery] Params InsumoParams
        )
        {
            if (InsumoParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork.InsumosPrendas.GetAllAsync(
                InsumoParams.PageIndex,
                InsumoParams.PageSize
            );
            var InsumoListDto = _mapper.Map<List<InsumoPrendaDto>>(registers);
            return new Pager<InsumoPrendaDto>(
                InsumoListDto,
                totalRegisters,
                InsumoParams.PageIndex,
                InsumoParams.PageSize
            );
        }
        
        private ActionResult<Pager<InsumoPrendaDto>> BadRequest(ApiResponse apiResponse)
        {
        throw new NotImplementedException();
        }
        
        [HttpGet("1.1")]
        [MapToApiVersion("1.1")]
        public async Task<ActionResult<IEnumerable<InsumoPrendaDto>>> Get1_1()
        {
            var registers = await _unitOfWork.InsumosPrendas.GetAllAsync();
            var InsumoListDto = _mapper.Map<List<InsumoPrendaDto>>(registers);
            return InsumoListDto;
        }
        
        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<InsumoPrenda>> Post(InsumoPrendaDto InsumoPrendaDto)
        {
            var Insumo = _mapper.Map<InsumoPrenda>(InsumoPrendaDto);
            _unitOfWork.InsumosPrendas.Add(Insumo);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(Post), InsumoPrendaDto);
        }
        
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<InsumoPrendaDto>> Put(
            int id,
            [FromBody] InsumoPrendaDto InsumoPrendaDto
        )
        {
            if (InsumoPrendaDto == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var Insumo = _mapper.Map<InsumoPrenda>(InsumoPrendaDto);
            _unitOfWork.InsumosPrendas.Update(Insumo);
            await _unitOfWork.SaveAsync();
            return InsumoPrendaDto;
        }
    }
}