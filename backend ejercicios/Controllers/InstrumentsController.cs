using Microsoft.AspNetCore.Mvc;
using MiPrimerApi.Repositories;

namespace MiPrimerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstrumentsController : ControllerBase
    {
        
        //private static List<string> instruments = new() { "Guitarra", "Batería", "Piano" };

        /// <summary>
        /// Devuelve todos los instrumentos de la lista
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetInstruments()
        {
            return Ok(InstrumentRepository.Instruments);
        }

        /// <summary>
        /// Agrega un nuevo instrumento a la lista
        /// </summary>
        /// <param name="instrument"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddNewInstrument([FromBody] string instrument)
        {
            if (instrument == null)
            {
                return BadRequest("El campo es obligatorio.");
            }
            //instruments.Add(instrument);
            InstrumentRepository.Instruments.Add(instrument);
            return Ok($"Instrumento agregado con éxito a la lista: {instrument}");

        }

        /// <summary>
        /// Modifica un instrumento de la lista
        /// </summary>
        /// <param name="instrumentIndex"></param>
        /// <param name="newInstrument"></param>
        /// <returns></returns>
        [HttpPut("{instrumentIndex}")]
        public ActionResult UpdateInstrument([FromRoute] int instrumentIndex, [FromBody] string newInstrument)
        {
            if (newInstrument == null)
            {
                return BadRequest("El campo es obligatorio.");
            }

            if (instrumentIndex < 0 || instrumentIndex >= InstrumentRepository.Instruments.Count)
            {
                return BadRequest($"El índice {instrumentIndex} no es válido. Debe estar entre 0 y {InstrumentRepository.Instruments.Count - 1}.");
            }

            //instruments[instrumentIndex] = newInstrument;
            InstrumentRepository.Instruments[instrumentIndex] = newInstrument;
            return Ok($"Se modificó el elemento en posición {instrumentIndex} a {newInstrument}.");
        }

        /// <summary>
        /// Elimina un instrumento de la lista
        /// </summary>
        /// <param name="instrumentIndex"></param>
        /// <returns></returns>
        [HttpDelete("{instrumentIndex}")]
        public ActionResult DeleteInstrument(int instrumentIndex)
        {
            if (instrumentIndex < 0 || instrumentIndex >= InstrumentRepository.Instruments.Count)
            {
                return BadRequest($"El índice {instrumentIndex} no es válido. Debe estar entre 0 y {InstrumentRepository.Instruments.Count - 1}.");
            }
            //instruments.RemoveAt(instrumentIndex);
            InstrumentRepository.Instruments.RemoveAt(instrumentIndex);
            return Ok($"Elemento en posición {instrumentIndex} eliminado con éxito.");
        }
    }
}