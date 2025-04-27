
using MahasiswaAPI.Models;
using Microsoft.AspNetCore.Mvc;
namespace MahasiswaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaController : ControllerBase
    {
        private static List<Mahasiswa> mahasiswas = new List<Mahasiswa>
        {
            new Mahasiswa { Nama = "gilang", Nim = "1302000001" },
            new Mahasiswa { Nama = "habib", Nim = "1302000002" },
            new Mahasiswa { Nama = "musyafa", Nim = "1302000003" },
            new Mahasiswa { Nama = "fadhli", Nim = "1302000003" }
        };
        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> GetAll()
        {
            return Ok(mahasiswas);
        }
        [HttpGet("{index}")]
        public ActionResult<Mahasiswa> GetByIndex(int index)
        {
            if (index < 0 || index >= mahasiswas.Count)
            {
                return NotFound("Index tidak valid");
            }
            return Ok(mahasiswas[index]);
        }
        [HttpPost]
        public ActionResult<Mahasiswa> AddMahasiswa([FromBody] Mahasiswa newMahasiswa)
        {
            if (newMahasiswa == null || string.IsNullOrEmpty(newMahasiswa.Nama) || string.IsNullOrEmpty(newMahasiswa.Nim))
            {
                return BadRequest("Data mahasiswa tidak valid");
            }

            mahasiswas.Add(newMahasiswa);
            return CreatedAtAction(nameof(GetByIndex), new { index = mahasiswas.Count - 1 }, newMahasiswa);
        }
        [HttpDelete("{index}")]
        public IActionResult DeleteMahasiswa(int index)
        {
            if (index < 0 || index >= mahasiswas.Count)
            {
                return NotFound("Index tidak valid");
            }
            mahasiswas.RemoveAt(index);
            return NoContent();
        }
    }
}
