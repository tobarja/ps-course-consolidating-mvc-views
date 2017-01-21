using System.Collections.Generic;

namespace PTC.Data
{
    public class TrainingProductViewModel
    {
        public List<TrainingProduct> Products { get; set; }

        public TrainingProductViewModel()
        {
            Products = new List<TrainingProduct>();
        }

        public void Get()
        {
            var mgr = new TrainingProductManager();
            Products = mgr.Get();
        }
    }
}
