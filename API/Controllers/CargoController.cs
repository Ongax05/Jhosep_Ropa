using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CargoController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CargoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pager<CargoDto>>> Get(
            [FromQuery] Params CargoParams
        )
        {
            if (CargoParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork.Cargos.GetAllAsync(
                CargoParams.PageIndex,
                CargoParams.PageSize
            );
            var CargoListDto = _mapper.Map<List<CargoDto>>(registers);
            return new Pager<CargoDto>(
                CargoListDto,
                totalRegisters,
                CargoParams.PageIndex,
                CargoParams.PageSize
            );
        }

        private ActionResult<Pager<CargoDto>> BadRequest(ApiResponse apiResponse)
        {
        throw new NotImplementedException();
        }

        [HttpGet]
        [MapToApiVersion("1.1")]
        public async Task<ActionResult<IEnumerable<CargoDto>>> Get1_1()
        {
            var registers = await _unitOfWork.Cargos.GetAllAsync();
            var CargoListDto = _mapper.Map<List<CargoDto>>(registers);
            return CargoListDto;
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Cargo>> Post(CargoDto CargoDto)
        {
            var Cargo = _mapper.Map<Cargo>(CargoDto);
            _unitOfWork.Cargos.Add(Cargo);
            await _unitOfWork.SaveAsync();
            CargoDto.Id = Cargo.Id;
            return CreatedAtAction(nameof(Post), new { id = CargoDto.Id }, CargoDto);
        }

        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<CargoDto>> Put(
            int id,
            [FromBody] CargoDto CargoDto
        )
        {
            if (CargoDto == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var Cargo = _mapper.Map<Cargo>(CargoDto);
            _unitOfWork.Cargos.Update(Cargo);
            await _unitOfWork.SaveAsync();
            return CargoDto;
        }

        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Delete(int id)
        {
            var Cargo = await _unitOfWork.Cargos.GetByIdAsync(id);
            _unitOfWork.Cargos.Remove(Cargo);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}