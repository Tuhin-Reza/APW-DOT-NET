using System.Collections.Generic;

namespace ZeroHunger.DTOS
{
    public class FoodCollectRequestProcessingDTO : FoodCollectRequestDTO
    {
        public List<ProcessingDTO> Processings { get; set; }
        public FoodCollectRequestProcessingDTO()
        {
            Processings = new List<ProcessingDTO>();
        }
    }
}